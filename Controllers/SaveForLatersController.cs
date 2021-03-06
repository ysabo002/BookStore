﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.ViewModels;

namespace BookStore
{
    public class SaveForLatersController : BaseController
    {
      

       

        // GET: SaveForLaters
        public async Task<IActionResult> Index()
        {
          
            return View();
        }

        // GET: SaveForLaters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

          
           

            return View();
        }

        // GET: SaveForLaters/Create
        public IActionResult Create()
        {
            ViewData["BuyerID"] = new SelectList("BuyerID", "BuyerID");
            return View();
        }

        // POST: SaveForLaters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaveForLaterID,BuyerID,Date,CreatedDate,LastUpdatedDate,IsActive")] SaveForLaterViewModel saveForLater)
        {
            if (ModelState.IsValid)
            {
              
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerID"] = new SelectList( "BuyerID", "BuyerID");
            return View(saveForLater);
        }

        // GET: SaveForLaters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
           
            ViewData["BuyerID"] = new SelectList( "BuyerID", "BuyerID");
            return View();
        }

        // POST: SaveForLaters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaveForLaterID,BuyerID,Date,CreatedDate,LastUpdatedDate,IsActive")] SaveForLaterViewModel saveForLater)
        {
            if (id != saveForLater.SaveForLaterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerID"] = new SelectList( "BuyerID", "BuyerID");
            return View(saveForLater);
        }

        // GET: SaveForLaters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
           

            return View();
        }

        // POST: SaveForLaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            return RedirectToAction(nameof(Index));
        }

       
    }
}
