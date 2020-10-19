using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using BookStore.ViewModels;

namespace BookStore
{
    public class AddressesController : Controller
    {
       

        public AddressesController()
        {
           
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            

            return View();
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressID,Address1,Address2,ZipCode,City,State,Preferred,CreatedDate,LastUpdatedDate,IsActive")] AddressViewModel address)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            
            return View();
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressID,Address1,Address2,ZipCode,City,State,Preferred,CreatedDate,LastUpdatedDate,IsActive")] AddressViewModel address)
        {
            if (id != address.AddressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
              

            return View();
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            return RedirectToAction(nameof(Index));
        }

       
    }
}
