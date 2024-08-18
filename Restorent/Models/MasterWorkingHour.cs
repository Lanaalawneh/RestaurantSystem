using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorent.Models
{
    public partial class MasterWorkingHour : BaseModel
    {
        public int MasterWorkingHourId { get; set; }

        [Display(Name = "Name")]
        public string? MasterWorkingHourIdName { get; set; }

       
        public string? MasterWorkingHourIdTimeFormTo { get; set; }
    }
}
