using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterSocialMediaVM
    {
        public int MasterSocialMediaId { get; set; }

        [Display(Name = "Img")]
        public string MasterSocialMediaImageUrl { get; set; } = null!;

        [Display(Name = "Url")]
        public string MasterSocialMediaUrl { get; set; } = null!;
    }
}
