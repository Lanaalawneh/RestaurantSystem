using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorent.Models
{
    public partial class MasterSlider : BaseModel
    {
        public int MasterSliderId { get; set; }

        [Display(Name = "Slider Title")]
        public string? MasterSliderTitle { get; set; }

        [Display(Name = "Breef")]
        public string? MasterSliderBreef { get; set; }

        [Display(Name = "Desc")]
        public string? MasterSliderDesc { get; set; }

        [Display(Name = "Url")]
        public string? MasterSliderUrl { get; set; }
    }
}
