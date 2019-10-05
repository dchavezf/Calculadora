using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using CalculadoraMacros.API.Data;

namespace CalculadoraMacros.API.Dtos
{
    public class MeasurementDto
    {
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsMetricSystem { get; set; }
        [Required]
        public int MeasureDeviceTypeId { get; set; }   
        public DateTime MeasurementDate { get; set; } 
        public IList<MeasurementValue> MeasurementValues { get; set; } 
    
    }
}