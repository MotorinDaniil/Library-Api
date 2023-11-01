using AutoMapper;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library;
namespace Library.Repository
{
    public class BookRep
    {
        
        public async Task<Book> Create(BookRequestModel bookRequestModel)
        {
            using (BookContext context = new BookContext())
            {
                
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BookRequestModel, Book>());
                var mapper = new Mapper(config);
                Book book_created = mapper.Map<Book>(bookRequestModel);
                context.Book.Add(book_created);
                await context.SaveChangesAsync();
                return book_created;
            }
        }

        public List<Book> GetAll()
        {
            using (BookContext context = new BookContext())
            {
                if (context.Book == null)
                {
                    return null;
                }
                return context.Book.ToList();

            }

        }

        public Book GetById(int id)
        {
            using (BookContext context = new BookContext())
            {
                if (!BookExists(id))
                {
                    return null;
                }
                return context.Book.Find(id);

            }

        }

        public Book GetByISBN(string ISBN)
        {
            using (BookContext context = new BookContext())
            {
                if (!BookExists(ISBN))
                {
                    return null;
                }
                return context.Book.Where(b => b.ISBN == ISBN).First();

            }

        }
        public async Task<Book> Update(int id, BookRequestModel bookRequestModel)
        {
            using (BookContext context = new BookContext())
            {
                if (!BookExists(id))
                {
                    return null;
                }
                Book book = context.Book.Find(id);
                book.ISBN = bookRequestModel.ISBN;
                book.Author = bookRequestModel.Author;
                book.Description = bookRequestModel.Description;
                book.DateToReturn = bookRequestModel.DateToReturn;
                book.Genre = bookRequestModel.Genre;
                book.DateTaken = bookRequestModel.DateTaken;
                context.Entry(book).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return book;
            }
        }

        public async Task<Book> Delete(int id)
        {
            using(BookContext context = new BookContext())
            {
                if (!BookExists(id))
                {
                    return null;
                }
                Book book = context.Book.Find(id);
                context.Book.Remove(book);
                await context.SaveChangesAsync();
                return book;           
            }
            
        }
        private bool BookExists(int id)
        {
            using (BookContext context = new BookContext())
            {
                return (context.Book?.Any(b => b.Id == id)).GetValueOrDefault();
            }

        }
        private bool BookExists(string ISBN)
        {
            using (BookContext context = new BookContext())
            {
                return (context.Book?.Any(b => b.ISBN == ISBN)).GetValueOrDefault();
            }
        }
    }
}
