namespace CalculadoraMacros.API.Dtos
{
    public class MeasurementKPIDto
    {
        // Valores calculados y de referencia
        public string MetricCode { get; set; }
        public decimal KpiValue { get; set; }
        public decimal Value { get; set; }
        public decimal KpiObjectiveValue { get; set; }
        public decimal ObjectiveValue { get; set; }
        public decimal GapValue { get; set; }
        public decimal KpiGapValue { get; set; }
        //Valores en Metric
        public string MetricName { get; set; }
        public string UofM {get; set;}
        // Classification
        public string MetricClassificationName { get; set; }
        public string KPIColor { get; set; }
        //Keys
    //   public int Id { get; set; }
    //   public int MeasurementId { get; set; }
    //   public int MetricId { get; set; }
    //   public int MetricClassId { get; set; }
    //   public int MetricClassificationId { get; set; }   
    }
}