using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class WebScrapDetail
    {
        public int Id { get; set; }
        public int WebScrapUrlId { get; set; }
        public string ElementName { get; set; }
        public string ElementValue { get; set; }

        public virtual WebScrapUrl WebScrapUrl { get; set; }
    }
}
