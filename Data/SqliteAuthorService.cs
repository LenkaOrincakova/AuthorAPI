using AuthorAPI.DataAccess;
using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAPI.Data
{
    public class SqliteAuthorService : IAuthorsService
    {
        private AuthorBookDbContext context;
        public SqliteAuthorService(AuthorBookDbContext context)
        {
            this.context = context;
        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            EntityEntry<Author> newlyAdded = await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<Book> AddBooksAsync(Book book)
        {
            EntityEntry<Book> newlyAdded = await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return newlyAdded.Entity;
        }
        //public async Task<Book> AddBooksAsync(Author author)
        //{
        //    EntityEntry<Book> newlyAdded = await context.Books.AddAsync(author);
        //    await context.SaveChangesAsync();
        //    return newlyAdded.Entity;
        //}

        public async Task<IList<Author>> GetAuthorsAsync()
        {
            return await context.Authors.ToListAsync();
        }

        public async Task<IList<Book>> GetBooksAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task RemoveBookAsync(int isbn)
        {
            Book toDelete = await context.Books.FirstOrDefaultAsync(t => t.ISBN == isbn);
            if(toDelete != null)
            {
                context.Books.Remove(toDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}
