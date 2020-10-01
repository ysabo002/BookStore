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
        public DateTime CreationDate { get; set; }
        public int Quantity { get; set; }



    }
}
