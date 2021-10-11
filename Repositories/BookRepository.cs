using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repositories
{
    public class BookRepository: IBookRepository
    {
        private protected readonly BookContext Context;

        public BookRepository(BookContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
           return await Context.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await Context.Books.FindAsync(id);
        }

        public async Task<Book> CreateBook(Book book)
        {
            Context.Books.Add(book);
            await Context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBook(Book book)
        {
            Context.Entry(book).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var bookToDelete = await Context.Books.FindAsync(id);
            Context.Books.Remove(bookToDelete);
            await Context.SaveChangesAsync();
        }
    }
}
