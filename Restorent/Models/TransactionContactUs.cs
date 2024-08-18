using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorent.Models
{
    public partial class TransactionContactUs : BaseModel
    {
        public int TransactionContactUsId { get; set; }

        [Display(Name = "FullName")]
        public string? TransactionContactUsFullName { get; set; }

        [Display(Name = "Email")]
        public string? TransactionContactUsEmail { get; set; }

        [Display(Name = "Subject")]
        public string? TransactionContactUsSubject { get; set; }

        [Display(Name = "Message")]
        public string? TransactionContactUsMessage { get; set; }
    }
}
