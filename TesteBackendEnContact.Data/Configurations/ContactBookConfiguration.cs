using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Data.Configurations
{
    public class ContactBookConfiguration : IEntityTypeConfiguration<ContactBook>
    {
        public void Configure(EntityTypeBuilder<ContactBook> builder)
        {
            builder
                .HasMany(c => c.Contacts)
                .WithOne(c => c.ContactBook);
            
            builder
                .HasOne(c => c.Company)
                .WithMany(c => c.ContactBooks)
                .HasForeignKey(c => c.CompanyId);
            
        }
    }
}