using PhoneDirectory.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Domain.Concrete.Entities
{
    public class Address : IEntity
    {
        public int AddressID { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public Address()
        {
            People = new HashSet<Person>();
        }
        public override string ToString()
        {
            return Description.Substring(0, 20);
        }
    }
}
