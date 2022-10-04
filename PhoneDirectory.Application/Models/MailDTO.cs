using PhoneDirectory.Domain.Concrete.Enums;


namespace PhoneDirectory.Application.Models
{
    public class MailDTO
    {
        public int MailID { get; set; }
        public string MailAdress { get; set; }
        public MailTypes MailType { get; set; }
        public int PersonID { get; set; }
    }
}
