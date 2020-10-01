using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SaveForLater
    {
        public int SaveForLaterID { get; set; }
        public List<Book> BookList { get; set; }
        public int BuyerID { get; set; }

        public DateTime Date { get; set; }


        // Navigation Properties
        public Buyer Buyer { get; set; } //nav prop
    }
}
