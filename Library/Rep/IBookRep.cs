using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Rep
{
    public interface IBookRep
    {
        Book Create(BookRequestModel bookRequestModel);

        List<Book> GetAll();

        Book GetById(int id);

        Book GetByISBN(string ISBN);

        Book Update(int id,BookRequestModel bookRequestModel);

        Book Delete(int id);
    }
}
