using System;
using System.Collections.Generic;

namespace datamodel.Models
{
    public partial class WebScrap
    {
        public WebScrap()
        {
            WebScrapUrl = new HashSet<WebScrapUrl>();
            Wselement = new HashSet<Wselement>();
            Wsrun = new HashSet<Wsrun>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DirUrl { get; set; }

        public virtual ICollection<WebScrapUrl> WebScrapUrl { get; set; }
        public virtual ICollection<Wselement> Wselement { get; set; }
        public virtual ICollection<Wsrun> Wsrun { get; set; }
    }
}
