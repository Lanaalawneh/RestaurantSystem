using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.Models
{
    public partial class MasterOffer : BaseModel
    {
        public int MasterOfferId { get; set; }

        [Display(Name = "Tittle")]
        public string? MasterOfferTitle { get; set; }

        [Display(Name = "Breef")]
        public string? MasterOfferBreef { get; set; }

        [Display(Name = "Desc")]
        public string? MasterOfferDesc { get; set; }

        [Display(Name = "Image")]
        public string? MasterOfferImageUrl { get; set; }

        
    }
}
