using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using Library.Repository;
using AutoMapper;
using Library.Rep;
using System.Diagnostics;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly BookRep _rep = new BookRep();
        private readonly BookContext _context;
        public BooksController(BookContext context)
        {
            _context = context;
        }
        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            Debug.WriteLine("it starts");
            List<Book> res = _rep.GetAll();
            if (res == null)
            {
                return Ok();
            }
            return res;
        }

        // GET: api/Books/5
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            Book res = _rep.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        [HttpGet("/GetByISBN/{ISBN}")]
        public async Task<ActionResult<Book>> GetBookByISBN(string ISBN)
        {
            Book res = _rep.GetByISBN(ISBN);
            if (res == null)
            {
                return NotFound();
            }

            return res;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBook(int id, BookRequestModel bookRequestModel)
        {

            Task<Book> res = _rep.Update(id, bookRequestModel);
            if (res == null)
            {
                return NotFound();
            }
            return await res;

        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookRequestModel bookRequestModel)
        {
            Task<Book> res = _rep.Create(bookRequestModel);
            if (res == null)
            {
                return Problem("Book has not found");
            }

            return await res;
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            Task<Book> res = _rep.Delete(id);
            if (res == null)
            {
                return Problem("Book is not found");
            }
            return await res;
        }

    }
}
