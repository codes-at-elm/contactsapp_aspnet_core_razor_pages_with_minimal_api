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
                FirstName = "Ankita", 
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
                FirstName = "Rod",
                LastName = "Anthony",
                Company = "Family Snacks LLC",
                Website = "www.familysnacks.com",
                Title = "Sr. Application Officer",
                Phone = "2563905673",
                Email = "supportadmissions@familysnacks.com",
                AddressLine1 = "645 Winchester Road",
                AddressLine2 = "New Market 4567, Alabama"
            }
        );
    }
}