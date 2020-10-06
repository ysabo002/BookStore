using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ShoppingCart : BaseEntity
    {
        public int ShoppingCartID { get; set; }
        public List<Book> Books { get; set; }
        public double TotalPrice { get; set; }
        public int BuyerID { get; set; }
        public Buyer Buyer { get; set; }

        public List<BookShoppingCart> BookShoppingCarts { get; set; } //aux class for many to many

    }
}
