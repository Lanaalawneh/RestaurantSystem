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
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }
        public IHostingEnvironment Host { get; }

        public MasterServiceController(IRepository<MasterService> MasterService , IHostingEnvironment _Host)
        {
            this.MasterService = MasterService;
            Host = _Host;
        }



        // GET: MasterServiceController
        public ActionResult Index()
        {
            IList<MasterService> dataList = MasterService.View();
            IList<MasterServiceModel> dataViewModelList = new List<MasterServiceModel> ();

            foreach (var data in dataList)
            {

                MasterServiceModel dataViewModel = new MasterServiceModel()
                {
                    MasterServiceId = data.MasterServiceId,
                    MasterServiceTitle = data.MasterServiceTitle,
                    MasterServiceDesc = data.MasterServiceDesc,
                    MasterServiceImage = data.MasterServiceImage,
                    IsActive = data.IsActive,
                    IsDelete = data.IsDelete

                };

                dataViewModelList.Add(dataViewModel);

            }

            return View(dataViewModelList);
        }


        public ActionResult Active(int id)
        {
            MasterService.Active(id, new MasterService()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }



        // GET: MasterServiceController/Create
        public ActionResult Create()
        {
            MasterServiceModel dataViewModel = new MasterServiceModel();
            dataViewModel.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(dataViewModel);
        }



        // POST: MasterServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServiceModel dataViewModel)
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

                var obj = new MasterService()
                {
                    MasterServiceId = dataViewModel.MasterServiceId,
                    MasterServiceTitle = dataViewModel.MasterServiceTitle,
                    MasterServiceDesc = dataViewModel.MasterServiceDesc,
                    MasterServiceImage = ImageName ,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                   
                };

                MasterService.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: MasterServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterService.Find(id);

            var obj = new MasterServiceModel()
            {
                MasterServiceId = data.MasterServiceId,
                MasterServiceTitle = data.MasterServiceTitle,
                MasterServiceDesc = data.MasterServiceDesc,
                MasterServiceImage = data.MasterServiceImage,
                IsActive = data.IsActive,
                CreateUser = data.CreateUser,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };

            return View(obj);
        }

        // POST: MasterServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServiceModel collection)
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

                var obj = new MasterService()
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServiceTitle = collection.MasterServiceTitle,
                    MasterServiceDesc = collection.MasterServiceDesc,
                    MasterServiceImage = ImageName == "" ? collection.MasterServiceImage : ImageName,
                    CreateDate = DateTime.UtcNow,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive
                   


                };

                MasterService.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: MasterServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterService.Delete(id, new MasterService()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            });
            return RedirectToAction(nameof(Index));
        }

        //// POST: MasterServiceController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        MasterService.Delete(id, entity: new MasterService());
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
