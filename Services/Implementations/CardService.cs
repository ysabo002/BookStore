using BookStore.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementations
{
    public class CardService : ICardService
    {
        public Task<Card> Create(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task<Card> Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Card>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Card> Update(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}
