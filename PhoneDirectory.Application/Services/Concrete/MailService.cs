using PhoneDirectory.Application.Models;
using PhoneDirectory.Application.Services.Abstract;
using PhoneDirectory.Domain.Concrete.Entities;
using PhoneDirectory.Infrastructure.Abstract;
using PhoneDirectory.Infrastructure.Concrete;

namespace PhoneDirectory.Application.Services.Concrete
{
    public class MailService : IMainService<MailDTO>
    {
        private static IMailRepo _repo;
        public MailService()
        {
            _repo = new MailRepo();
        }
        public void Create(MailDTO model)
        {
            Mail mail = new Mail()
            {
                MailType = model.MailType,
                MailAdress = model.MailAdress,
                PersonID = model.PersonID
            };
            _repo.Create(mail);
        }

        public void Delete(int id)
        {
            Mail mail = _repo.Get(id);
            _repo.Delete(mail);
        }

        public List<MailDTO> GetAll()
        {
            return _repo.GetAll().Select(x => new MailDTO()
            {
                MailType = x.MailType,
                MailAdress = x.MailAdress,
                MailID = x.MailID,
                PersonID = x.PersonID
            }).ToList();
        }

        public void Update(MailDTO model)
        {
            Mail mail = new Mail()
            {
                MailID = model.MailID,
                MailAdress = model.MailAdress,
                MailType = model.MailType
            };
            _repo.Update(mail);
        }
    }
}
