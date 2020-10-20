using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class CardViewModel : BaseEntityViewModel
    {
        public int CardID { get; set; }
        public string CardNumber { get; set; }
        
        public int SecCode { get; set; }
        
        public bool Preferred { get; set; }

        public int BuyerID { get; set; }
        public BuyerViewModel Buyer { get; set; } //nav prop

       
    }
}