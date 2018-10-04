using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cs341.Models;
using cs341.Structures; // remove once database comes in

namespace cs341.Controllers
{
    public class HomeController : Controller
    {
        ////////////////////////////////////////////
        // used for testing purposes
        ////////////////////////////////////////////
        public static Item item = new Item()
        {
            Id = 0,
            Name = "Risk",
            Description = "Strategy game for parties",
            Price = (decimal)50.0,
            SalePrice = (decimal)30.0
        };

        public static User user = new User()
        {
            Id = 0,
            Username = "admin",
            IsAdmin = true,
            IsGuest = false,
            Cart = new Dictionary<Item, int>()
            {
                {item, 1}
            }
        };

        public static CartViewModel cart = new CartViewModel()
        {
            User = user
        };

        public static ItemViewModel itemView = new ItemViewModel()
        {
            Item = item,
            User = user
        };

        public static ResultsViewModel results = new ResultsViewModel()
        {
            Items = new List<Item>()
            {
                {item}
            },
            User = user
        };

        ////////////////////////////////////////////

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetResults()
        {
            return PartialView("ResultsView", results);
        }

        public ActionResult GetResult()
        {
            return PartialView("ItemView", itemView);
        }

        public ActionResult GetCart()
        {
            return PartialView("CartView", cart);
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
