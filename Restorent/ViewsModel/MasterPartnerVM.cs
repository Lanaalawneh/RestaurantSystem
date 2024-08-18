using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterPartnerVM
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
