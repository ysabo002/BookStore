using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookShoppingCart
    {
       
        public int BookShoppingCartID { get; set; }
        public int BookID { get; set; }
        public int ShoppingCartID { get; set; }

        public Book Book { get; set; } //nav prop
        public ShoppingCart ShoppingCart { get; set; } //nav prop
    }
}
