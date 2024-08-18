using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorent.Models
{
    public partial class MasterService : BaseModel
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
