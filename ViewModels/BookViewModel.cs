using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookViewModel : BaseEntityViewModel
    {
        [Required]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string Seller { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double RatingAve { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Cover { get; set; }//to storage cover image
        [Required] 
        public string ImageName { get; set; }  //name of the cover file

        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public int Quantity { get; set; }



    }
}
