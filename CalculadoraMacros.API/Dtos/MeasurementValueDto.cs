using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CalculadoraMacros.API.Dtos
{
    public class MeasurementValueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string MetricClassName;
        public int Sequence { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public int InputTypeId { get; set; }
        public bool IsRequired { get; set; }
        public IList<MetricClassificationDto> MetricClassificationDto { get; set; } 
       
        public IEnumerable<ValidationResult> Validate(ValidationContext vc)
         {
            var fields = new[] { "Value" };
            
            if (Value > MaxValue)
                yield return new ValidationResult(Name + " debe ser menor que " + MaxValue.ToString(), fields);
            if (Value < MinValue)
                yield return new ValidationResult(Name + " debe ser mayor que " + MinValue.ToString(), fields);
         }
    }

}