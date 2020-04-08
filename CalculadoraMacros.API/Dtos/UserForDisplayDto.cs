using System;

namespace CalculadoraMacros.API.Dtos
{
    public class UserForDisplayDto
    {
        
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenreId { get; set; }
        public int GenreName { get; set; }
        public bool IsMetricSystem { get; set; }
         public decimal HeightValue { get; set; }
        public int LastMeasurementId { get; set; }    
    }
}