using System;
using System.ComponentModel.DataAnnotations;

namespace CalculadoraMacros.API.Dtos
{
    public class Funnel1Dto
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
        public float HeightValue {get; set;}
        [Required]
        public float WeightValue {get; set;}
        [Required]
        public float WeightObjetive {get; set;}
    }
}