using BookStore.Carts.Interfaces;
using BookStore.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementations
{
    public class CartServices : ICartService
    {
        public Task<ShoppingCart> Create(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ShoppingCart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> Update(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }
    }
}
