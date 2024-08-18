using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Builder.Extensions;
using Restorent.Models;

namespace Restorent.Areas.Admin.ViewModels
{
    public class MasterPartnerModel : BaseModel
    {
        public int MasterPartnerId { get; set; }

        [Display(Name = "Partner Name")]
        public string? MasterPartnerName { get; set; }

        [Display(Name = "Img")]
        public string? MasterPartnerLogoImageUrl { get; set; }

        [Display(Name = "Url")]
        public string? MasterPartnerWebsiteUrl { get; set; }

        public IFormFile? FIle { get; set; }
    }
}
