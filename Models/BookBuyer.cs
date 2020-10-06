using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookBuyer
    {
        [Key]
        public int BookBuyerID { get; set; }
        public int BookID { get; set; }
        public int BuyerID { get; set; }

        public Book Book { get; set; } //nav prop
        public Buyer Buyer { get; set; } //nav prop
    }
}
