using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book : BaseEntity
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Isbn { get; set; }
        public string Seller { get; set; }
        public double Price { get; set; }
        public double RatingAve { get; set; }
        public byte[] Cover { get; set; } //to storage cover image

        public List<Review> Reviews { get; set; }
        public List<BookShoppingCart> BookShoppingCarts { get; set; } //aux list for relationship many to many
        public List<BookBuyer> BookBuyers { get; set; } //aux list for relationship many to many
        public List<BookSaveForLater> BookSaveForLaters { get; set; }
        public DateTime CreationDate { get; set; }
        public int Quantity { get; set; }



    }
}
