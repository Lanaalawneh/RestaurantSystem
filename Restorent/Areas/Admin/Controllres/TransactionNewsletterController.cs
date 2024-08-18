using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restorent.Models;
using Restorent.Models.Repositories;

namespace Restorent.Areas.Admin.Controllres
{
    [Area("Admin")]
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> TransactionNewsletter)
        {
            this.TransactionNewsletter = TransactionNewsletter;
        }


        // GET: TransactionNewsletterController
        public ActionResult Index()
        {
            return View(TransactionNewsletter.View());
        }

        // GET: TransactionNewsletterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionNewsletterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionNewsletterController/Create
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

        // GET: TransactionNewsletterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionNewsletterController/Edit/5
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

        // GET: TransactionNewsletterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionNewsletterController/Delete/5
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
