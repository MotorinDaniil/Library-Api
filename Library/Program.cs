using Microsoft.EntityFrameworkCore;
using Library.Models;
using Library.Rep;
using Library.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<BookRep>();
builder.Services.AddScoped<BookRep>();
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



app.Run();
