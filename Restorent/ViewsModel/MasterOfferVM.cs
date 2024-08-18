using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Restorent.ViewsModel
{
    public class MasterOfferVM
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
