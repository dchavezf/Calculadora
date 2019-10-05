using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class Measurement
    {
        public Measurement()
        {
            MeasurementInput = new HashSet<MeasurementInput>();
            MeasurementKpiresult = new HashSet<MeasurementKpiresult>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsMetricSystem { get; set; }
        public int MeasureDeviceTypeId { get; set; }
        public int CalculatorId { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual Calculator Calculator { get; set; }
        public virtual MeasureDeviceType MeasureDeviceType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<MeasurementInput> MeasurementInput { get; set; }
        public virtual ICollection<MeasurementKpiresult> MeasurementKpiresult { get; set; }
    }
}
