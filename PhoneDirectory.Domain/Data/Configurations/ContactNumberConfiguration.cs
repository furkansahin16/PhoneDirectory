using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Domain.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Domain.Data.Configurations
{
    public class ContactNumberConfiguration : IEntityTypeConfiguration<ContactNumber>
    {
        public void Configure(EntityTypeBuilder<ContactNumber> builder)
        {
            builder.Property(n => n.ContactNumberID)
                .IsRequired()
                .UseIdentityColumn(1, 1);

            builder.Property(n => n.Number)
                .HasMaxLength(15);

            builder.Property(n => n.ContactType)
                .HasColumnType("nvarchar(20)")
                .HasConversion(n => n.ToString(),n => (ContactTypes)Enum.Parse(typeof(ContactTypes),n));

            builder.HasKey(n => n.ContactNumberID)
                .HasName("PK_Number")
                .IsClustered();

            builder.HasIndex(n => n.Number)
                .IsUnique()
                .HasDatabaseName("INDX_ContactNumber");

            builder.HasOne(n => n.Person)
                .WithMany(n => n.ContactNumbers)
                .HasForeignKey(n => n.PersonID)
                .HasConstraintName("FK_People_Phones");
        }
    }
}
