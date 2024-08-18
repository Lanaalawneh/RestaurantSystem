using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorent.Models
{
    public partial class SystemSetting : BaseModel
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
    }
}
