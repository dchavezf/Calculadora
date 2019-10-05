using System;
using System.Collections.Generic;

namespace CalculadoraMacros.API.Models
{
    public partial class User
    {
        public User()
        {
            Measurement = new HashSet<Measurement>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime BirthDate { get; set; }
        public int Genre { get; set; }
        public decimal HeightValue { get; set; }
        public bool IsMetricSystem { get; set; }
        public string LastUser { get; set; }
        public DateTime LastDate { get; set; }
        public string LastMachine { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StatusFlag { get; set; }

        public virtual ICollection<Measurement> Measurement { get; set; }
    }
}
