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
    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IHostingEnvironment Host { get; }

        public MasterSocialMediaController(IRepository<MasterSocialMedia> MasterSocialMedia , IHostingEnvironment _Host)
        {
            this.MasterSocialMedia = MasterSocialMedia;
            Host = _Host;
        }

        // GET: MasterSocialMediaController
        public ActionResult Index()
        {
            IList<MasterSocialMedia> dataList = MasterSocialMedia.View();
            IList<MasterSocialMediaModel> dataViewModelList = new List<MasterSocialMediaModel>();

            foreach (var data in dataList)
            {

                MasterSocialMediaModel dataViewModel = new MasterSocialMediaModel()
                {
                    MasterSocialMediaId = data.MasterSocialMediaId,
                    MasterSocialMediaUrl = data.MasterSocialMediaUrl,
                    MasterSocialMediaImageUrl = data.MasterSocialMediaImageUrl,
                    IsActive = data.IsActive,
                    IsDelete = data.IsDelete
                };

                dataViewModelList.Add(dataViewModel);

            }

            return View(dataViewModelList);
        }


        public ActionResult Active(int id)
        {
            MasterSocialMedia.Active(id, new MasterSocialMedia()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }



        // GET: MasterSocialMediaController/Create
        public ActionResult Create()
        {
            MasterSocialMediaModel dataViewModel = new MasterSocialMediaModel();
            dataViewModel.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(dataViewModel);
        }



        // POST: MasterSocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediaModel dataViewModel)
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

                var obj = new MasterSocialMedia()
                {
                    MasterSocialMediaId = dataViewModel.MasterSocialMediaId,
                    MasterSocialMediaUrl = dataViewModel.MasterSocialMediaUrl,
                    MasterSocialMediaImageUrl = ImageName,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                   
                };

                MasterSocialMedia.Add(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedia.Find(id);

            var obj = new MasterSocialMediaModel()
            {
                MasterSocialMediaId = data.MasterSocialMediaId,
                MasterSocialMediaUrl = data.MasterSocialMediaUrl,
                MasterSocialMediaImageUrl = data.MasterSocialMediaImageUrl,
                CreateUser = data.CreateUser,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),

            };


            return View(obj);
        }

        // POST: MasterSocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediaModel collection)
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

                var obj = new MasterSocialMedia()
                {
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    MasterSocialMediaImageUrl = ImageName ==""? collection.MasterSocialMediaImageUrl : ImageName,
                    CreateDate = DateTime.UtcNow,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                   
                   
                    
                };

                MasterSocialMedia.Update(id, obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterSocialMedia.Delete(id, new MasterSocialMedia()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        //// POST: MasterSocialMediaController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        MasterSocialMedia.Delete(id, entity: new MasterSocialMedia());
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
