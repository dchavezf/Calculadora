using System;
using System.Collections.Generic;

namespace CalculadoraMacros.API.Models
{
    public partial class Metric
    {
        public Metric()
        {
            CalculatorConfig = new HashSet<CalculatorConfig>();
            MeasurementInput = new HashSet<MeasurementInput>();
            MeasurementKpiresult = new HashSet<MeasurementKpiresult>();
            MetricTable = new HashSet<MetricTable>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int UnitOfMeasureId { get; set; }
        public int MetricClassId { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public int InputTypeId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsBaseLine { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual MetricClass MetricClass { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual ICollection<CalculatorConfig> CalculatorConfig { get; set; }
        public virtual ICollection<MeasurementInput> MeasurementInput { get; set; }
        public virtual ICollection<MeasurementKpiresult> MeasurementKpiresult { get; set; }
        public virtual ICollection<MetricTable> MetricTable { get; set; }
    }
}
