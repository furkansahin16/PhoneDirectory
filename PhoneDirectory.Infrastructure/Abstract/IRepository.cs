using PhoneDirectory.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Infrastructure.Abstract
{
    public interface IRepository<T> where T : class,IEntity
    {
        void Create (T entity);
        void Update (T entity);
        void Delete (T entity);
        IQueryable<T> GetAll ();
        T Get (int id);
    }
}
