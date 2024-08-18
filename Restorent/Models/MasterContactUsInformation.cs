using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorent.Models
{
    public partial class MasterContactUsInformation : BaseModel
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
