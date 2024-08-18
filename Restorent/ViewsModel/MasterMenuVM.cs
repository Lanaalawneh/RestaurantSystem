using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterMenuVM
    {
        public int MasterMenuId { get; set; }

        [Display(Name = "Menu Name")]
        public string MasterMenuName { get; set; } = null!;

        [Display(Name = "Menu Url")]
        public string MasterMenuUrl { get; set; } = null!;


    }
}
