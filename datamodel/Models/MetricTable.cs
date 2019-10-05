using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class MetricTable
    {
        public int Id { get; set; }
        public int MetricId { get; set; }
        public int MetricClassificationId { get; set; }
        public decimal LowValue { get; set; }
        public decimal HiValue { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual Metric Metric { get; set; }
        public virtual MetricClassification MetricClassification { get; set; }
    }
}
