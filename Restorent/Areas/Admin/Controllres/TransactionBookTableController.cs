using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restorent.Models;
using Restorent.Models.Repositories;

namespace Restorent.Areas.Admin.Controllres
{

    [Area("Admin")]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTable { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> TransactionBookTable)
        {
            this.TransactionBookTable = TransactionBookTable;
        }

        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            return View(TransactionBookTable.View());
        }

        // GET: TransactionBookTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionBookTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionBookTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionBookTableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionBookTableController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
