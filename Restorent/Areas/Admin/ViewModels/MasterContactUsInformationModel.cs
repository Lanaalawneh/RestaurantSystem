using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Restorent.Models;

namespace Restorent.Areas.Admin.ViewModels
{
    public class MasterContactUsInformationModel /*: BaseModel*/
    {
        public int MasterContactUsInformationId { get; set; }

        [Display(Name = "Idesc")]
        public string? MasterContactUsInformationIdesc { get; set; }

        [Display(Name = "ImageUrl")]
        public string? MasterContactUsInformationImageUrl { get; set; }

        [Display(Name = "Redirect")]
        public string? MasterContactUsInformationRedirect { get; set; }

        public IFormFile? FIle { get; set; }
    }
}
