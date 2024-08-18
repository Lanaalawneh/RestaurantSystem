using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restorent.Models;
using Restorent.Models.Repositories;

namespace Restorent.Areas.Admin.Controllres
{
    [Authorize]
    [Area("Admin")]
   
    public class MasterMenuController : Controller
    {

        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenuController(IRepository<MasterMenu> MasterMenu)
        {
            this.MasterMenu = MasterMenu;
        }


        public IActionResult Index()
        {
            return View(MasterMenu.View());
        }

        public ActionResult Active(int id)
        {
            MasterMenu.Active(id, new MasterMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            });

            return RedirectToAction(nameof(Index));
        }


        // GET: Controller/Create
        public ActionResult Create()
        {
            MasterMenu obj = new MasterMenu();
            obj.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(obj);
        }




        // POST: qqqqController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenu collection)
        {
            try
            {
                collection.CreateDate = DateTime.UtcNow;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                MasterMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            var data = MasterMenu.Find(id);
            var obj = new MasterMenu()
            {
                MasterMenuId = data.MasterMenuId,
                MasterMenuName = data.MasterMenuName,
                MasterMenuUrl = data.MasterMenuUrl,
                CreateUser = data.CreateUser,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };

            return View(obj);
        }

        // POST: controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenu collection)
        {
            try
            {
                //collection.CreateDate = DateTime.UtcNow;
                collection.EditDate = DateTime.UtcNow;
                collection.CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                collection.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier); 
                MasterMenu.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            MasterMenu.Delete(id, new MasterMenu()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            });

            return RedirectToAction(nameof(Index));
        }

      
    }
}

