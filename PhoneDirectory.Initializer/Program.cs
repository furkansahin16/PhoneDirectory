// See https://aka.ms/new-console-template for more information

using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Domain.Data;
using System.Text.RegularExpressions;

Console.WriteLine("Database Seed Data Entry Started");

CreateSeedData();

Console.WriteLine("Database Seed Data Entry Ended");

Console.ReadKey();

void CreateSeedData()
{
    using (var db = new PhoneDirectoryDB())
    {
        Person furkan;
        ContactNumber furkanNumber;
        PersonGroup bilgeAdam;
        Address furkanAddress;
        Mail furkanMail;

        try
        {
            furkan = db.People
                .Where(x => x.FirstName == "Furkan" && x.LastName == "Şahin" && x.NickName == "sahfur")
                .First();
        }
        catch (Exception)
        {
            furkan = new Person()
            {
                FirstName = "Furkan"
                , LastName = "Şahin"
                , NickName = "sahfur"
                , Description = "Owner"
                , BirthDate = Convert.ToDateTime("16/10/1997")
            };

            db.People.Add(furkan);
        }

        try
        {
            furkanNumber = db.ContactNumbers
                .Where(x => x.Number == "05066057431")
                .First();

            furkanNumber.Person = furkan;
            furkanNumber.ContactType = PhoneDirectory.Domain.Concrete.Enums.ContactTypes.Mobile;
        }
        catch (Exception)
        {
            furkanNumber = new ContactNumber()
            {
                Number = "05066057431"
                , ContactType = PhoneDirectory.Domain.Concrete.Enums.ContactTypes.Mobile
                , Person = furkan
            };

            db.ContactNumbers.Add(furkanNumber);
        }

        furkanAddress = new Address()
        {
            Description = "Yeniay Sokak."
            ,City = "İstanbul"
            ,Country = "Türkiye"
        };

        if (!db.Address.Contains(furkanAddress))
        {
            db.Address.Add(furkanAddress);
        }

        bilgeAdam = new PersonGroup()
        {
            GroupName = "BilgeAdam"
        };

        if (!db.Groups.Contains(bilgeAdam))
        {
            db.Groups.Add(bilgeAdam);
        }

        furkanMail = new Mail()
        {
            MailAdress = "furkansahin1610@gmail.com"
            , MailType = PhoneDirectory.Domain.Concrete.Enums.MailTypes.Home
            , Person = furkan
        };

        if (!db.Mail.Contains(furkanMail))
        {
            db.Mail.Add(furkanMail);
        }

        bilgeAdam.People.Add(furkan);
        furkanAddress.People.Add(furkan);
        furkan.Mails.Add(furkanMail);
        furkan.Address = furkanAddress;
        furkan.ContactNumbers.Add(furkanNumber);
        furkan.Groups.Add(bilgeAdam);

        db.SaveChanges();
    }
}
