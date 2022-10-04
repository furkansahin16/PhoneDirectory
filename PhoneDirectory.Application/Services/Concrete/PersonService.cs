using PhoneDirectory.Application.Models;
using PhoneDirectory.Application.Services.Abstract;
using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Infrastructure.Abstract;
using PhoneDirectory.Infrastructure.Concrete;


namespace PhoneDirectory.Application.Services.Concrete
{
    public class PersonService : IMainService<PersonDTO>
    {
        private static IPersonRepo _repo;
        public PersonService()
        {
            _repo = new PersonRepo();
        }
        public void Create(PersonDTO model)
        {
            Person person = new Person()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                NickName = model.NickName,
                AddressID = model.AddressID,
                BirthDate = model.BirthDate,
                Description = model.Description
            };

            _repo.Create(person);
        }

        public void Delete(int id)
        {
            Person person = _repo.Get(id);
            _repo.Delete(person);
        }

        public List<PersonDTO> GetAll()
        {
            return _repo.GetAll().Select(x => new PersonDTO()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                NickName = x.NickName,
                BirthDate = x.BirthDate,
                Description = x.Description
            }
            ).ToList();
        }

        public void Update(PersonDTO model)
        {
            Person person = new Person()
            {
                PersonID = model.PersonID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                NickName = model.NickName,
                BirthDate = model.BirthDate,
                Description = model.Description,
                AddressID = model.AddressID
            };

            _repo.Update(person);
        }
    }
}
