using BookStore.Data;
using BookStore.Models;
using BookStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Implementations
{


    public class BookService : IBookService

    {

        BookStoreContext my_Context;

        public BookService(BookStoreContext myContext)
        {
            my_Context = myContext;
        }

        public Task<ICollection<Book>> BrowseByGenre(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> BrowseByRating(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> BrowseByTopSellers(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Create(Book entity)
        {
            throw new NotImplementedException();

        }

        public Task<bool> Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderAscendingByAuthor(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderAscendingByDate(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderAscendingByPrice(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderAscendingByRating(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderAscendingByTitle(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderDescendingByAuthor(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderDescendingByDate(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderDescendingByPrice(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderDescendingByRating(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> OrderDescendingByTittle(ICollection<Book> list)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Update(Book entity)
        {
            throw new NotImplementedException();
        }

        
        
    }
}
