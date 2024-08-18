using Restorent.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.Areas.Admin.ViewModels
{
    public class MasterItemMenuModel : BaseModel
    {
        public int MasterItemMenuId { get; set; }

        [Display(Name = "CategoryMenuId ")]
        public int? MasterCategoryMenuId { get; set; }

        [Display(Name = "ItemMenuTitle ")]
        public string? MasterItemMenuTitle { get; set; }

        [Display(Name = "Breef")]
        public string? MasterItemMenuBreef { get; set; }

        [Display(Name = "Desc ")]
        public string? MasterItemMenuDesc { get; set; }

        [Display(Name = "Price ")]
        public decimal? MasterItemMenuPrice { get; set; }

        [Display(Name = "ImgUrl ")]
        public string? MasterItemMenuImageUrl { get; set; }

        [Display(Name = "Date ")]
        public DateTime? MasterItemMenuDate { get; set; }


        [Display(Name = "Total Price ")]
        public string? MasterItemMenuTotalPrice { get; set; }


        public MasterCategoryMenu? MasterCategoryMenu { get; set; }

        public IFormFile? FIle { get; set; }
    }
}
