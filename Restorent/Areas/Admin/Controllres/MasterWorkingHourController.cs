using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Restorent.Areas.Admin.ViewModels;
using Restorent.Models;
using Restorent.Models.Repositories;

namespace Restorent.Areas.Admin.Controllres
{
    [Area("Admin")]
    [Authorize]
    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> MasterWorkingHour)
        {
            this.MasterWorkingHour = MasterWorkingHour;
        }


        // GET: MasterWorkingHourController
        public ActionResult Index()
        {
            IList<MasterWorkingHour> dataList = MasterWorkingHour.View();
            IList<MasterWorkingHourModel> dataViewModelList = new List<MasterWorkingHourModel>();

            foreach (var data in dataList)
            {

                MasterWorkingHourModel dataViewModel = new MasterWorkingHourModel()
                {
                    MasterWorkingHourId = data.MasterWorkingHourId,
                    MasterWorkingHourIdName = data.MasterWorkingHourIdName,
                    MasterWorkingHourIdTimeFormTo = data.MasterWorkingHourIdTimeFormTo,
                    IsActive = data.IsActive,
                    IsDelete = data.IsDelete
                };

                dataViewModelList.Add(dataViewModel);

            }

            return View(dataViewModelList);
        }

        public ActionResult Active(int id)
        {
            MasterWorkingHour.Active(id, new MasterWorkingHour()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });

            return RedirectToAction(nameof(Index));
        }



        // GET: MasterWorkingHourController/Create
        public ActionResult Create()
        {
            MasterWorkingHourModel dataViewModel = new MasterWorkingHourModel();
            dataViewModel.CreateUser =User.FindFirstValue(ClaimTypes.NameIdentifier);
            dataViewModel.EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(dataViewModel);
        }

        // POST: MasterWorkingHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHourModel dataViewModel)
        {
            try
            {

                var obj = new MasterWorkingHour()
                {
                    MasterWorkingHourId = dataViewModel.MasterWorkingHourId,
                    MasterWorkingHourIdName = dataViewModel.MasterWorkingHourIdName,
                    MasterWorkingHourIdTimeFormTo = dataViewModel.MasterWorkingHourIdTimeFormTo,
                    CreateDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false,
                };
               

                MasterWorkingHour.Add(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterWorkingHour.Find(id);

            var obj = new MasterWorkingHourModel()
            {
                MasterWorkingHourId = data.MasterWorkingHourId,
                MasterWorkingHourIdName = data.MasterWorkingHourIdName,
                MasterWorkingHourIdTimeFormTo = data.MasterWorkingHourIdTimeFormTo,
                CreateUser = data.CreateUser,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };

            return View(obj);
        }

        // POST: MasterWorkingHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHourModel dataViewModel)
        {
            try
            {


                var obj = new MasterWorkingHour()
                {
                    MasterWorkingHourId = dataViewModel.MasterWorkingHourId,
                    MasterWorkingHourIdName = dataViewModel.MasterWorkingHourIdName,
                    MasterWorkingHourIdTimeFormTo = dataViewModel.MasterWorkingHourIdTimeFormTo,
                    EditDate = DateTime.UtcNow,
                    CreateUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false


                };

                MasterWorkingHour.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Delete/5
        public ActionResult Delete(int id)
        {
            MasterWorkingHour.Delete(id, new MasterWorkingHour()
            {
                EditDate = DateTime.UtcNow,
                EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            return RedirectToAction(nameof(Index));
            
        }

        // POST: MasterWorkingHourController/Delete/5 ,  User.FindFirstValue(ClaimTypes.NameIdentifier)
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterWorkingHour collection)
        //{
        //    try
        //    {



        //        MasterWorkingHour.Delete(id, new MasterWorkingHour()
        //        {
        //            EditDate = DateTime.UtcNow,
        //            EditUser = User.FindFirstValue(ClaimTypes.NameIdentifier)
        //        });
        //        return RedirectToAction(nameof(Index));



        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
