using PhoneDirectory.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Domain.Concrete.Entities
{
    public class PersonGroup : IEntity
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public PersonGroup()
        {
            People = new HashSet<Person>();
        }
        public override string ToString()
        {
            return GroupName;
        }
    }
}
