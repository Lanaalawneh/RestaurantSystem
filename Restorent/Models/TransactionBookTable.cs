using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorent.Models
{
    public partial class TransactionBookTable : BaseModel
    {
        public int TransactionBookTableId { get; set; }

        [Display(Name = "FullName")]
        public string? TransactionBookTableFullName { get; set; }

        [Display(Name = "Email")]
        public string? TransactionBookTableEmail { get; set; }

        [Display(Name = "MobileNumber")]
        public string? TransactionBookTableMobileNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime? TransactionBookTableDate { get; set; }
    }
}
