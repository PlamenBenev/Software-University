using Contacts.Data.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
            /* builder
                .Entity<Contact>()
                .HasData(new Contact()
                {
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    PhoneNumber = "+359881223344",
                    Address = "Gotham City",
                    Email = "imbatman@batman.com",
                    Website = "www.batman.com"
                });
            */
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<ApplicationUserContact>().HasKey(e => new {e.ApplicationUserId,e.ContactId});

            builder.Entity<ApplicationUser>()
                .Property(p => p.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

			builder.Entity<ApplicationUser>()
	            .Property(p => p.Email)
	            .IsRequired()
				.HasColumnType("nvarchar(60)");

            builder
                .Entity<Contact>()
                .HasData(new Contact()
                {
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    PhoneNumber = "+359881223344",
                    Address = "Gotham City",
                    Email = "imbatman@batman.com",
                    Website = "www.batman.com"
                });

            base.OnModelCreating(builder);
		}

	}
}