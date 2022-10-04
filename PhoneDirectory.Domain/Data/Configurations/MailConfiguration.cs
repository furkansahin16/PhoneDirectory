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
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder.Property(m => m.MailID)
                .IsRequired()
                .UseIdentityColumn(1, 1);

            builder.Property(m => m.MailAdress)
                .HasMaxLength(30);

            builder.Property(m => m.MailType)
                .HasColumnType("nvarchar(20)")
                .HasConversion(m=>m.ToString(),m => (MailTypes)Enum.Parse(typeof(MailTypes),m));

            builder.HasKey(m => m.MailID)
                .IsClustered()
                .HasName("PK_Mail");

            builder.HasOne(m => m.Person)
                .WithMany(m => m.Mails)
                .HasForeignKey(m => m.PersonID)
                .HasConstraintName("FK_PersonMails");
        }
    }
}
