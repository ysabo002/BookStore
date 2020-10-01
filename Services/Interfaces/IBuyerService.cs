using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IBuyerService
    {
        Task<Buyer> Create(Buyer entity);
        Task<bool> Delete(Buyer entity);
        Task<Buyer> Get(int entityID);
        Task<Buyer> Update(Buyer entity);
        Task<ICollection<Buyer>> GetAll();
    }
}

