using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Review : BaseEntity
    {
        #region Object properties
        public int ReviewID { get; set; }
        public int BuyerID { get; set; }
        public int BookID { get; set; }
        public DateTime CreationDate { get; set; }
        public string Ratingtxt { get; set; }

        public Rating Rating { get; set; }
        #endregion

        #region Navigation Properties
        public Buyer Buyer { get; set; } //nav prop
        public Book Book { get; set; } //nav prop
        #endregion


    }

    public enum Rating { 
    
        Poor = 1, 
        Average = 2,
        Good = 3, 
        VeryGood = 4, 
        Excellent = 5
   
    }
}
