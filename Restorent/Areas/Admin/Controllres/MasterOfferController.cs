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
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public IHostingEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer> MasterOffer, IHostingEnvironment _Host)
        {
            this.MasterOffer = MasterOffer;
            Host = _Host;
        }

        // GET: MasterOfferController
        public ActionResult Index()
        {
            IList<MasterOffer> dataList =  MasterOffer.View();
            IList<MasterOfferModel> dataViewModelList = new List<MasterOfferModel>();

            foreach (var data in dataList)
            {

                MasterOfferModel dataViewModel = new MasterOfferModel()
                {
                    MasterOfferId = data.MasterOfferId,
                    MasterOfferTitle = data.MasterOfferTitle,
                    MasterOfferBreef = data.MasterOfferBreef,
                    MasterOfferDesc = data.MasterOfferDesc,
                    MasterOfferImageUrl = data.MasterOfferImageUrl,
                    IsActive = data.IsActive,
                    IsDelete = data.IsDelete
                };

                dataViewModelList.Add(dataViewModel);

            }
            return View(dataViewModelList);
        }



        public ActionResult Active(int id)
        {
            MasterOffer.Active(id, new MasterOffer()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
                
            });
            return RedirectToAction(nameof(Index));
        }





        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            MasterOfferModel dataViewModel = new MasterOfferModel();
            dataViewModel.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(dataViewModel);
        }




        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel dataViewModel)
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

                var obj = new MasterOffer()
                {
                    MasterOfferId = dataViewModel.MasterOfferId,
                    MasterOfferTitle = dataViewModel.MasterOfferTitle,
                    MasterOfferBreef = dataViewModel.MasterOfferBreef,
                    MasterOfferDesc = dataViewModel .MasterOfferDesc,
                    MasterOfferImageUrl = ImageName,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };

                MasterOffer.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {

            var data = MasterOffer.Find(id);

            var obj = new MasterOfferModel()
            {
                MasterOfferId = data.MasterOfferId,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferBreef = data.MasterOfferBreef,
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferImageUrl = data.MasterOfferImageUrl,
                CreateUser = data.CreateUser,
                //IsActive= data.IsActive,    
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };

            return View(obj);
        }





        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferModel collection)
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

                var obj = new MasterOffer()
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferImageUrl = ImageName == "" ? collection.MasterOfferImageUrl : ImageName,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive,
                    
                   
                   
                };

                MasterOffer.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterOffer.Delete(id, new MasterOffer()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
        });
            return RedirectToAction(nameof(Index));
        }

        //// POST: MasterOfferController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        MasterOffer.Delete(id, entity: new MasterOffer());
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
