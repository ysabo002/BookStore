using BookStore.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IAddressService
    {
        Task<Address> Create(Address entity);
        Task<bool> Delete(Address entity);
        Task<Address> Get(int entityID);
        Task<Address> Update(Address entity);
        Task<ICollection<Address>> GetAll();
        Task<ICollection<Address>> GetAddressesByBuyerID(int entiyID);
        
    }
}
