using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Document.Application.Interfaces.Persistence;
using Document.Domain.Entities.Common;

namespace Document.Persistence.Shared
{
    public class Repository<T>
        : IRepository<T>
        where T : class, IEntity

    {
        private readonly ApplicationDbContext _database;

        public Repository(ApplicationDbContext database)
        {
            _database = database;
        }

        public IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public T Get(int id)
        {
            return _database.Set<T>()
                .Single(p => p.Id == id);
        }
        public virtual IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> where)
        {
            return _database.Set<T>().Where(where).AsQueryable();
        }

        public void Add(T entity)
        {
            _database.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
        }
    }
}