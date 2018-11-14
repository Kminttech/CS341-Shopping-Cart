using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using cs341.Models;

namespace cs341.Controllers
{
    public class HomeController : Controller
    {

        ////////////////////////////////////////////
        private static readonly User _user = new User()
        {
            Id = -1,
            Username = "Guest",
            IsAdmin = false,
            IsGuest = true,
            Cart = new List<CartEntry>()
        };
        ////////////////////////////////////////////

        public ActionResult Index()
        {
            IndexModel indexView = new IndexModel()
            {
                User = _user
            };
            return View("Index", indexView);
        }

        public ActionResult Home()
        {
            return PartialView("Home");
        }

        public ActionResult Admin()
        {
            AdminViewModel adminView = new AdminViewModel()
            {
                User = _user
            };
            return PartialView("AdminView", adminView);
        }
       
        public ActionResult RegisterLogin()
        {
            IndexModel index = new IndexModel()
            {
                User = _user
            };
            return View("RegisterLoginView", index);
        }

        public ActionResult Login(User user)
        {
            IndexModel indexView = new IndexModel()
            {
                User = user
            };
            return View("Index", indexView);
        }

        public ActionResult Logout()
        {
            IndexModel indexView = new IndexModel()
            {
                User = _user
            };
            return View("Index", indexView);
        }

        public ActionResult Register()
        {
            return PartialView("RegisterView");
        }

        public ActionResult Error(string error)
        {
            return View("Error", new ErrorViewModel { Error = error, User = _user });
        }
    }
}
