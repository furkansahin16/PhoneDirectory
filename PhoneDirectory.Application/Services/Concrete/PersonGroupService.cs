using PhoneDirectory.Application.Models;
using PhoneDirectory.Application.Services.Abstract;
using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Infrastructure.Abstract;
using PhoneDirectory.Infrastructure.Concrete;
using System.Security.Cryptography.X509Certificates;

namespace PhoneDirectory.Application.Services.Concrete
{
    public class PersonGroupService : IMainService<PersonGroupDTO>
    {
        private static IPersonGroupRepo _repo;
        public PersonGroupService()
        {
            _repo = new PersonGroupRepo();
        }
        public void Create(PersonGroupDTO model)
        {
            PersonGroup group = new PersonGroup()
            {
                GroupName = model.GroupName
            };
            _repo.Create(group);
        }

        public void Delete(int id)
        {
            PersonGroup group = _repo.Get(id);
            _repo.Delete(group);
        }

        public List<PersonGroupDTO> GetAll()
        {
            return _repo.GetAll().Select(x => new PersonGroupDTO()
            {
                GroupID = x.GroupID,
                GroupName = x.GroupName
            })
            .ToList();
        }

        public void Update(PersonGroupDTO model)
        {
            PersonGroup group = new PersonGroup()
            {
                GroupID = model.GroupID,
                GroupName = model.GroupName
            };
            _repo.Update(group);
        }
    }
}
