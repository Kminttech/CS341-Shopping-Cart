using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cs341.Models;

namespace cs341.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetResults()
        {
            return PartialView("ResultsView", new ResultsViewModel());
        }

        public ActionResult GetResult()
        {
            return PartialView("ItemView", new ItemViewModel());
        }

        public ActionResult GetCart()
        {
            return PartialView("CartView", new CartViewModel());
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
