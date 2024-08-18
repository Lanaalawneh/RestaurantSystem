using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.Models
{
    public partial class MasterCategoryMenu : BaseModel
    {


        public int MasterCategoryMenuId { get; set; }

        [Display(Name = "Category Menu Name")]
        public string? MasterCategoryMenuName { get; set; }

     }
}
