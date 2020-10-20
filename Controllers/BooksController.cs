﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BookStore
{
    public class BooksController : Controller
    {
        public string BaseUrl = "https://localhost:44357/api/";
        private readonly IWebHostEnvironment _hostEnvironment;

        public BooksController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = new List<BookViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                Task<HttpResponseMessage> responseTask = client.GetAsync("Books");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<IList<BookViewModel>>();

                    books = readTask.ToList();

                    return View(books);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = new BookViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Books/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<BookViewModel>();

                    book = readTask;

                    return View(book);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,Author,Genre,Isbn,Seller,Price,RatingAve,Cover,CreationDate,Quantity,CreatedDate,LastUpdatedDate,IsActive")] BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                book.IsActive = true;

                //snippet of code for saving the cover image to wwwroot/Images

                //string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(book.Cover.FileName);
                //string extension = Path.GetExtension(book.Cover.FileName);
                //book.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                //string path = Path.Combine(wwwRootPath +"/Images/", fileName);
                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    await book.Cover.CopyToAsync(fileStream);
                //}
                //Insert record

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    //var bookEntity = new Book()
                    //{
                    //    ImageName = book.ImageName,
                    //    CreationDate = DateTime.UtcNow,
                    //    LastUpdatedDate = DateTime.UtcNow,
                    //    Cover = book.Cover,
                    //    Genre = book.Genre,
                    //    Author = book.Author,
                    //    Isbn = book.Isbn,
                    //    Price = book.Price,
                    //    Quantity = book.Quantity,
                    //    RatingAve = book.RatingAve,
                    //    Title = book.Title
                    //};
                    var responseTask = await client.PostAsJsonAsync("Books", book);
                    return RedirectToAction(nameof(Index));

                }

            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = new BookViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Books/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<BookViewModel>();

                    book = readTask;

                    return View(book);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(book);

        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,Title,Author,Genre,Isbn,Seller,Price,RatingAve,CreationDate,Quantity,CreatedDate,LastUpdatedDate,IsActive")] BookViewModel book)
        {
            if (id != book.BookID)
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
                        var responseTask = await client.PutAsJsonAsync($"Books/{id}", book);
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = new BookViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Books/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<BookViewModel>();

                    book = readTask;

                    return View(book);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.DeleteAsync($"Books/{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index)); 
                }

                return RedirectToAction("Delete");
            }


        }
    }
}
