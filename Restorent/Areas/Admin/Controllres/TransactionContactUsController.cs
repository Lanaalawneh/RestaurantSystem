using Microsoft.AspNetCore.Mvc;
using Restorent.Models;
using Restorent.Models.Repositories;

namespace Restorent.Areas.Admin.Controllres
{
    [Area("Admin")]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> TransactionContactUs { get; }


        public TransactionContactUsController(IRepository<TransactionContactUs> TransactionContactUs)
        {
            this.TransactionContactUs = TransactionContactUs;
        }

      

        public IActionResult Index()
        {
            return View(TransactionContactUs.View());
        }
    }
}
