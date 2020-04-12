using System;
using System.ComponentModel.DataAnnotations;

namespace CalculadoraMacros.API.Dtos
{
    public class FunnelNormalPlusBodyDto
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
        public decimal HeightValue {get; set;}
        [Required]
        public decimal WeightValue {get; set;}
        [Required]
        public decimal NeckValue {get; set;}
        [Required]
        public decimal WaistValue {get; set;}
        [Required]
        public decimal HipsValue {get; set;}
    }
}