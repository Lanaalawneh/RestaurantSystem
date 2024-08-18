using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorent.Models
{
    public partial class MasterSocialMedia : BaseModel
    {
        public int MasterSocialMediaId { get; set; }

        [Display(Name = "Img")]
        public string MasterSocialMediaImageUrl { get; set; } = null!;

        [Display(Name = "Url")]
        public string MasterSocialMediaUrl { get; set; } = null!;
    }
}
