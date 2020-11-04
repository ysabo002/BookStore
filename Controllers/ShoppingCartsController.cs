using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace BookStore
{
    public class ShoppingCartsController : Controller
    {
        public string BaseUrl = "https://localhost:44357/api/";


        public ShoppingCartsController()
        {
           
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            var shoppingcarts = new List<ShoppingCartViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                Task<HttpResponseMessage> responseTask = client.GetAsync("ShoppingCarts");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<IList<ShoppingCartViewModel>>();

                    shoppingcarts = readTask.ToList();

                    return View(shoppingcarts);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
   
            return View(shoppingcarts);
        }

        // GET: ShoppingCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shoppingcart = new ShoppingCartViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"ShoppingCarts/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<ShoppingCartViewModel>();

                    shoppingcart = readTask;

                    return View(shoppingcart);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(shoppingcart);
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
        public async Task<IActionResult> Create([Bind("ShoppingCartID,TotalPrice,BuyerID,CreatedDate,LastUpdatedDate,IsActive")] ShoppingCartViewModel shoppingCart)
        {
            if (ModelState.IsValid)
            {
                shoppingCart.IsActive = true;

              

                using (var client = new HttpClient())
                {
                   
                    
                    var responseTask = await client.PostAsJsonAsync("ShoppingCart", shoppingCart);
                    return RedirectToAction(nameof(Index));

                }

            }
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shoppingcart = new ShoppingCartViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"ShoppingCarts/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<ShoppingCartViewModel>();

                    shoppingcart = readTask;

                    return View(shoppingcart);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(shoppingcart);

        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingCartID,TotalPrice,BuyerID,CreatedDate,LastUpdatedDate,IsActive")] ShoppingCartViewModel shoppingCart)
        {
            if (id != shoppingCart.ShoppingCartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                shoppingCart.LastUpdatedDate = DateTime.UtcNow;
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(BaseUrl);
                        var responseTask = await client.PutAsJsonAsync($"ShoppingCart/{id}", shoppingCart);
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shoppingcart = new ShoppingCartViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"ShoppingCart/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {

                    var readTask = await responseTask.Content.ReadAsAsync<ShoppingCartViewModel>();

                    shoppingcart = readTask;

                    return View(shoppingcart);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(shoppingcart);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.DeleteAsync($"ShoppingCart/{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<ShoppingCartViewModel>();
                    var shoppingcart = readTask;
                   
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Delete");
            }


        }
        

    }
}
