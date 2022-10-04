using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Application.Services.Abstract
{
    public interface IMainService<T>
    {
        List<T> GetAll();
        void Create(T model);
        void Update(T model);
        void Delete(int id);
    }
}
