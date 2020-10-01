using BookStore.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementations
{
    public class UserService : IUserService
    {
        public Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
