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
    public class PromotionsController : Controller
    {
        private readonly CartContext _context;

        public PromotionsController(CartContext context)
        {
            _context = context;
        }

        //////////////////////////////////////////////////////////////
        /// Client Calls
        //////////////////////////////////////////////////////////////

        public ActionResult GetPromoPage()
        {
            List<Promotion> promotions = _context.Promotions.ToList();
            List<Item> saleItems = _context.Items.Where(item => item.SalePrice != null).ToList();
            PromoPageModel model = new PromoPageModel()
            {
                SaleItems = saleItems,
                Promotions = promotions
            };
            return View("PromoPage", model);
        }

        public ActionResult AddPromotionToCart(string promoCode, int userId)
        {
            Promotion promo = _context.Promotions.SingleOrDefault(m => m.Code == promoCode);
            return promo == null
                ? (ActionResult)Json("<h1>Promo Code doesn't exist!</h1>")
                : RedirectToAction("GetCart", "CartEntries", new { id = userId, discount = promo.PercentOff });
        }

//////////////////////////////////////////////////////////////
/// Admin Interaction
        //////////////////////////////////////////////////////////////

        // GET: Promotions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promotions.ToListAsync());
        }

        // GET: Promotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        // GET: Promotions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,PercentOff,StartDate,EndDate")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promotion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions.SingleOrDefaultAsync(m => m.Id == id);
            if (promotion == null)
            {
                return NotFound();
            }
            return View(promotion);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code,PercentOff,StartDate,EndDate")] Promotion promotion)
        {
            if (id != promotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionExists(promotion.Id))
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
            return View(promotion);
        }

        // GET: Promotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promotion = await _context.Promotions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Promotions.Remove(promotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromotionExists(int id)
        {
            return _context.Promotions.Any(e => e.Id == id);
        }
    }
}
