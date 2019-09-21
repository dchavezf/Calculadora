using System;
using System.Collections.Generic;

namespace CalculadoraMacros.API.Models
{
    public partial class MetricClass
    {
        public MetricClass()
        {
            Metric = new HashSet<Metric>();
            MetricClassification = new HashSet<MetricClassification>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual ICollection<Metric> Metric { get; set; }
        public virtual ICollection<MetricClassification> MetricClassification { get; set; }
    }
}
