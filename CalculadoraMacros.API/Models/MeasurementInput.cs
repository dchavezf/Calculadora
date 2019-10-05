using System;
using System.Collections.Generic;

namespace CalculadoraMacros.API.Models
{
    public partial class MeasurementInput
    {
        public int Id { get; set; }
        public int MeasurementId { get; set; }
        public int MetricId { get; set; }
        public decimal Value { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual Metric Metric { get; set; }
    }
}
