using Restorent.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterItemMenuVM
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

        public MasterCategoryMenu? MasterCategoryMenu { get; set; }


    }
}
