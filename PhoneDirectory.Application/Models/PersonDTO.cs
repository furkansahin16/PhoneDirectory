namespace PhoneDirectory.Application.Models
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public int AddressID { get; set; }
    }
}
