using System;
using System.Collections.Generic;

namespace CalculadoraMacros.API.Models
{
    public partial class CalculatorConfig
    {
        public int Id { get; set; }
        public bool MandatoryFlag { get; set; }
        public int MetricId { get; set; }
        public bool InputFlag { get; set; }
        public int Sequence { get; set; }
        public int CalculatorId { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual Calculator Calculator { get; set; }
        public virtual Metric Metric { get; set; }
    }
}
