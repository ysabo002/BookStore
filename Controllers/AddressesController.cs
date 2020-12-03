using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using BookStore.ViewModels;
using System.Net.Http;

namespace BookStore
{
    public class AddressesController : BaseController
    {
        public string BaseUrl = "https://localhost:44357/api/";

        public AddressesController()
        {

        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var addresses = new List<AddressViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                Task<HttpResponseMessage> responseTask = client.GetAsync("Addresses");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<IList<AddressViewModel>>();

                    addresses = readTask.ToList();

                    return View(addresses);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(addresses);
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = new AddressViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"addresses/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<AddressViewModel>();

                    address = readTask;

                    return View(address);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(address);
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
                address.IsActive = true;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var responseTask = await client.PostAsJsonAsync("Addresses", address);
                    return RedirectToAction(nameof(Index));

                }

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

            var address = new AddressViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Addresses/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<AddressViewModel>();

                    address = readTask;

                    return View(address);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(address);
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
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(BaseUrl);
                        var responseTask = await client.PutAsJsonAsync($"Addresses/{id}", address);
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {

                }
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

            var address = new AddressViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Addresses/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<AddressViewModel>();

                    address = readTask;

                    return View(address);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.DeleteAsync($"Addresses/{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Delete");
            }


        }
    }
}