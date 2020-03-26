using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class Wsrun
    {
        public int Id { get; set; }
        public int WebScrapId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual WebScrap WebScrap { get; set; }
    }
}
