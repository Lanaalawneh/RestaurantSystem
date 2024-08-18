using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restorent.Areas.Admin.ViewModels;
using Restorent.Models;
using Restorent.Models.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restorent.Areas.Admin.Controllres
{
    [Area("Admin")]
    [Authorize]
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> MasterPartner , IHostingEnvironment _Host) 
        {
            this.MasterPartner = MasterPartner;
            Host = _Host;
        }


        // GET: MasterPartnerController
        public ActionResult Index()
        {
            IList<MasterPartner> dataList = MasterPartner.View();
            IList<MasterPartnerModel> dataViewModelList = new List<MasterPartnerModel>();
            foreach (var data in dataList)
            {
                MasterPartnerModel dataViewModel = new MasterPartnerModel()
                {
                    MasterPartnerId = data.MasterPartnerId,
                    MasterPartnerName = data.MasterPartnerName,
                    MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                    MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
                    IsActive = data.IsActive
                };

                dataViewModelList.Add(dataViewModel);
            }

            return View(dataViewModelList);
        }





        public ActionResult Active(int id)
        {
            MasterPartner.Active(id, new MasterPartner()
            {
              EditDate = DateTime.UtcNow,
              EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)

            });
            return RedirectToAction(nameof(Index));
        }




        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            MasterPartnerModel dataViewModel = new MasterPartnerModel();

            dataViewModel.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(dataViewModel);
        }



        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel dataViewModel)
        {
            try
            {
                
                string ImageName = "";


                if (dataViewModel.FIle != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath,"Admin/assets/img");
                    FileInfo fn = new FileInfo(dataViewModel.FIle.FileName);
                    ImageName = "img" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName);
                    dataViewModel.FIle.CopyTo(new FileStream(FullPath, FileMode.Create));


                }
                
           

                var obj = new MasterPartner()
                {
                    MasterPartnerId = dataViewModel.MasterPartnerId,
                    MasterPartnerName = dataViewModel.MasterPartnerName, 
                    MasterPartnerWebsiteUrl = dataViewModel.MasterPartnerWebsiteUrl,
                    MasterPartnerLogoImageUrl = ImageName ,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser =  User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                   
                };


                MasterPartner.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartner.Find(id);

            var obj = new MasterPartnerModel()
            {
                MasterPartnerId = data.MasterPartnerId,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                CreateUser = data.CreateUser,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),

            };
            return View(obj);
        }



        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {
            try
            {

                string ImageName = "";


                if (collection.FIle != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Admin/assets/img");
                    FileInfo fn = new FileInfo(collection.FIle.FileName);
                    ImageName = "img" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName);
                    collection.FIle.CopyTo(new FileStream(FullPath, FileMode.Create));


                }

                
                var obj = new MasterPartner()
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    MasterPartnerLogoImageUrl = ImageName == "" ? collection.MasterPartnerLogoImageUrl : ImageName,
                    CreateDate = DateTime.UtcNow,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                  

                    

                };

                MasterPartner.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int id)
        {

            MasterPartner.Delete(id, new MasterPartner()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            });
            return RedirectToAction(nameof(Index));

          
        }

        //// POST: MasterPartnerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        MasterPartner.Delete(id, entity: new MasterPartner());
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
