using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.Models
{
    public partial class MasterPartner : BaseModel
    {
        public int MasterPartnerId { get; set; }

        [Display(Name = "Partne Name")]
        public string? MasterPartnerName { get; set; }

        [Display(Name = "Img")]
        public string? MasterPartnerLogoImageUrl { get; set; }

        [Display(Name = "Url")]
        public string? MasterPartnerWebsiteUrl { get; set; }
    }
}
