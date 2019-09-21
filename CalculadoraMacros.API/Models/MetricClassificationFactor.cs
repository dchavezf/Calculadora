using System;
using System.Collections.Generic;

namespace CalculadoraMacros.API.Models
{
    public partial class MetricClassificationFactor
    {
        public int Id { get; set; }
        public int MetricClassificationId { get; set; }
        public string Name { get; set; }
        public decimal Factor { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual MetricClassification MetricClassification { get; set; }
    }
}
