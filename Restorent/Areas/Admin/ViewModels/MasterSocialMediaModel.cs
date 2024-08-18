using System.ComponentModel.DataAnnotations;
using Restorent.Models;

namespace Restorent.Areas.Admin.ViewModels
{
    public class MasterSocialMediaModel : BaseModel
    {

        public int MasterSocialMediaId { get; set; }

        [Display(Name = "Img")]
        public string MasterSocialMediaImageUrl { get; set; } = null!;

        [Display(Name = "Url")]
        public string MasterSocialMediaUrl { get; set; } = null!;

        public IFormFile? FIle { get; set; }

    }
}
