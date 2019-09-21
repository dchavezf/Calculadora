using System;
using System.Collections.Generic;

namespace CalculadoraMacros.API.Models
{
    public partial class PhysicalActivity
    {
        public PhysicalActivity()
        {
            InverseNextPhysicalActivity = new HashSet<PhysicalActivity>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Factor { get; set; }
        public int NextPhysicalActivityId { get; set; }
        public decimal ProteinPerKgFactor { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual PhysicalActivity NextPhysicalActivity { get; set; }
        public virtual ICollection<PhysicalActivity> InverseNextPhysicalActivity { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
