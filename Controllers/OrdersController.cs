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
    public class OrdersController : Controller
    {
        public string BaseUrl = "https://localhost:44327/api/";

        public OrdersController()
        {

        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = new List<OrderViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                Task<HttpResponseMessage> responseTask = client.GetAsync("Orders");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<IList<OrderViewModel>>();

                    orders = readTask.ToList();

                    return View(orders);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = new OrderViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Orders/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<OrderViewModel>();

                    order = readTask;

                    return View(order);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,BookID,BuyerID,CreatedDate,LastUpdatedDate,IsActive")] OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                order.IsActive = true;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var responseTask = await client.PostAsJsonAsync("Orders", order);
                    return RedirectToAction(nameof(Index));

                }

            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = new OrderViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Orders/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<OrderViewModel>();

                    order = readTask;

                    return View(order);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(order);
        }

        // POST: Buyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,BookID,BuyerID,CreatedDate,LastUpdatedDate,IsActive")] OrderViewModel order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(BaseUrl);
                        var responseTask = await client.PutAsJsonAsync($"Buyers/{id}", order);
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Buyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = new OrderViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Orders/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<OrderViewModel>();

                    order = readTask;

                    return View(order);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(order);
        }

        // POST: Buyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.DeleteAsync($"Orders/{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Delete");
            }


        }
    }
}