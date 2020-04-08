using System;
using System.ComponentModel.DataAnnotations;

namespace CalculadoraMacros.API.Dtos
{
    public class Funnel2Dto
    {
        [Required]
        public int Genre { get; set; }
        [Required]
        public int PhysicalActivity { get; set; }
        [Required]
        public bool IsMetricSystem { get; set; }        
        [Required]
        public int Age {get; set;}   
        [Required]
        public float HeightValue {get; set;}
        [Required]
        public float WeightValue {get; set;}
        [Required]
        public float NeckValue {get; set;}
        [Required]
        public float WaistValue {get; set;}
        [Required]
        public float HipsValue {get; set;}
    }
}