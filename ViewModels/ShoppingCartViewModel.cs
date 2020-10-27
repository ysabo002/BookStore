using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class ShoppingCartViewModel : BaseEntityViewModel
    {
        public int ShoppingCartID { get; set; }
        public List<BookViewModel> Books { get; set; }
        public double TotalPrice { get; set; }
        public int BuyerID { get; set; }
        public BuyerViewModel Buyer { get; set; }

        

    }
}
