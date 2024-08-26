using Microsoft.EntityFrameworkCore;

public class ContactDb : DbContext
{
    public ContactDb(DbContextOptions<ContactDb> options) : base(options) { }

    public DbSet<Contact> Contacts => Set<Contact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Contact>().HasData(
            new Contact {
                Id = 1,
                FirstName = "Ankita", 
                MiddleName = "Shree",
                LastName="Lokhande", 
                Company = "AECC Food Mart",
                Website = "www.aeccfoodmart.com",
                Title = "Floor Supervisor",
                Phone = "6039060126",
                Email = "floormanager@aeccfoodmart.com",
                AddressLine1 = "5123 Elm Street",
                AddressLine2 = "Vermillion, South Dakota 57069, USA"
            },
            new Contact
            {
                Id = 2,
                FirstName = "Rod",
                LastName = "Anthony",
                Company = "Family Snacks LLC",
                Website = "www.familysnacks.com",
                Title = "Sr. Application Officer",
                Phone = "2563905673",
                Email = "supportadmissions@familysnacks.com",
                AddressLine1 = "645 Winchester Road",
                AddressLine2 = "New Market 4567, Alabama"
            },
            new Contact
            {
                Id = 3,
                FirstName = "Robert",
                LastName = "Timothy",
                Company = "Delicious Foods",
                Website = "www.diliciousfoods.com",
                Title = "Restaurant Manager",
                Phone = "2568943906",
                Email = "restro_manager@diliciousfoods.com",
                AddressLine1 = "89 Oxford Road",
                AddressLine2 = "New Market 4567, Alabama"
            },
            new Contact
            {
                Id = 4,
                FirstName = "Sharon",
                LastName = "Stone",
                Company = "Delicious Foods",
                Website = "www.deliciousfoods.com",
                Title = "Restaurant Owner",
                Phone = "2568462345",
                Email = "owner@deliciousfoods.com",
                AddressLine1 = "1245 Oxford Road",
                AddressLine2 = "New Market 4567, Alabama"
            },
            new Contact
            {
                Id = 5,
                FirstName = "William",
                MiddleName = "Bradley",
                LastName = "Pitt",
                Company = "Marvel Studios",
                Website = "www.marvelstudios.com",
                Title = "Chief Executive Officer",
                Phone = "9368472769",
                Email = "brad.pitt@marvelstudios.com",
                AddressLine1 = "1245 Stars Drive",
                AddressLine2 = "Hollywood 9883, California"
            }
        );
    }
}