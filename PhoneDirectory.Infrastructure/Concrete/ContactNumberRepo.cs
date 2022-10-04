using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Infrastructure.Abstract;

namespace PhoneDirectory.Infrastructure.Concrete
{
    public class ContactNumberRepo : Repository<ContactNumber>, IContactNumberRepo { }
}
