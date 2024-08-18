using System.ComponentModel.DataAnnotations;
using Restorent.Models;

namespace Restorent.Areas.Admin.ViewModels
{
    public class MasterServiceModel : BaseModel
    {
        public int MasterServiceId { get; set; }

        [Display(Name = "Service Title")]
        public string? MasterServiceTitle { get; set; }

        [Display(Name = "Desc")]
        public string? MasterServiceDesc { get; set; }

        [Display(Name = "Image")]
        public string? MasterServiceImage { get; set; }

        public IFormFile? FIle { get; set; }
    }
}
