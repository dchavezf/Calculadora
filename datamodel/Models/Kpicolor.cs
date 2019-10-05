using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class Kpicolor
    {
        public Kpicolor()
        {
            MetricClassification = new HashSet<MetricClassification>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual ICollection<MetricClassification> MetricClassification { get; set; }
    }
}
