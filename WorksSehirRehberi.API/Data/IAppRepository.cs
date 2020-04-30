using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WorksSehirRehberi.API.Data
{
    public interface IAppRepository<T> : IDisposable where T:class
    {
        void Insert(T entity);
        void Delete(T entity);
        bool SaveAll();

        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> filter);
        List<T> GetByIdList(int id);
        T GetItem(int id);
        T GetItem(Expression<Func<T, bool>> filter);
        IQueryable<T> Queryable();
    }
}
