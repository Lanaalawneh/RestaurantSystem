using Restorent.Models;

namespace Restorent.ViewsModel
{
    public class HomeModel
    {

        

        public List<MasterCategoryMenu> ListMasterCategoryMenu { get; set; }

        public List<MasterContactUsInformation> ListMasterContactUsInformation { get; set; }

        public List<MasterItemMenu> ListMasterItemMenu { get; set; }

        public List<MasterMenu> ListMasterMenu { get; set; }

        public MasterOffer MasterOffer { get; set; }

        public List<MasterPartner> ListMasterPartner { get; set; }

        public List<MasterService> ListMasterService { get; set; }

        public List<MasterSlider> ListMasterSlider { get; set; }

        public List<MasterSocialMedia> ListMasterSocialMedia { get; set; }

        public List<MasterWorkingHour> ListMasterWorkingHour { get; set; }

        public SystemSetting SystemSetting { get; set; }

        public TransactionBookTable TransactionBookTable { get; set; }
        public TransactionContactUs TransactionContactUs { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
       
     


    }
}
