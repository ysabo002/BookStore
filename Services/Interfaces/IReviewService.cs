using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IReviewService
    {
        Task<Review> Create(Review entity);
        Task<bool> Delete(Review entity);
        Task<Review> Get(int entityID);
        Task<Review> Update(Review entity);
        Task<ICollection<Review>> GetAll();
    }
}

