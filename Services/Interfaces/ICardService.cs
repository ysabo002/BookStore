using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface ICardService
    {
        Task<Card> Create(Card entity);
        Task<bool> Delete(Card entity);
        Task<Card> Get(int entityID);
        Task<Card> Update(Card entity);
        Task<ICollection<Card>> GetAll();
    }
}

