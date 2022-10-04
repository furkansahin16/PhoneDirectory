using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneDirectory.Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Domain.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.AddressID)
                .IsRequired()
                .UseIdentityColumn(1, 1);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode();

            builder.Property(a => a.City)
                .HasMaxLength(20)
                .IsUnicode();

            builder.Property(a => a.Country)
                .HasMaxLength(20)
                .IsUnicode();

            builder.HasKey(a => a.AddressID)
                .IsClustered()
                .HasName("PK_Address");

            builder.HasIndex(p => new { p.Description, p.City, p.Country })
                .IsUnique()
                .HasDatabaseName("INDX_AddressUnique");

            builder.HasMany(a => a.People)
                .WithOne(a => a.Address)
                .HasForeignKey(a => a.AddressID)
                .HasConstraintName("FK_AddressPeople");
        }
    }
}
