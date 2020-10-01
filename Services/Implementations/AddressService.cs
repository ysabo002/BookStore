using BookStore.Data;
using BookStore.Models;
using BookStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private BookStoreContext _context;
        public AddressService(BookStoreContext context)
        {
            _context = context;
        }

        public Task<Address> Create(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Address>> GetAddressesByBuyerID(int entiyID)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Address>> GetAll()
        {
            var adresses = await _context.Addresses.Where(x => x.IsActive).ToListAsync();

            return adresses;
        }

        public Task<Address> Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
