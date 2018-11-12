﻿using System;
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
        public async Task<IActionResult> Create([Bind("Id,quantitiy")] CartEntry cartEntry)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,quantitiy")] CartEntry cartEntry)
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
