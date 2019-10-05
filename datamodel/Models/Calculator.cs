using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class Calculator
    {
        public Calculator()
        {
            CalculatorConfig = new HashSet<CalculatorConfig>();
            Measurement = new HashSet<Measurement>();
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

        public virtual ICollection<CalculatorConfig> CalculatorConfig { get; set; }
        public virtual ICollection<Measurement> Measurement { get; set; }
    }
}
