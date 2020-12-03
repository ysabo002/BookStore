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
    public class BooksController : Controller
    {
        public string BaseUrl = "https://localhost:44327/api/";
        private readonly IWebHostEnvironment _hostEnvironment;

        public IEnumerable<BookViewModel> TopSellers { get; private set; }

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

                    TopSellers = books.OrderByDescending(i => i.RatingAve).Take(5);
                    ViewBag.TopSellers = TopSellers;

                    return View(books);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }

            TopSellers = books.OrderByDescending(i => i.RatingAve).Take(5);
            ViewBag.TopSellers = TopSellers;

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
                HttpResponseMessage responseTask2 = await client.GetAsync($"Reviews/GetReviewsForBook/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    if (TempData["RatingError"] != null)
                    {
                        ModelState.AddModelError("RatingError", TempData["RatingError"].ToString());
                    }

                    if(TempData["DuplicateReview"] != null)
                    {
                        ModelState.AddModelError("DuplicateReview", TempData["DuplicateReview"].ToString());
                    }

                    var readTask = await responseTask.Content.ReadAsAsync<BookViewModel>();

                    book = readTask;

                    var readTask2 = await responseTask2.Content.ReadAsAsync<IList<ReviewViewModel>>();

                    var ratingtxt = readTask2.ToList();
                    ViewBag.Ratingtxt = ratingtxt;

                    var ratings = readTask2.ToList();

                    ViewBag.BookID = id;
                    ViewBag.BuyerID = 0;

                    if (ratings.Count() > 0)
                    {
                        var ratingSum = ratings.Sum(d => (decimal)d.Rating); 
                        ViewBag.RatingSum = ratingSum;
                        var ratingCount = ratings.Count();
                        ViewBag.RatingCount = ratingCount;
                    }
                    else
                    {
                        ViewBag.RatingSum = 0;
                        ViewBag.RatingCount = 0;
                    }

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

                ////snippet of code for saving the cover image to wwwroot/Images

                string wwwrootpath = _hostEnvironment.WebRootPath;
                string filename = String.Concat(DateTime.Now.ToString("yyyMMddHHmm"), book.Cover.FileName);
                string path = String.Concat(wwwrootpath + "/images/", filename);
                
                //string extension = path.getextension(book.cover.filename);
                book.ImageName = filename;

                using (var filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    await book.Cover.CopyToAsync(filestream);
                }
                // insert record

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
                    book.Cover = null;
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
        public async Task<IActionResult> Edit(int id, [Bind("BookID,Title,Author,Genre,Isbn,Seller,Price,RatingAve,Cover,CreationDate,Quantity,CreatedDate,LastUpdatedDate,IsActive")] BookViewModel book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                book.LastUpdatedDate = DateTime.UtcNow;
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
        [HttpPost, ActionName("Delete")]
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
                    var readTask = await responseTask.Content.ReadAsAsync<BookViewModel>();
                    var book = readTask;
                    if (book.ImageName != null && book.ImageName != "")
                    {
                        string wwwrootpath = _hostEnvironment.WebRootPath;
                        string filename = book.ImageName;
                        string path = String.Concat(wwwrootpath + "/images/", filename);
                        System.IO.File.Delete(path);
                    }
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Delete");
            }


        }
    }
}
