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
    public class GroupConfiguration : IEntityTypeConfiguration<PersonGroup>
    {
        public void Configure(EntityTypeBuilder<PersonGroup> builder)
        {
            builder.ToTable("Group");

            builder.Property(g => g.GroupID)
                .IsRequired()
                .UseIdentityColumn(1, 1);

            builder.Property(g => g.GroupName)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasKey(g => g.GroupID)
                .IsClustered()
                .HasName("PK_Group");

            builder.HasMany(g => g.People)
                .WithMany(g => g.Groups);
        }
    }
}
