using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CalculadoraMacros.API.Models;

namespace CalculadoraMacros.API.Data
{
    public class CalcRepository: ICalcRepository
    {
        private readonly DataContext _context;

        public CalcRepository(DataContext context)
        {
            _context = context;
        }
        public Task<Measurement> CalculateMacros(User user, Measurement m)
        {
            throw new System.NotImplementedException();
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
  
        public  MeasurementValue GetMeasurementValue(FieldInfo field)
        {
            MeasurementValue p=new MeasurementValue();
            p.Id=0;
            p.Name = field.Name;
            p.Value=(decimal)field.GetValue(null);
            return  p;
        }

        public HashSet<MeasurementValue> GetMeasurementValues(object obj) {
            Type type = obj.GetType();
            // Obtain all fields with type pointer.
            FieldInfo[] fields = type.GetFields();
            HashSet<MeasurementValue> m=new HashSet<MeasurementValue>();
            foreach (var field in fields){
                if(field.GetType().ToString().Equals("decimal")){
                    m.Add(GetMeasurementValue(field));
                }
            }
            return m;
        }
        public Task<Measurement> GetFunnelMeasurement(
            int genre, decimal height, int physicalActivityId, 
            bool isMetricSystem, int measureDeviceTypeId,
            HashSet<MeasurementValue> values
        )
        {
            User user=new User();
            user.Genre= genre;
            user.HeightValue= height;
            user.PhysicalActivityId =physicalActivityId;

            Measurement m=new Measurement();
            m.User=user;
            m.IsMetricSystem=isMetricSystem;
            m.MeasureDeviceTypeId=measureDeviceTypeId;
        

            throw new NotImplementedException();
        }
    }
}