using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class WebScrapUrl
    {
        public WebScrapUrl()
        {
            WebScrapDetail = new HashSet<WebScrapDetail>();
        }

        public int Id { get; set; }
        public string WebScrapUrl1 { get; set; }
        public int WebScrapId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateScrapped { get; set; }

        public virtual WebScrap WebScrap { get; set; }
        public virtual ICollection<WebScrapDetail> WebScrapDetail { get; set; }
    }
}
