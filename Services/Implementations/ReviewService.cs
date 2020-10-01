using BookStore.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        public Task<Review> Create(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Review>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Review> Update(Review entity)
        {
            throw new NotImplementedException();
        }
    }
}
