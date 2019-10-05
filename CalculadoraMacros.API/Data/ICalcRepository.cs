using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CalculadoraMacros.API.Dtos;
using CalculadoraMacros.API.Models;

namespace CalculadoraMacros.API.Data
{
    public interface ICalcRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<Measurement> GetFunnelMeasurement(int genre, decimal height, int physicalActivityId, bool isMetricSystem, int measureDeviceTypeId, HashSet<MeasurementValue> values);
        MeasurementValue GetMeasurementValue(FieldInfo field);
        HashSet<MeasurementValue> GetMeasurementValues(object obj);
        
    }
}