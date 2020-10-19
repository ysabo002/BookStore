using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookViewModel : BaseEntityViewModel
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

       
        public DateTime CreationDate { get; set; }
        public int Quantity { get; set; }



    }
}
