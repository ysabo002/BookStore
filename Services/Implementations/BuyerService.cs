using BookStore.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementations
{
    public class BuyerService : IBuyerService
    {
        public Task<Buyer> Create(Buyer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Buyer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Buyer> Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Buyer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Buyer> Update(Buyer entity)
        {
            throw new NotImplementedException();
        }
    }
}
