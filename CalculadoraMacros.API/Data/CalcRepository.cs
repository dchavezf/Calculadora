using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CalculadoraMacros.API.Dtos;
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
            /*
            var query = _context.Users.AsQueryable();

            query = query.IgnoreQueryFilters();

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
            */
        }
      
        public Task<Measurement> CalculateMacros(UserForFunnelDto userForFunnelDto)
        {
            var m=new Measurement();
            
            m.Date=System.DateTime.Now;
            m.IsMetricSystem=userForFunnelDto.IsMetricSystem;
            m.MeasureDeviceTypeId=1;
            m.CalculatorId=1;
            
        }
        public Task<MeasurementInput> InsertMeasurementInput(){
            var mi=new MeasurementInput();
            mi.
        }
    }
}