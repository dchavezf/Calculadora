using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using CalculadoraMacros.API.Data;

namespace CalculadoraMacros.API.Dtos
{
    public class MeasurementDto
    {
        public int Id { get; set; } 
        public DateTime MeasurementDate { get; set; } 
        public bool IsMetricSystem { get; set; }
        public IList<MeasurementValueDto> MeasurementValues { get; set; }  
        public IList<MeasurementKPIDto> MeasurementKPIDto { get; set; }    
    }
}