using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.Models
{
    public partial class TransactionNewsletter : BaseModel
    {
        public int TransactionNewsletterId { get; set; }

        [Display(Name = "Email")]
        public string? TransactionNewsletterEmail { get; set; }
    }
}
