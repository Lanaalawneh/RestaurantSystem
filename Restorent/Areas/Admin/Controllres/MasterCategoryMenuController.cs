using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restorent.Models;
using Restorent.Models.Repositories;

namespace Restorent.Areas.Admin.Controllres
{
    [Area("Admin")]
    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> MasterCategoryMenu)
        {
            this.MasterCategoryMenu = MasterCategoryMenu;
        }

        // GET: MasterCategoryMenuController
        public ActionResult Index()
        {
            return View(MasterCategoryMenu.View());
        }


        public ActionResult Active(int id)
        {
            MasterCategoryMenu.Active(id, new MasterCategoryMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),



            });

            return RedirectToAction(nameof(Index));
        }




        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            MasterCategoryMenu obj = new MasterCategoryMenu();
            obj.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);


            return View(obj);
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {
                collection.CreateDate = DateTime.UtcNow;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.IsActive = true;
                collection.IsDelete = false;


                MasterCategoryMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterCategoryMenu.Find(id);

            var obj = new MasterCategoryMenu()
            {
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterCategoryMenuName = data.MasterCategoryMenuName,  
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                IsActive = data.IsActive
            };

            return View(data);
        }

         

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {
                //collection.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //collection.EditDate = DateTime.UtcNow;
                
                //collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var obj = new MasterCategoryMenu()
                {
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterCategoryMenuName = collection.MasterCategoryMenuName,
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = collection.IsActive
                };

                MasterCategoryMenu.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterCategoryMenu.Delete(id, new MasterCategoryMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
        }



       
    }
}
