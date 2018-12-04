using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cs341.Models;
using Microsoft.AspNetCore.Routing;

namespace cs341.Controllers
{
    public class UsersController : Controller
    {
        private readonly CartContext _context;

        public UsersController(CartContext context)
        {
            _context = context;
        }

//////////////////////////////////////////////////////////////
/// Client Calls
//////////////////////////////////////////////////////////////

        /// Login
        public async Task<IActionResult> Login(string username, string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            password = System.Text.Encoding.ASCII.GetString(data);

            User user =  await _context.Users
                .SingleOrDefaultAsync(m => m.Username == username && m.Password == password);
            return user == null
                ? RedirectToAction("Error", "Home", new { error = "Username or Password does not match :(" })
                : RedirectToAction("Login", "Home", user);
        }

        /// Register
        public IActionResult Register([Bind("Id,Username,Password,IsAdmin,IsGuest")] User user)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(user.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            user.Password = System.Text.Encoding.ASCII.GetString(data);

            _context.Add(user);
            _context.SaveChanges();
            return View("RegisterLoginView");
        }

        public IActionResult GuestIndex()
        {
            User guest = new User()
            {
                Username = "Guest",
                IsGuest = true,
                IsAdmin = false
            };
            _context.Add(guest);
            _context.SaveChanges();

            return RedirectToAction("Login", "Home", guest);
        }

        public IActionResult GetAccount(int id)
        {
            var user =  _context.Users.SingleOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View("AccountInfo",user);
        }

        public IActionResult UpdateAccount(int userid, string password, string billingAddress)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == userid);
            if(password != null)
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                user.Password = System.Text.Encoding.ASCII.GetString(data);
            }
            if (password != null)
            {
                user.BillingAddress = billingAddress;
            }
            _context.Update(user);
            _context.SaveChangesAsync();

            return View("EditSuccess");
        }

        //////////////////////////////////////////////////////////////
        /// Admin Interaction
        //////////////////////////////////////////////////////////////

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,IsAdmin,IsGuest,BillingAddress")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,IsAdmin,IsGuest,BillingAddress")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
