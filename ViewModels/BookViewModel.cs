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

        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
       public string ShortTitle => Title.Length < 15 ? Title.Substring(0, Title.Length) : Title.Substring(0, 15);

        [Required]

        public string Author { get; set; }
        [Required]

        public string Genre { get; set; }
        [Required]

        public string Isbn { get; set; }
        [Required]

        public string Seller { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public double Price { get; set; }

        
        public double RatingAve { get; set; } //to be changed so it takes the average of all the reviews on listOfBookReviews

        public IFormFile Cover { get; set; }//to storage cover image

        public string ImageName { get; set; }  //name of the cover file
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        public DateTime CreationDate { get; set; }

        
        //public string CreationDateString => CreationDate.ToShortDateString();

        public int Quantity { get; set; }
        public List<ReviewViewModel> listOfBookReviews { get; set; }
        public ReviewViewModel Review { get; set; } //nav prop
        
    }
}


