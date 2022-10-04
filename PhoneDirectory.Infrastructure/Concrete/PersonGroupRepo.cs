using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Infrastructure.Abstract;

namespace PhoneDirectory.Infrastructure.Concrete
{
    public class PersonGroupRepo : Repository<PersonGroup>, IPersonGroupRepo { }
}
