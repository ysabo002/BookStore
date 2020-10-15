using System;

namespace BookStore.Models
{
    public class Card : BaseEntity
    {
        public int CardID { get; set; }
        public string CardNumber { get; set; }
        public int SecCode { get; set; }
        public bool Preferred { get; set; }

        public int BuyerID { get; set; }
        public Buyer Buyer { get; set; } //nav prop

       
    }
}