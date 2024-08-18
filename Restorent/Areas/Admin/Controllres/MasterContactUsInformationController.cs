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
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IHostingEnvironment Host { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> MasterContactUsInformation ,
           IHostingEnvironment _Host)


        {
            this.MasterContactUsInformation = MasterContactUsInformation;
            Host = _Host;
        }



        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {
           
            return View(MasterContactUsInformation.View());
        }



        public ActionResult Active(int id)
        {
            MasterContactUsInformation.Active(id, new MasterContactUsInformation()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
               
               
            });
            return RedirectToAction(nameof(Index));
        }



        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            //MasterContactUsInformationModel dataViewModel = new MasterContactUsInformationModel();
            //dataViewModel.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //return View(dataViewModel);
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformationModel dataViewModel)
        {
            try
            {
                string ImageName = "";


                if (dataViewModel.FIle != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Admin/assets/img");
                    FileInfo fn = new FileInfo(dataViewModel.FIle.FileName);
                    ImageName = "img" + Guid.NewGuid() + fn.Extension;
                    string FullPath = Path.Combine(Imagepath, ImageName);
                    dataViewModel.FIle.CopyTo(new FileStream(FullPath, FileMode.Create));
                }

                var obj = new MasterContactUsInformation()
                {
                    MasterContactUsInformationId = dataViewModel.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = dataViewModel.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = dataViewModel.MasterContactUsInformationRedirect,
                    MasterContactUsInformationImageUrl = ImageName,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                  

                };

                MasterContactUsInformation.Add(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterContactUsInformation.Find(id);

            var obj = new MasterContactUsInformationModel()
            {
                MasterContactUsInformationId = data.MasterContactUsInformationId,
                MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
                MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl,
                //CreateUser = data.CreateUser,
                //EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                //IsActive = data.IsActive,
               
            };

            return View(obj);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformationModel collection)
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

                var obj = new MasterContactUsInformation()
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    MasterContactUsInformationImageUrl = ImageName == "" ? collection.MasterContactUsInformationImageUrl : ImageName,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = MasterContactUsInformation.Find(collection.MasterContactUsInformationId).IsActive,
                    
                  
                };

                MasterContactUsInformation.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
         
        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterContactUsInformation.Delete(id, new MasterContactUsInformation()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        //// POST: MasterContactUsInformationController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        MasterContactUsInformation.Delete(id, entity: new Models.MasterContactUsInformation());
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
