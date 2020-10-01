using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Create(User entity);
        Task<bool> Delete(User entity);
        Task<User> Get(int entityID);
        Task<User> Update(User entity);
        Task<ICollection<User>> GetAll();
    }
}

