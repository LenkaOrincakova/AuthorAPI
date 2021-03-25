using AuthorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAPI.Data
{
    public interface IAuthorsService
    {
        Task<IList<Author>> GetAuthorsAsync();
        Task<Author> AddAuthorAsync(Author author);
        Task<IList<Book>> GetBooksAsync();
        Task<Book> AddBooksAsync(Book book);
        //Task<Book> AddBooksAsync(Author author);
        Task RemoveBookAsync(int isbn);


    }
}
