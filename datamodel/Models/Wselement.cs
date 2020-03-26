using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class Wselement
    {
        public int Id { get; set; }
        public int WebScrapId { get; set; }
        public string UrlLabel { get; set; }
        public string ElementName { get; set; }
        public string SearchBy { get; set; }
        public string StringToFind { get; set; }
        public string Action { get; set; }

        public virtual WebScrap WebScrap { get; set; }
    }
}
