using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

app.MapGet("/contactlist", async (ContactDb db) => await db.Contacts.ToListAsync())
    .WithTags("Get all contacts");

app.MapGet("/contactlist/{id}",
    async (int id, ContactDb db) =>
        await db.Contacts.FindAsync(id) is Contact contact
        ? Results.Ok(contact)
        : Results.NotFound())
    .WithTags("Get contact by Id");

app.MapPost("/contactlist", async (Contact contact, ContactDb db) =>
{
    db.Contacts.Add(contact);
    await db.SaveChangesAsync();

    return Results.Created($"/contactlist/{contact.Id}", contact);
}).WithTags("Create new contact");

app.MapPut("/contactlist/{id}", async (int id, Contact inputContact, ContactDb db) =>
{
    var contact = await db.Contacts.FindAsync(id);

    if (contact is null) return Results.NotFound();

    contact.FirstName = inputContact.FirstName;
    contact.MiddleName = inputContact.MiddleName;
    contact.LastName = inputContact.LastName;
    contact.Company = inputContact.Company;
    contact.Website = inputContact.Website;
    contact.Title = inputContact.Title;
    contact.Phone = inputContact.Phone;
    contact.Email = inputContact.Email;
    contact.AddressLine1 = inputContact.AddressLine1;
    contact.AddressLine2 = inputContact.AddressLine2;

    await db.SaveChangesAsync();

    return Results.NoContent();

}).WithTags("Update contact by Id");

app.MapDelete("/contactlist/{id}", async (int id, ContactDb db) =>
{
    var contact = await db.Contacts.FindAsync(id);

    if (contact is null) return Results.NotFound();

    db.Contacts.Remove(contact);
    await db.SaveChangesAsync();
    return Results.Ok(contact);

}).WithTags("Delete contact by Id");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();