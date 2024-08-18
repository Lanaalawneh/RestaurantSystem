using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Restorent.Models;

namespace Restorent.Areas.Admin.ViewModels
{
    public class SystemSettingModel : BaseModel
    {
        public int SystemSettingId { get; set; }

        [Display(Name = "Logo1")]
        public string? SystemSettingLogoImageUrl { get; set; }

        [Display(Name = "Logo2")]
        public string? SystemSettingLogoImageUrl2 { get; set; }

        [Display(Name = "CopyRight")]
        public string? SystemSettingCopyright { get; set; }

        [Display(Name = "WlcNote Title")]
        public string? SystemSettingWelcomeNoteTitle { get; set; }

        [Display(Name = "WlcNote Breef")]
        public string? SystemSettingWelcomeNoteBreef { get; set; }

        [Display(Name = "WlcNote Desc")]
        public string? SystemSettingWelcomeNoteDesc { get; set; }

        [Display(Name = "WlcNote Url")]
        public string? SystemSettingWelcomeNoteUrl { get; set; }

        [Display(Name = "WlcNote Img")]
        public string? SystemSettingWelcomeNoteImageUrl { get; set; }

        [Display(Name = "Map Loc")]
        public string? SystemSettingMapLocation { get; set; }

        public IFormFile? ImagUrl1 { get; set; }
        public IFormFile? ImagUrl2 { get; set; }
        public IFormFile? ImagUrl3 { get; set; }
    }
}
