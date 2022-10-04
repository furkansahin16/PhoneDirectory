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
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");

            builder.Property(p => p.PersonID)
                .IsRequired()
                .UseIdentityColumn(1, 1);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(p => p.NickName)
                .HasMaxLength(30);

            builder.Property(p => p.Description)
                .HasMaxLength(30);

            builder.Property(p => p.BirthDate)
                .HasColumnType("date");

            builder.HasKey(p => p.PersonID)
                .IsClustered()
                .HasName("PK_People");

            builder.HasIndex(p => new { p.FirstName, p.LastName })
                .HasDatabaseName("INDX_People_NameOrder");

            builder.HasIndex(p => p.NickName)
                .IsUnique()
                .HasDatabaseName("INDX_People_NickName");

            builder.HasOne(p => p.Address)
                .WithMany(p => p.People)
                .HasForeignKey(p => p.AddressID);

            builder.HasMany(p => p.ContactNumbers)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonID)
                .IsRequired()
                .HasConstraintName("FK_Person_Phones");

            builder.HasMany(p => p.Mails)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonID);

            builder.HasMany(p => p.Groups)
                .WithMany(g => g.People);
        }
    }
}
