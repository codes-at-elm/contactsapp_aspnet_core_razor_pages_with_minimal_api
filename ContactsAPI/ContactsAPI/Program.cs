using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ContactDb>(opt => opt.UseInMemoryDatabase("ContactList"));
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ContactDb>();
    dbContext.Database.EnsureCreated();
}

app.MapGet("contactlist", async (ContactDb db) => await db.Contacts.ToListAsync())
    .WithName("GetAllContacts")
    .WithTags("Get all contacts.")
    .WithOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();