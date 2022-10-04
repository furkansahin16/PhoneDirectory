using PhoneDirectory.Domain.Abstract;

namespace PhoneDirectory.Domain.Concrete.Entities
{
    public class Person : IEntity
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<ContactNumber> ContactNumbers { get; set; } = null!;
        public virtual ICollection<PersonGroup> Groups { get; set; }
        public virtual ICollection<Mail> Mails { get; set; }
        public Person()
        {
            ContactNumbers = new HashSet<ContactNumber>();
            Groups = new HashSet<PersonGroup>();
            Mails = new HashSet<Mail>();
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
