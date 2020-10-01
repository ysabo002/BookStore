using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Carts.Interfaces
{
    public interface ICartService
    {
        Task<ShoppingCart> Create(ShoppingCart entity);
        Task<bool> Delete(ShoppingCart entity);
        Task<ShoppingCart> Get(int entityID);
        Task<ShoppingCart> Update(ShoppingCart entity);
        Task<ICollection<ShoppingCart>> GetAll();
    }
}

