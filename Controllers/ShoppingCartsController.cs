using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore
{
    public class ShoppingCartsController : Controller
    {
        

        public ShoppingCartsController()
        {
           
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
     
            return View();
        }

        // GET: ShoppingCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

          
          

            return View();
        }

        // GET: ShoppingCarts/Create
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingCartID,TotalPrice,BuyerID,CreatedDate,LastUpdatedDate,IsActive")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerID"] = new SelectList( "BuyerID", "BuyerID");
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
           
            ViewData["BuyerID"] = new SelectList("BuyerID", "BuyerID");
            return View();
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingCartID,TotalPrice,BuyerID,CreatedDate,LastUpdatedDate,IsActive")] ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.ShoppingCartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerID"] = new SelectList( "BuyerID", "BuyerID");
            return View();
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

       
    }
}
