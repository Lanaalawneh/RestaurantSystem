using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Restorent.Models;

namespace Restorent.Areas.Admin.ViewModels
{
    public class MasterWorkingHourModel : BaseModel
    {

        public int MasterWorkingHourId { get; set; }

        [Display(Name = "Name")]
        public string? MasterWorkingHourIdName { get; set; }


        public string? MasterWorkingHourIdTimeFormTo { get; set; }


    }
}
