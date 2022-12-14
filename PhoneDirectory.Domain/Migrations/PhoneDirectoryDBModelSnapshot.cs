// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneDirectory.Domain.Data;

#nullable disable

namespace PhoneDirectory.Domain.Migrations
{
    [DbContext(typeof(PhoneDirectoryDB))]
    partial class PhoneDirectoryDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PersonPersonGroup", b =>
                {
                    b.Property<int>("GroupsGroupID")
                        .HasColumnType("int");

                    b.Property<int>("PeoplePersonID")
                        .HasColumnType("int");

                    b.HasKey("GroupsGroupID", "PeoplePersonID");

                    b.HasIndex("PeoplePersonID");

                    b.ToTable("PersonPersonGroup");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("AddressID")
                        .HasName("PK_Address");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("AddressID"));

                    b.HasIndex("Description", "City", "Country")
                        .IsUnique()
                        .HasDatabaseName("INDX_AddressUnique");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.ContactNumber", b =>
                {
                    b.Property<int>("ContactNumberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactNumberID"), 1L, 1);

                    b.Property<string>("ContactType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("ContactNumberID")
                        .HasName("PK_Number");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ContactNumberID"));

                    b.HasIndex("Number")
                        .IsUnique()
                        .HasDatabaseName("INDX_ContactNumber");

                    b.HasIndex("PersonID");

                    b.ToTable("ContactNumbers");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.Mail", b =>
                {
                    b.Property<int>("MailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MailID"), 1L, 1);

                    b.Property<string>("MailAdress")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MailType")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("MailID")
                        .HasName("PK_Mail");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MailID"));

                    b.HasIndex("PersonID");

                    b.ToTable("Mail");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"), 1L, 1);

                    b.Property<int>("AddressID")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PersonID")
                        .HasName("PK_People");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("PersonID"));

                    b.HasIndex("AddressID");

                    b.HasIndex("NickName")
                        .IsUnique()
                        .HasDatabaseName("INDX_People_NickName");

                    b.HasIndex("FirstName", "LastName")
                        .HasDatabaseName("INDX_People_NameOrder");

                    b.ToTable("People", (string)null);
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.PersonGroup", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"), 1L, 1);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GroupID")
                        .HasName("PK_Group");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("GroupID"));

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("PersonPersonGroup", b =>
                {
                    b.HasOne("PhoneDirectory.Domain.Concrete.Entities.PersonGroup", null)
                        .WithMany()
                        .HasForeignKey("GroupsGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PhoneDirectory.Domain.Concrete.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PeoplePersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.ContactNumber", b =>
                {
                    b.HasOne("PhoneDirectory.Domain.Concrete.Entities.Person", "Person")
                        .WithMany("ContactNumbers")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_People_Phones");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.Mail", b =>
                {
                    b.HasOne("PhoneDirectory.Domain.Concrete.Entities.Person", "Person")
                        .WithMany("Mails")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PersonMails");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.Person", b =>
                {
                    b.HasOne("PhoneDirectory.Domain.Concrete.Entities.Address", "Address")
                        .WithMany("People")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AddressPeople");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.Address", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Concrete.Entities.Person", b =>
                {
                    b.Navigation("ContactNumbers");

                    b.Navigation("Mails");
                });
#pragma warning restore 612, 618
        }
    }
}
