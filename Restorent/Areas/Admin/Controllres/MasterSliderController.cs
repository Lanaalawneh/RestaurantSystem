 using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Restorent.Areas.Admin.ViewModels;
using Restorent.Models;
using Restorent.Models.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restorent.Areas.Admin.Controllres
{
    [Area("Admin")]

    public class MasterSliderController : Controller
    { 
        public IRepository<MasterSlider> MasterSlider { get; }
        public IHostingEnvironment Host { get; }

        public MasterSliderController(IRepository<MasterSlider> MasterSlider , IHostingEnvironment _Host)
        {
            this.MasterSlider = MasterSlider;
            Host = _Host;
        }



        // GET: MasterSliderController
        public ActionResult Index()
        {

            //IList<MasterSlider> dataList = MasterSlider.View();
            //IList<MasterSocialMediaModel> dataViewModelList = new List<MasterSocialMediaModel>();

            //foreach (var data in dataList)
            //{

            //    MasterSocialMediaModel dataViewModel = new MasterSocialMediaModel()
            //    {
            //        MasterSocialMediaId = data.MasterSocialMediaId,
            //        MasterSocialMediaUrl = data.MasterSocialMediaUrl,
            //        MasterSocialMediaImageUrl = data.MasterSocialMediaImageUrl,
            //        IsActive = data.IsActive,
            //        IsDelete = data.IsDelete
            //    };

            //    dataViewModelList.Add(dataViewModel);

            //}
            return View(MasterSlider.View());
        }

        public ActionResult Active(int id)
        {
            MasterSlider.Active(id, new MasterSlider()  
            {
                EditDate = DateTime.UtcNow,
                EditUser =  User.FindFirstValue(ClaimTypes.NameIdentifier),
             
            });
            return RedirectToAction(nameof(Index));
        }






        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            MasterSliderModel dataViewModel = new MasterSliderModel();
            dataViewModel.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(dataViewModel);
        }


        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderModel dataViewModel)
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


                var obj = new MasterSlider()
                {
                    MasterSliderId = dataViewModel.MasterSliderId,
                    MasterSliderTitle = dataViewModel.MasterSliderTitle,
                    MasterSliderBreef = dataViewModel.MasterSliderBreef,
                    MasterSliderDesc = dataViewModel.MasterSliderDesc,
                    MasterSliderUrl = ImageName,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };


                MasterSlider.Add(obj);   

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSlider.Find(id);

            var obj = new MasterSliderModel()
            {
                MasterSliderId = data.MasterSliderId,
                MasterSliderBreef = data.MasterSliderBreef,
                MasterSliderDesc = data.MasterSliderDesc,
                MasterSliderTitle = data.MasterSliderTitle,
                MasterSliderUrl = data.MasterSliderUrl,
                CreateUser = data.CreateUser,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),

            };

            return View(obj);
        }



        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderModel collection)
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

                var obj = new MasterSlider()
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderUrl = ImageName == "" ? collection.MasterSliderUrl : ImageName,
                    CreateDate = DateTime.UtcNow,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    
                };

                
                MasterSlider.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: MasterSliderController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterSlider.Delete(id, new MasterSlider()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }

        //// POST: MasterSliderController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        MasterSlider.Delete(id, entity: new MasterSlider());
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
