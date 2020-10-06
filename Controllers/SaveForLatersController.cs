using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore
{
    public class SaveForLatersController : Controller
    {
        private readonly BookStoreContext _context;

        public SaveForLatersController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: SaveForLaters
        public async Task<IActionResult> Index()
        {
            var bookStoreContext = _context.SaveForLater.Include(s => s.Buyer);
            return View(await bookStoreContext.ToListAsync());
        }

        // GET: SaveForLaters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saveForLater = await _context.SaveForLater
                .Include(s => s.Buyer)
                .FirstOrDefaultAsync(m => m.SaveForLaterID == id);
            if (saveForLater == null)
            {
                return NotFound();
            }

            return View(saveForLater);
        }

        // GET: SaveForLaters/Create
        public IActionResult Create()
        {
            ViewData["BuyerID"] = new SelectList(_context.Buyers, "BuyerID", "BuyerID");
            return View();
        }

        // POST: SaveForLaters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaveForLaterID,BuyerID,Date,CreatedDate,LastUpdatedDate,IsActive")] SaveForLater saveForLater)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saveForLater);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerID"] = new SelectList(_context.Buyers, "BuyerID", "BuyerID", saveForLater.BuyerID);
            return View(saveForLater);
        }

        // GET: SaveForLaters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saveForLater = await _context.SaveForLater.FindAsync(id);
            if (saveForLater == null)
            {
                return NotFound();
            }
            ViewData["BuyerID"] = new SelectList(_context.Buyers, "BuyerID", "BuyerID", saveForLater.BuyerID);
            return View(saveForLater);
        }

        // POST: SaveForLaters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaveForLaterID,BuyerID,Date,CreatedDate,LastUpdatedDate,IsActive")] SaveForLater saveForLater)
        {
            if (id != saveForLater.SaveForLaterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saveForLater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaveForLaterExists(saveForLater.SaveForLaterID))
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
            ViewData["BuyerID"] = new SelectList(_context.Buyers, "BuyerID", "BuyerID", saveForLater.BuyerID);
            return View(saveForLater);
        }

        // GET: SaveForLaters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saveForLater = await _context.SaveForLater
                .Include(s => s.Buyer)
                .FirstOrDefaultAsync(m => m.SaveForLaterID == id);
            if (saveForLater == null)
            {
                return NotFound();
            }

            return View(saveForLater);
        }

        // POST: SaveForLaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saveForLater = await _context.SaveForLater.FindAsync(id);
            _context.SaveForLater.Remove(saveForLater);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaveForLaterExists(int id)
        {
            return _context.SaveForLater.Any(e => e.SaveForLaterID == id);
        }
    }
}
