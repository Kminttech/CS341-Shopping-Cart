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
        ////////////////////////////////////////////
        // used for testing purposes
        ////////////////////////////////////////////
        public static Item item = new Item()
        {
            Id = 0,
            Name = "Risk",
            Description = "Strategy game for parties",
            ImageLOC = "risk.jpg",
            Price = (decimal)50.0,
            SalePrice = (decimal)30.0
        };

        public static User user = new User()
        {
            Id = 0,
            Username = "Guest",
            IsAdmin = false,
            IsGuest = true,
            Cart = new List<CartEntry>
            {
                { new CartEntry { Id = 0, EntryItem = item, Quantitiy = 1 } }
            }
        };

        public static IndexModel guest = new IndexModel()
        {
            User = user
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

        public static AdminViewModel adminView = new AdminViewModel()
        {
            User = user
        };

        ////////////////////////////////////////////

        public ActionResult Index()
        {
            return View("Index", guest);
        }

        public ActionResult Home()
        {
            return PartialView("Home");
        }

        public ActionResult Admin()
        {
            return PartialView("AdminView", adminView);
        }

        public ActionResult Login(string username, string password)
        {
            User user = new User()
            {
                Username = username,
                Password = password,
                IsAdmin = true,
                IsGuest = false
            };

            IndexModel indexModel = new IndexModel()
            {
                User = user
            };

            return View("Index", indexModel);
        }

        public ActionResult RegisterLogin()
        {
            return View("RegisterLoginView", guest);
        }

        public ActionResult GetResults()
        {
            return PartialView("ResultsView", results);
        }

        public ActionResult GetItem(int id)
        {
            return PartialView("ItemView", itemView);
        }

        public ActionResult GetCart()
        {
            return PartialView("CartView", cart);
        }

        public ActionResult Register()
        {
            return PartialView("RegisterView");
        }

        public ActionResult RegisterUser()
        {
            //Database Stuff
            //return worked or not partial view :)
            return null;

        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
