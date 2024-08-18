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
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IHostingEnvironment Host { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> MasterItemMenu,
             IHostingEnvironment _Host, IRepository<MasterCategoryMenu> MasterCategoryMenu)
        {
            this.MasterItemMenu = MasterItemMenu;
            Host = _Host;
            this.MasterCategoryMenu = MasterCategoryMenu;
        }

        // GET: MasterItemMenuController
        public ActionResult Index()
        {
            IList<MasterItemMenu> dataList = MasterItemMenu.View();
            IList<MasterItemMenuModel> dataViewModelList = new List<MasterItemMenuModel>();

            foreach (var data in dataList)
            {
                MasterItemMenuModel dataViewModel = new MasterItemMenuModel()
                {
                    MasterItemMenuId = data.MasterItemMenuId,
                    MasterCategoryMenuId = data.MasterCategoryMenuId,
                    MasterItemMenuTitle = data.MasterItemMenuTitle,
                    MasterItemMenuBreef = data.MasterItemMenuBreef,
                    MasterItemMenuDesc = data.MasterItemMenuDesc,
                    MasterItemMenuPrice = data.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                    MasterItemMenuDate = data.MasterItemMenuDate,
                    MasterItemMenuTotalPrice = data.MasterItemMenuTotalPrice,
                    MasterCategoryMenu = data.MasterCategoryMenu,
                    IsActive = data.IsActive,
                    IsDelete = data.IsDelete
                };

                dataViewModelList.Add(dataViewModel);
            }
            return View(dataViewModelList);




        }


        public ActionResult Active(int id)
        {
            MasterItemMenu.Active(id, new MasterItemMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });

            return RedirectToAction(nameof(Index));
        }





        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        {
            ViewBag.ListMasterCategoryMenu = MasterCategoryMenu.View();
            MasterItemMenuModel dataViewModel = new MasterItemMenuModel();
            dataViewModel.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(dataViewModel);
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel dataViewModel)
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


                var obj = new MasterItemMenu()
                {
                    MasterItemMenuId = dataViewModel.MasterItemMenuId,
                    MasterCategoryMenuId = dataViewModel.MasterCategoryMenuId,
                    MasterItemMenuTitle = dataViewModel.MasterItemMenuTitle,
                    MasterItemMenuBreef = dataViewModel.MasterItemMenuBreef,
                    MasterItemMenuDesc = dataViewModel.MasterItemMenuDesc,
                    MasterItemMenuTotalPrice = dataViewModel.MasterItemMenuTotalPrice,
                    MasterItemMenuPrice = dataViewModel.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = ImageName,
                    MasterItemMenuDate = dataViewModel.MasterItemMenuDate,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false


                };

                MasterItemMenu.Add(obj);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterItemMenu.Find(id);

            ViewBag.ListMasterCategoryMenu = MasterCategoryMenu.View();

            var obj = new MasterItemMenuModel()
            {
                MasterItemMenuId = data.MasterItemMenuId,
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuBreef = data.MasterItemMenuBreef,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                MasterItemMenuDate = data.MasterItemMenuDate,
                MasterCategoryMenu = data.MasterCategoryMenu,
                MasterItemMenuTotalPrice = data.MasterItemMenuTotalPrice,
                CreateUser = data.CreateUser,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };

            return View(obj);
        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
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


                var obj = new MasterItemMenu()
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterCategoryMenu = collection.MasterCategoryMenu,
                    MasterItemMenuTotalPrice = collection.MasterItemMenuTotalPrice,
                    MasterItemMenuImageUrl = ImageName == "" ? collection.MasterItemMenuImageUrl : ImageName,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    CreateDate = DateTime.UtcNow,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false,


                };

                MasterItemMenu.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterItemMenu.Delete(id, new MasterItemMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            });
            return RedirectToAction(nameof(Index));
        }




        public ActionResult TotalPrice(int id)
        {
            var obj = MasterItemMenu.Find(id);

            return View();
        }





    }
}
