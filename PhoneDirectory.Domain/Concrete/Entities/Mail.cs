using PhoneDirectory.Domain.Abstract;
using PhoneDirectory.Domain.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Domain.Concrete.Entities
{
    public class Mail : IEntity
    {
        public int MailID { get; set; }
        public string MailAdress { get; set; }
        public MailTypes MailType { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public override string ToString()
        {
            return MailAdress;
        }





    }
}
