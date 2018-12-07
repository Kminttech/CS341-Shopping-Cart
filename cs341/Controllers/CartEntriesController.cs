using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cs341.Models;

namespace cs341.Controllers
{
    public class CartEntriesController : Controller
    {
        private readonly CartContext _context;

        public CartEntriesController(CartContext context)
        {
            _context = context;
        }

//////////////////////////////////////////////////////////////
/// Client Calls
//////////////////////////////////////////////////////////////

        public void AddEntry([Bind("Id,EntryItemId,UserId,Quantity")] CartEntry cartEntry)
        {
            if (cartEntry != null)
            {
                var dupEntry = _context.CartEntries.SingleOrDefault(e =>
                    (e.UserId == cartEntry.UserId && e.EntryItemId == cartEntry.EntryItemId));
                if (dupEntry == null)
                {
                    _context.Add(cartEntry);
                    _context.SaveChanges();
                }
            }
        }

        public ActionResult DeleteEntry(int cartId, int userId)
        {
            var cartEntry = _context.CartEntries.SingleOrDefault(m => m.Id == cartId);
            _context.CartEntries.Remove(cartEntry);
            _context.SaveChanges();
            return GetCart(userId, null);
        }

        public ActionResult EditEntry(int cartId, int quantity, int userId)
        {
            var cartEntry = _context.CartEntries.SingleOrDefault(m => m.Id == cartId);
            cartEntry.Quantity = quantity;
            _context.CartEntries.Update(cartEntry);
            _context.SaveChanges();
            return GetCart(userId, null);
        }

        public ActionResult GetCart(int id, decimal? discount)
        {
            List<CartEntry> entries = _context.CartEntries.Where(entry => entry.UserId == id && entry.OrderId == null).ToList();
            List <Item> items = new List<Item>();
            entries.ForEach(entry => items.Add(_context.Items.SingleOrDefault(item => item.Id == entry.EntryItemId)));
            CartViewModel cartView = new CartViewModel()
            {
                Entries = entries,
                Items = items,
            };
            if (discount != null)
                cartView.Discount = (decimal)discount;

            return View("CartView", cartView);
        }

        public ActionResult SubmitOrder(int id)
        {
            List<CartEntry> entries = _context.CartEntries.Where(entry => entry.UserId == id && entry.OrderId == null).ToList();

            // add orderNumber to CartEntries
            string orderNumber = System.Guid.NewGuid().ToString("D");
            foreach (CartEntry entry in entries)
            {
                entry.OrderId = orderNumber;
                _context.CartEntries.Update(entry);
            }
            _context.SaveChanges();
            return View("OrderConfirmed");
        }

        public ActionResult GetOrders(int id)
        {
            Dictionary<string, List<CartEntry>> orders2 = new Dictionary<string, List<CartEntry>>();
            List<CartEntry> orders = _context.CartEntries.Where(entry => entry.UserId == id && entry.OrderId != null).ToList();
            foreach(CartEntry entry in orders)
            {
                if (!orders2.ContainsKey(entry.OrderId))
                {
                    orders2.Add(entry.OrderId,new List<CartEntry>());
                    orders2.SingleOrDefault(order => order.Key == entry.OrderId);
                }
                orders2.SingleOrDefault(order => order.Key == entry.OrderId);
            }

            OrdersModel ordersModel = new OrdersModel()
            {
                Orders = orders2
            };

            return View("OrdersView", ordersModel);
        }



        //////////////////////////////////////////////////////////////
        /// Admin Interaction
        //////////////////////////////////////////////////////////////

        // GET: CartEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.CartEntries.ToListAsync());
        }

        // GET: CartEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartEntry = await _context.CartEntries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cartEntry == null)
            {
                return NotFound();
            }

            return View(cartEntry);
        }

        // GET: CartEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntryItemId,UserId,Quantity")] CartEntry cartEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartEntry);
        }

        // GET: CartEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartEntry = await _context.CartEntries.SingleOrDefaultAsync(m => m.Id == id);
            if (cartEntry == null)
            {
                return NotFound();
            }
            return View(cartEntry);
        }

        // POST: CartEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntryItemId,UserId,Quantity")] CartEntry cartEntry)
        {
            if (id != cartEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartEntryExists(cartEntry.Id))
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
            return View(cartEntry);
        }

        // GET: CartEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartEntry = await _context.CartEntries
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cartEntry == null)
            {
                return NotFound();
            }

            return View(cartEntry);
        }

        // POST: CartEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartEntry = await _context.CartEntries.SingleOrDefaultAsync(m => m.Id == id);
            _context.CartEntries.Remove(cartEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartEntryExists(int id)
        {
            return _context.CartEntries.Any(e => e.Id == id);
        }
    }
}
