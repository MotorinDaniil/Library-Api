using Microsoft.EntityFrameworkCore;
using Library.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookContext>(options =>
{
    options.UseSqlServer("Data Source=LAPTOP-6MK2PS7G;Initial Catalog=Library;Trusted_Connection=True;TrustServerCertificate=True");
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("api/books", async (BookContext db) => await db.Book.ToListAsync());
app.MapGet("api/books/{id:int}", async (int id, BookContext db) =>
{
    Book? book = await db.Book.FirstOrDefaultAsync(b => b.Id == id);

    if (book == null) return Results.NotFound(new { message = "Book is not found" });

    return Results.Json(book);
});
app.MapGet("api/books/{ISBN}", async (string ISBN, BookContext db) =>
{
    Book? book = await db.Book.FirstOrDefaultAsync(b => b.ISBN == ISBN);

    if (book == null) return Results.NotFound(new { message = "Book is not found" });

    return Results.Json(book);
});

app.MapDelete("api/books/{id:int}", async (int id, BookContext db) =>
{
    Book? book = await db.Book.FirstOrDefaultAsync(b => b.Id == id);

    if (book == null) return Results.NotFound(new { message = "Book is not found" });

    db.Book.Remove(book);
    db.SaveChanges();
    await db.SaveChangesAsync();
    return Results.Json(book);
});

app.MapPost("api/books", async (Book book, BookContext db) =>
{
    await db.Book.AddAsync(book);
    await db.SaveChangesAsync();
    return book;
}
);
app.MapPut("api/books", async (Book bookData, BookContext db) =>
{
    var book = await db.Book.FirstOrDefaultAsync(b => b.Id == bookData.Id);

    if (book == null) return Results.NotFound(new { message = "Book is not found" });

    book.ISBN = bookData.ISBN;
    book.Name = bookData.Name;
    book.Genre = bookData.Genre;
    book.Description = bookData.Description;
    book.Author = bookData.Author;
    book.DateToReturn = bookData.DateToReturn;
    book.DateTaken = bookData.DateTaken;

    await db.SaveChangesAsync();
    return Results.Json(book);

});


app.Run();
