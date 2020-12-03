using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using System.Net.Http;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BookStore
{
    public class ReviewsController : BaseController
    {
        public string BaseUrl = "https://localhost:44327/api/";

        public ReviewsController()
        {

        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var reviews = new List<ReviewViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                Task<HttpResponseMessage> responseTask = client.GetAsync("Reviews");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<IList<ReviewViewModel>>();

                    reviews = readTask.ToList();

                    return View(reviews);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(reviews);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = new ReviewViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Review/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<ReviewViewModel>();

                    review = readTask;

                    return View(review);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewID,BuyerID,BookID,Username,CreationDate,Ratingtxt,Rating,CreatedDate,LastUpdatedDate,IsActive")] ReviewViewModel review)
        {
            if (ModelState.IsValid)
            {
                review.IsActive = true;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var responseTask = await client.PostAsJsonAsync("Reviews", review);
                    return RedirectToAction(nameof(Index));

                }

            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = new ReviewViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Reviews/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<ReviewViewModel>();

                    review = readTask;

                    return View(review);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,BuyerID,BookID,Username,CreationDate,Ratingtxt,Rating,CreatedDate,LastUpdatedDate,IsActive")] ReviewViewModel review)
        {
            if (id != review.ReviewID)
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
                        var responseTask = await client.PutAsJsonAsync($"Reviews/{id}", review);
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = new ReviewViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.GetAsync($"Reviews/{id.Value}");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<ReviewViewModel>();

                    review = readTask;

                    return View(review);
                }

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");

            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                //HTTP GET
                HttpResponseMessage responseTask = await client.DeleteAsync($"Reviews/{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction("Delete");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(IFormCollection form)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var ratingtxt = form["Comment"].ToString();
                var bookID = int.Parse(form["BookID"]);
                var rating = int.Parse(form["Rating"]);
                int buyerID = 1;
                
                HttpResponseMessage responseTask3 = await client.GetAsync($"Orders/GetOrderForBooknBuyer/{bookID}/{buyerID}");
                
                if (responseTask3.IsSuccessStatusCode)
                {
                    
                    HttpResponseMessage responseTask4 = await client.GetAsync($"Reviews/GetReviewForBooknBuyer/{bookID}/{buyerID}");
                    if (responseTask4.IsSuccessStatusCode)
                    {
                        TempData["DuplicateReview"] = "You have already submitted a review for this book.";
                    }
                    else
                    {
                        var buyer = new BuyerViewModel();
                        HttpResponseMessage responseTask2 = await client.GetAsync($"Buyers/{buyerID}");
                        var readTask2 = await responseTask2.Content.ReadAsAsync<BuyerViewModel>();
                        buyer = readTask2;
                        string username = buyer.Name;

                        if (form["Anonymous"].ToString() == "Checked")
                        {
                            username = null;
                        }
                        else if (form["Nickname"].ToString() == "Checked1")
                        {
                            username = buyer.Nickname;
                        }
                        else
                        {
                            username = buyer.Name;
                        }

                        ReviewViewModel review = new ReviewViewModel()
                        {
                            Ratingtxt = ratingtxt,
                            BookID = bookID,
                            Rating = (Rating)rating,
                            CreationDate = DateTime.Now,
                            BuyerID = buyerID,
                            Username = username
                        };

                        review.IsActive = true;
                        var responseTask = await client.PostAsJsonAsync("Reviews/Add", review);
                    }

                   

                }
                else
                {
                    TempData["RatingError"] = "You cannot rate until you have purchased this book.";
                }


                return RedirectToAction("Details", "Books", new { id = bookID });

            }
            

        }

    }
}

