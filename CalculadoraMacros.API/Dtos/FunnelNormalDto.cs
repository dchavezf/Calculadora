using System;
using System.ComponentModel.DataAnnotations;

namespace CalculadoraMacros.API.Dtos
{
    public class FunnelNormalDto
    {
        [Required]
        public int Genre { get; set; }
        [Required]
        public int PhysicalActivity { get; set; }
        [Required]
        public int [] Meat {get; set;}
        [Required]
        public int [] Vegetables {get; set;}
        [Required]
        public int [] OtherFoods {get; set;}

        // Screen 6 Your Measurement
        [Required]
        public bool IsMetricSystem { get; set; }        
        [Required]
        public int Age {get; set;}   
        [Required]
        public decimal HeightValue {get; set;}
        [Required]
        public decimal WeightValue {get; set;}
        [Required]
        public decimal WeightObjetive {get; set;}
    }
}