using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterWorkingHourVM
    {
        public int MasterWorkingHourId { get; set; }

        [Display(Name = "Name")]
        public string? MasterWorkingHourIdName { get; set; }


        public string? MasterWorkingHourIdTimeFormTo { get; set; }
    }
}
