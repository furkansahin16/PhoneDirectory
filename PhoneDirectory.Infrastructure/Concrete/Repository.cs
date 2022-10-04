using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Domain.Abstract;
using PhoneDirectory.Domain.Data;
using PhoneDirectory.Infrastructure.Abstract;

namespace PhoneDirectory.Infrastructure.Concrete
{
    public class Repository<T> : IRepository<T> where T : class,IEntity
    {
        private static PhoneDirectoryDB _db;
        private static DbSet<T> _dbSet;

        public Repository()
        {
            if (_db == null)
            {
                _db = new PhoneDirectoryDB();
            }
            _dbSet = _db.Set<T>();
        }

        public void Create(T entity)
        {
            if (!_dbSet.Contains(entity))
            {
                _dbSet.Add(entity);
                _db.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
