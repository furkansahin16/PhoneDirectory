using PhoneDirectory.Domain.Abstract;
using PhoneDirectory.Domain.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Domain.Concrete.Entities
{
    public class ContactNumber : IEntity
    {
        public int ContactNumberID { get; set; }
        public string Number { get; set; }
        public ContactTypes ContactType { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public override string ToString()
        {
            return Number;
        }


    }
}
