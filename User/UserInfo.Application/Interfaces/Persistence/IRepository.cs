using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo.Application.Interfaces.Persistence
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T Get(int id);
        IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> where);
        void Add(T entity);

        void Remove(T entity);
    }
}
