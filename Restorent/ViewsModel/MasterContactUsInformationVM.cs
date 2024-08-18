using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterContactUsInformationVM
    {
        public int MasterContactUsInformationId { get; set; }

        [Display(Name = "Idesc")]
        public string? MasterContactUsInformationIdesc { get; set; }

        [Display(Name = "ImageUrl")]
        public string? MasterContactUsInformationImageUrl { get; set; }

        [Display(Name = "Redirect")]
        public string? MasterContactUsInformationRedirect { get; set; }
    }
}
