using System.ComponentModel.DataAnnotations;
using Restorent.Models;

namespace Restorent.Areas.Admin.ViewModels
{
    public class MasterOfferModel : BaseModel
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

        public IFormFile? FIle { get; set; }
    }
}
