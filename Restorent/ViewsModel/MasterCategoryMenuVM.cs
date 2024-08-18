using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterCategoryMenuVM
    {
        public int MasterCategoryMenuId { get; set; }

        [Display(Name = "Category Menu Name")]
        public string? MasterCategoryMenuName { get; set; }
    }
}
