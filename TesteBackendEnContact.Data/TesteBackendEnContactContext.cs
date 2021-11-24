using TesteBackendEnContact.Core.Models;
using Microsoft.EntityFrameworkCore;
using TesteBackendEnContact.Data.Configurations;

namespace TesteBackendEnContact.Data
{
    public class TesteBackendEnContactContext: DbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Contact> Contacts { get; set; }
        public TesteBackendEnContactContext(DbContextOptions<TesteBackendEnContactContext> options) : base(options){}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}