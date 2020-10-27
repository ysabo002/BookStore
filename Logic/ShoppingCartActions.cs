using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;
using Microsoft.AspNetCore.Http;

namespace BookStore.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private ProductContext _db = new ProductContext();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            //many bugs rn tryng to figure out how to fix them
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();

            var ShoppingCart = _db.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id);
            if (ShoppingCart == null)
            {
                // Create a new cart item if no cart item exists.                 
                ShoppingCart = new ShoppingCart
                {
                    BookShoppingCarts = Guid.NewGuid().ToString(),
                    Books = id,
                    ShoppingCartID = ShoppingCartId,
                    Books = _db.Products.SingleOrDefault(
                   p => p.ProductID == id),
                    Quantity = 1,

                };

                _db.ShoppingCartItems.Add(ShoppingCart);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                ShoppingCart.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<ShoppingCart> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }
        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
            // Multiply product price by quantity of that product to get        
            // the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   
            decimal? total = decimal.Zero;
            total = (decimal?)(from ShoppingCart in _db.ShoppingCartItems
                               where ShoppingCart.ShoppingCartId == ShoppingCartId
                               select (int?)ShoppingCart.Quantity *
                               ShoppingCart.Product.UnitPrice).Sum();
            return total ?? decimal.Zero;
        }
    }
}