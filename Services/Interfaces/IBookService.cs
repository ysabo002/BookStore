using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book> Create(Book entity);
        Task<bool> Delete(Book entity);
        Task<Book> Get(int entityID);
        Task<Book> Update(Book entity);
        Task<ICollection<Book>> GetAll();

        Task<ICollection<Book>> OrderAscendingByTitle(ICollection<Book> list);
        Task<ICollection<Book>> OrderDescendingByTittle(ICollection<Book> list);
        Task<ICollection<Book>> OrderAscendingByAuthor(ICollection<Book> list);

        Task<ICollection<Book>> OrderDescendingByAuthor(ICollection<Book> list);
        Task<ICollection<Book>> OrderAscendingByRating(ICollection<Book> list);
        Task<ICollection<Book>> OrderDescendingByRating(ICollection<Book> list);
        Task<ICollection<Book>> OrderDescendingByDate(ICollection<Book> list);
        Task<ICollection<Book>> OrderAscendingByDate(ICollection<Book> list);
        Task<ICollection<Book>> OrderAscendingByPrice(ICollection<Book> list);
        Task<ICollection<Book>> OrderDescendingByPrice(ICollection<Book> list);

        Task<ICollection<Book>> BrowseByGenre(ICollection<Book> list);
        Task<ICollection<Book>> BrowseByTopSellers(ICollection<Book> list);
        Task<ICollection<Book>> BrowseByRating(ICollection<Book> list);


    }
}
