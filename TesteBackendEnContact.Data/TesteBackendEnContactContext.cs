using TesteBackendEnContact.Core.Models;
using Microsoft.EntityFrameworkCore;
using TesteBackendEnContact.Data.Configurations;

namespace TesteBackendEnContact.Data
{
    public class TesteBackendEnContactContext: DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactBook> ContactBooks { get; set; }
        public TesteBackendEnContactContext(DbContextOptions<TesteBackendEnContactContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            modelBuilder.ApplyConfiguration(new ContactBookConfiguration());
        }
    }
}