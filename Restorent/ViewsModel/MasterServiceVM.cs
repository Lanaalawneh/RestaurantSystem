using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterServiceVM
    {

        public int MasterServiceId { get; set; }

        [Display(Name = "Service Title")]
        public string? MasterServiceTitle { get; set; }

        [Display(Name = "Desc")]
        public string? MasterServiceDesc { get; set; }

        [Display(Name = "Image")]
        public string? MasterServiceImage { get; set; }
    }
}
