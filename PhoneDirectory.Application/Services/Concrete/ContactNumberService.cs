using PhoneDirectory.Application.Models;
using PhoneDirectory.Application.Services.Abstract;
using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Infrastructure.Abstract;
using PhoneDirectory.Infrastructure.Concrete;

namespace PhoneDirectory.Application.Services.Concrete
{
    public class ContactNumberService : IMainService<ContactNumberDTO>
    {
        private static IContactNumberRepo _repo;
        public ContactNumberService()
        {
            _repo = new ContactNumberRepo();
        }
        public void Create(ContactNumberDTO model)
        {
            ContactNumber number = new ContactNumber()
            {
                Number = model.Number,
                ContactType = model.ContactType,
                PersonID = model.PersonID,
            };
            _repo.Create(number);
        }

        public void Delete(int id)
        {
            ContactNumber number = _repo.Get(id);
            _repo.Delete(number);
        }

        public List<ContactNumberDTO> GetAll()
        {
            return _repo.GetAll().Select(x => new ContactNumberDTO()
            {
                ContactNumberID = x.ContactNumberID,
                Number = x.Number,
                ContactType = x.ContactType,
                PersonID = x.PersonID
            }).ToList();
        }

        public void Update(ContactNumberDTO model)
        {
            ContactNumber number = new ContactNumber()
            {
                ContactNumberID = model.ContactNumberID,
                Number = model.Number,
                ContactType = model.ContactType,
                PersonID = model.PersonID
            };
            _repo.Update(number);
        }
    }
}
