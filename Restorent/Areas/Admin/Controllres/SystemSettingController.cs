using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restorent.Areas.Admin.ViewModels;
using Restorent.Models;
using Restorent.Models.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Restorent.Areas.Admin.Controllres
{
    [Area("Admin")]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> SystemSetting , IHostingEnvironment _Host)
        {
            this.SystemSetting = SystemSetting;
            Host = _Host;
        }

        // GET: SystemSettingController
        public ActionResult Index()
        {
            IList<SystemSetting> dataList = SystemSetting.View();
            IList<SystemSettingModel> dataViewModelList = new List<SystemSettingModel>();

            foreach (var data in dataList)
            {

                SystemSettingModel dataViewModel = new SystemSettingModel()
                {
                    SystemSettingId = data.SystemSettingId,
                    SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                    SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingCopyright = data.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                    IsActive = data.IsActive,
                    IsDelete = data.IsDelete
                };

                dataViewModelList.Add(dataViewModel);

            }
            return View(dataViewModelList);
        }


        public ActionResult Active(int id)
        {
            SystemSetting.Active(id, new SystemSetting()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = true,
                IsDelete = false

            });
            return RedirectToAction(nameof(Index));
        }                             



        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            SystemSettingModel dataViewModel = new SystemSettingModel();
            dataViewModel.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(dataViewModel);
           
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingModel dataViewModel)
        {
            try
            {
                string ImageName1 = "";
                string ImageName2 = "";
                string ImageName3 = "";


                if (dataViewModel.ImagUrl1 != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Admin/assets/img");
                    FileInfo fn = new FileInfo(dataViewModel.ImagUrl1.FileName);
                    ImageName1 = "img1" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName1);
                    dataViewModel.ImagUrl1.CopyTo(new FileStream(FullPath, FileMode.Create));
                }



                if (dataViewModel.ImagUrl2 != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Admin/assets/img");
                    FileInfo fn = new FileInfo(dataViewModel.ImagUrl2.FileName);
                    ImageName2 = "img2" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName2);
                    dataViewModel.ImagUrl2.CopyTo(new FileStream(FullPath, FileMode.Create));
                }


                if (dataViewModel.ImagUrl3 != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Admin/assets/img");
                    FileInfo fn = new FileInfo(dataViewModel.ImagUrl3.FileName);
                    ImageName3 = "img3" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName3);
                    dataViewModel.ImagUrl3.CopyTo(new FileStream(FullPath, FileMode.Create));
                }

                var obj = new SystemSetting()
                {
                    SystemSettingId = dataViewModel.SystemSettingId,
                    SystemSettingLogoImageUrl = ImageName1,
                    SystemSettingLogoImageUrl2 = ImageName2,
                    SystemSettingWelcomeNoteImageUrl = ImageName3,
                    SystemSettingCopyright = dataViewModel.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = dataViewModel.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = dataViewModel.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = dataViewModel.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = dataViewModel.SystemSettingWelcomeNoteUrl,
                    SystemSettingMapLocation = dataViewModel.SystemSettingMapLocation,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false,
                    
                    

                };

                SystemSetting.Add(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);
            var obj = new SystemSettingModel()
            {
                SystemSettingId = data.SystemSettingId,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                CreateUser = data.CreateUser,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };

            return View(obj);
        }




        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingModel collection)
        {
            try
            {
                
                string ImageName1 = "";
                string ImageName2 = "";
                string ImageName3 = "";

                if (collection.ImagUrl1 != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Admin/assets/img");
                    FileInfo fn = new FileInfo(collection.ImagUrl1.FileName);
                    ImageName1 = "img1" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName1);
                    collection.ImagUrl1.CopyTo(new FileStream(FullPath, FileMode.Create));
                }

                if (collection.ImagUrl2 != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Admin/assets/img");
                    FileInfo fn = new FileInfo(collection.ImagUrl2.FileName);
                    ImageName2 = "img2" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName2);
                    collection.ImagUrl2.CopyTo(new FileStream(FullPath, FileMode.Create));
                }




                if (collection.ImagUrl3 != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Admin/assets/img");
                    FileInfo fn = new FileInfo(collection.ImagUrl3.FileName);
                    ImageName3 = "img3" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName3);
                    collection.ImagUrl3.CopyTo(new FileStream(FullPath, FileMode.Create));
                }




                var obj = new SystemSetting()
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = ImageName1 == "" ? collection.SystemSettingLogoImageUrl : ImageName1,
                    SystemSettingLogoImageUrl2 = ImageName2 == "" ? collection.SystemSettingLogoImageUrl2 : ImageName2,
                    SystemSettingWelcomeNoteImageUrl = ImageName3 == "" ? collection.SystemSettingWelcomeNoteImageUrl : ImageName3,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                   

                };

                SystemSetting.Update(id, obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int id)
        {
            SystemSetting.Delete(id, new SystemSetting()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            });
            return RedirectToAction(nameof(Index));
        }

        //// POST: SystemSettingController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
