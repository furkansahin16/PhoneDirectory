using PhoneDirectory.Domain.Concrete.Enums;


namespace PhoneDirectory.Application.Models
{
    public class ContactNumberDTO
    {
        public int ContactNumberID { get; set; }
        public string Number { get; set; }
        public ContactTypes ContactType { get; set; }
        public int PersonID { get; set; }
    }
}
