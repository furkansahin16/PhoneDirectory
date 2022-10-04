using PhoneDirectory.Application.Models;
using PhoneDirectory.Application.Services.Abstract;
using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Infrastructure.Abstract;
using PhoneDirectory.Infrastructure.Concrete;


namespace PhoneDirectory.Application.Services.Concrete
{
    public class AddressService : IMainService<AddressDTO>
    {
        private static IAddressRepo _repo;

        public AddressService()
        {
            _repo = new AddressRepo();
        }
        public void Create(AddressDTO model)
        {
            Address address = new Address()
            {
                City = model.City,
                Country = model.Country,
                Description = model.Description,
            };
            _repo.Create(address);
        }

        public void Delete(int id)
        {
            Address address = _repo.Get(id);
            _repo.Delete(address);
        }

        public List<AddressDTO> GetAll()
        {
            return _repo.GetAll().Select(x => new AddressDTO()
            {
                AddressID = x.AddressID,
                Description = x.Description,
                City = x.City,
                Country = x.Country
            }).ToList();
        }

        public void Update(AddressDTO model)
        {
            Address address = new Address()
            {
                AddressID = model.AddressID,
                City = model.City,
                Country = model.Country,
                Description = model.Description
            };
            _repo.Update(address);
        }
    }
}
