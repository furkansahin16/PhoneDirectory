using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Domain.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Domain.Data
{
    public class PhoneDirectoryDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J37MVVO\SQLSERVER2019;Initial Catalog=PhoneDirectory;Integrated Security=True").UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressConfiguration().Configure(modelBuilder.Entity<Address>());
            new PersonConfiguration().Configure(modelBuilder.Entity<Person>());
            new GroupConfiguration().Configure(modelBuilder.Entity<PersonGroup>());
            new ContactNumberConfiguration().Configure(modelBuilder.Entity<ContactNumber>());
            new MailConfiguration().Configure(modelBuilder.Entity<Mail>());
        }
        public DbSet<Person> People { get; set; }
        public DbSet<ContactNumber> ContactNumbers { get; set; }
        public DbSet<PersonGroup> Groups { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Mail> Mail { get; set; }
    }
}
