using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Restorent.Areas.Admin.ViewModels;
using Restorent.Models;
using Restorent.Models.Repositories;
using Restorent.ViewsModel;

namespace Restorent.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterService> MasterService { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public IRepository<TransactionContactUs> TransactionContactUs { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }



        public HomeController(
             IRepository<MasterCategoryMenu> _MasterCategoryMenu,
             IRepository<TransactionContactUs> _TransactionContactUs,
             IRepository<MasterItemMenu> _MasterItemMenu,
             IRepository<MasterMenu> _MasterMenu,
             IRepository<MasterOffer> _MasterOffer,
             IRepository<MasterPartner> _MasterPartner,
             IRepository<MasterService> _MasterService,
             IRepository<MasterSlider> _MasterSlider,
             IRepository<MasterSocialMedia> _MasterSocialMedia,
             IRepository<MasterWorkingHour> MasterWorkingHour,
             IRepository<SystemSetting> _SystemSetting,
             IRepository<TransactionBookTable> _TransactionBookTable,
             IRepository<TransactionNewsletter> _TransactionNewsletter,
             IRepository<MasterContactUsInformation> _MasterContactUsInformation)
        {
            MasterCategoryMenu = _MasterCategoryMenu;
            MasterContactUsInformation = _MasterContactUsInformation;
            MasterItemMenu = _MasterItemMenu;
            MasterMenu = _MasterMenu;
            MasterOffer = _MasterOffer;
            MasterPartner = _MasterPartner;
            MasterService = _MasterService;
            MasterSlider = _MasterSlider;
            MasterSocialMedia = _MasterSocialMedia;
            this.MasterWorkingHour = MasterWorkingHour;
            SystemSetting = _SystemSetting;
            TransactionBookTable = _TransactionBookTable;
            TransactionContactUs = _TransactionContactUs;
            TransactionNewsletter = _TransactionNewsletter;    
            
        }





        /// Home Page 

        public IActionResult Index()
        {
            var data = new HomeModel();

            // Header
            data.ListMasterMenu = MasterMenu.ViewFormClient().ToList();


            // Body 
            data.ListMasterSlider = MasterSlider.ViewFormClient().ToList();
            data.SystemSetting = SystemSetting.ViewFormClient().Where(x => x.SystemSettingId == 1).SingleOrDefault();
            data.ListMasterItemMenu = MasterItemMenu.ViewFormClient().OrderByDescending(x => x.MasterItemMenuId).Take(5).ToList();
            //Also The TransAction BookTable Have Another Action 
            data.MasterOffer = MasterOffer.ViewFormClient().Where(x => x.MasterOfferId == 1008).SingleOrDefault();
            data.ListMasterPartner = MasterPartner.ViewFormClient().ToList();

            // Footer 
            data.ListMasterSocialMedia = MasterSocialMedia.ViewFormClient().ToList();
            data.ListMasterContactUsInformation = MasterContactUsInformation.ViewFormClient().ToList();
            data.ListMasterWorkingHour = MasterWorkingHour.ViewFormClient().ToList();
            //Also The Trans Action News Letter Have Another Action 

            return View(data);
        }





        // About Page

        public IActionResult About()
        {
            var data = new HomeModel();

            // Header
            data.ListMasterMenu = MasterMenu.ViewFormClient().ToList();

            // Body 
            data.SystemSetting = SystemSetting.ViewFormClient().Where(x => x.SystemSettingId == 1).SingleOrDefault();
            data.ListMasterService = MasterService.ViewFormClient().ToList();


            // Footer 
            data.ListMasterSocialMedia = MasterSocialMedia.ViewFormClient().ToList();
            data.ListMasterContactUsInformation = MasterContactUsInformation.ViewFormClient().ToList();
            data.ListMasterWorkingHour = MasterWorkingHour.ViewFormClient().ToList();

            return View(data);
        }






        // Menu Page 
        public IActionResult Menu()
        {
            var data = new HomeModel();

            // Header
            data.ListMasterMenu = MasterMenu.ViewFormClient().ToList();
            data.SystemSetting = SystemSetting.ViewFormClient().Where(x => x.SystemSettingId == 1).SingleOrDefault();


            // Body 
            data.ListMasterItemMenu = MasterItemMenu.ViewFormClient().ToList();
            data.ListMasterCategoryMenu = MasterCategoryMenu.ViewFormClient().ToList();
            data.ListMasterPartner = MasterPartner.ViewFormClient().ToList();


            // Footer 
            data.ListMasterSocialMedia = MasterSocialMedia.ViewFormClient().ToList();
            data.ListMasterContactUsInformation = MasterContactUsInformation.ViewFormClient().ToList();
            data.ListMasterWorkingHour = MasterWorkingHour.ViewFormClient().ToList();

            return View(data);
        }







        // Contact US Page
        public IActionResult ContactUs()
        {
            var data = new HomeModel();


            // Header
            data.ListMasterMenu = MasterMenu.ViewFormClient().ToList();
            data.SystemSetting = SystemSetting.ViewFormClient().Where(x => x.SystemSettingId == 1).SingleOrDefault();


            //For Body 

            //TransActionContactUs ( LEAVE A MESSAGE ) , CONTACT US FORM , GoogleMap



            // Footer 
            data.ListMasterSocialMedia = MasterSocialMedia.ViewFormClient().ToList();
            data.ListMasterContactUsInformation = MasterContactUsInformation.ViewFormClient().ToList();
            data.ListMasterWorkingHour = MasterWorkingHour.ViewFormClient().ToList();


            return View(data);
        }





        /// For News Letter  (LayOut Footer)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewsletter(HomeModel collection)
        {
            try
            {

                var obj = new TransactionNewsletter()
                {
                    TransactionNewsletterId = collection.TransactionNewsletter.TransactionNewsletterId,
                    TransactionNewsletterEmail = collection.TransactionNewsletter.TransactionNewsletterEmail,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };


                TransactionNewsletter.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }





        /////////For Book Table  ( HOME PAGE )

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBookTable(HomeModel collection)
        {
            try
            {

                var obj = new TransactionBookTable()
                {
                    TransactionBookTableId = collection.TransactionBookTable.TransactionBookTableId,
                    TransactionBookTableFullName = collection.TransactionBookTable.TransactionBookTableFullName,
                    TransactionBookTableEmail = collection.TransactionBookTable.TransactionBookTableEmail,
                    TransactionBookTableMobileNumber = collection.TransactionBookTable.TransactionBookTableMobileNumber,
                    TransactionBookTableDate = collection.TransactionBookTable.TransactionBookTableDate,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };


                TransactionBookTable.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception x)
            {
                return View();
            }
        }







        /////////For TransActionContactUs  ( Leave A Message , CONTACT US PAGE  ) 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTransactionContact(HomeModel collection)
        {
            try
            {

                var obj = new TransactionContactUs ()
                {
                    TransactionContactUsId = collection.TransactionContactUs.TransactionContactUsId,
                    TransactionContactUsFullName = collection.TransactionContactUs.TransactionContactUsFullName,
                    TransactionContactUsEmail = collection.TransactionContactUs.TransactionContactUsEmail,
                    TransactionContactUsSubject = collection.TransactionContactUs.TransactionContactUsSubject,
                    TransactionContactUsMessage = collection.TransactionContactUs.TransactionContactUsMessage,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                 
                TransactionContactUs.Add(obj);
                return RedirectToAction(nameof(ContactUs));
            }
            catch 
            {
                return View();
            }
        }









    }
}
