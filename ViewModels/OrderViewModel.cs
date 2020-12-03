using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class OrderViewModel : BaseEntityViewModel
    {
        public int OrderID { get; set; }
        public int BuyerID { get; set; }
        public int BookID { get; set; }
        public BuyerViewModel Buyer { get; set; } //nav prop
        public BookViewModel Book { get; set; } //nav prop
    }
}
