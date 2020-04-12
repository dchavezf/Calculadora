using System;

namespace CalculadoraMacros.API.Dtos
{
    public class FunnelMasterDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsMetricSystem { get; set; }
        public int MeasureDeviceTypeId { get; set; }
        public int CalculatorId { get; set; }
        public int Genre { get; set; }
        public int PhysicalActivity { get; set; }
        public int [] Meat {get; set;}
        public int [] Vegetables {get; set;}
        public int [] OtherFoods {get; set;}
        public int Age {get; set;}   
        public decimal HeightValue {get; set;}
        public decimal WeightValue {get; set;}
        public decimal WeightObjetive {get; set;}
        public decimal NeckValue {get; set;}
        public decimal WaistValue {get; set;}
        public decimal HipsValue {get; set;}
        public decimal IMC  {get; set;}
    }
}