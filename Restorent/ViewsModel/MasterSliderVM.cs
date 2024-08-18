using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterSliderVM
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
