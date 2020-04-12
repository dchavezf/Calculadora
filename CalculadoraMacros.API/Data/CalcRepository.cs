using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CalculadoraMacros.API.Dtos;
using CalculadoraMacros.API.Models;
using System.Linq;


namespace CalculadoraMacros.API.Data
{
    public class CalcRepository : ICalcRepository
    {
        public const int SCALE_NORMAL = 1;
        public const int SCALE_BIOIMPEDANCE = 2;
        public const int SCALE_NORMALPLUSBODY = 3;
        public const int CALC_FAT = 1;
        public const decimal IMC_OBJETIVE = 21.5M;
        private readonly DataContext _context;
        public CalcRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        void ICalcRepository.Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        void ICalcRepository.Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICalcRepository.SaveAll()
        {
            throw new NotImplementedException();
        }
        Task<User> ICalcRepository.GetUser(int id)
        {
            throw new NotImplementedException();

        }

        public async Task<Metric> getMetric(string MetricCode)
        {
            var data = from m in _context.Metric
                       where m.Code.Trim().Equals(MetricCode.Trim())
                       select m;
            return await data.ToAsyncEnumerable().First();
        }
        public async Task<MeasurementKpiresult> getClassification(MeasurementKpiresult kpi)
        {
            kpi.GapValue = 0;
            kpi.KpiGapValue = 0;
            if (kpi.Value > kpi.ObjectiveValue)
            {
                kpi.GapValue = kpi.Value - kpi.ObjectiveValue;
                kpi.KpiGapValue = kpi.KpiValue - kpi.KpiObjectiveValue;
            }
            var data = from t in _context.MetricTable
                       where t.MetricId == kpi.MetricId &&
                           kpi.Value >= t.LowValue && kpi.Value <= t.HiValue
                       select t;
            var classification = await data.ToAsyncEnumerable().First();
            kpi.MetricClassificationId = classification.MetricClassification.Id;
            return kpi;
        }
        public async Task<MeasurementKpiresult> CalculateIMC(FunnelMasterDto f)
        {
            var kpi = new MeasurementKpiresult();
            var metric = await getMetric("IMCValue");
            kpi.MetricId = metric.Id;
            kpi.KpiValue = Convert.ToDecimal(Convert.ToDouble(f.WeightValue) /
                        Math.Pow(Convert.ToDouble(f.HeightValue / 100M), 2));
            kpi.Value = f.WeightValue;
            kpi.KpiObjectiveValue = CalcRepository.IMC_OBJETIVE;
            kpi.ObjectiveValue = Convert.ToDecimal(Math.Pow(Convert.ToDouble(f.HeightValue / 100M), 2)) * kpi.ObjectiveValue;

            return await getClassification(kpi);
        }
        public async Task<MeasurementKpiresult> CalculatePcFat(FunnelMasterDto f)
        {
            var kpi = new MeasurementKpiresult();
            var metric = await getMetric("PcFatValue");
            kpi.MetricId = metric.Id;

            var pcFat = 0m;
            if (f.MeasureDeviceTypeId == 3)
            {
                if (f.Genre == 1)
                {
                    pcFat = Convert.ToDecimal(
                        495 / (
                            1.0324 - 0.19077 * (
                                Math.Log(
                                    Convert.ToDouble(f.WaistValue - f.NeckValue)
                                )
                            ) +
                            0.15456 * (
                                Math.Log(
                                    Convert.ToDouble(f.HeightValue)
                                )
                            )
                        ) - 450
                    );
                }
                else
                {
                    pcFat = Convert.ToDecimal(
                        495 / (
                            1.29579 - 0.35004 * (
                                Math.Log(
                                    Convert.ToDouble(f.HipsValue + f.WaistValue - f.NeckValue)
                                )
                            ) +
                            0.22100 * (
                                Math.Log(
                                    Convert.ToDouble(f.HeightValue)
                                )
                            )
                        ) - 450
                    );
                }
            }
            kpi.Value = pcFat * f.WeightValue;
            kpi.KpiValue = pcFat;
            kpi.KpiObjectiveValue = (
                        1.2M * CalcRepository.IMC_OBJETIVE +
                        Convert.ToDecimal(0.23 * f.Age - 10.8 * f.Genre - 5.4)
                    ) / 100;
            kpi.ObjectiveValue = kpi.KpiObjectiveValue * f.WeightValue;
            return await getClassification(kpi);
        }


        public async Task<Measurement> CalculateMacros(FunnelMasterDto funnel)
        {
            var m = new Measurement();
            m.UpdateDate = DateTime.Now;
            m.IsMetricSystem = funnel.IsMetricSystem;
            m.MeasureDeviceTypeId = funnel.MeasureDeviceTypeId;
            m.CalculatorId = funnel.CalculatorId;

            MeasurementKpiresult imc = await CalculateIMC(funnel);
            MeasurementKpiresult pcFat = await CalculatePcFat(funnel);

            m.MeasurementKpiresult.Add(imc);
            m.MeasurementKpiresult.Add(pcFat);
            return m;
        }
    }
}