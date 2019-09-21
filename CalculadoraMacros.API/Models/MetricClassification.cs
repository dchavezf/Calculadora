using System;
using System.Collections.Generic;

namespace CalculadoraMacros.API.Models
{
    public partial class MetricClassification
    {
        public MetricClassification()
        {
            MeasurementKpiresult = new HashSet<MeasurementKpiresult>();
            MetricClassificationFactor = new HashSet<MetricClassificationFactor>();
            MetricTable = new HashSet<MetricTable>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int MetricClassId { get; set; }
        public int KpiColorId { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual Kpicolor KpiColor { get; set; }
        public virtual MetricClass MetricClass { get; set; }
        public virtual ICollection<MeasurementKpiresult> MeasurementKpiresult { get; set; }
        public virtual ICollection<MetricClassificationFactor> MetricClassificationFactor { get; set; }
        public virtual ICollection<MetricTable> MetricTable { get; set; }
    }
}
