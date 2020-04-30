using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorksSehirRehberi.API.Data
{
    public class AppRepository<T> : IAppRepository<T> where T : class
    {
        private DataContext _db = new DataContext(new DbContextOptions<DataContext>());
        private DbSet<T> _context;

        public AppRepository(DataContext context)
        {
            _context = _db.Set<T>();
        }


        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public bool SaveAll()
        {
            return _db.SaveChanges() > 0;
        }

        public List<T> GetList()
        {
            return _context.ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> filter)
        {
            return _context.Where(filter).ToList();
        }

        public List<T> GetByIdList(int id)
        {
            return _context.ToList();
        }

        public T GetItem(int id)
        {
            return _context.Find(id);
        }

        public T GetItem(Expression<Func<T, bool>> filter)
        {
            return _context.FirstOrDefault(filter);
        }

        public IQueryable<T> Queryable()
        {
            return _context.AsQueryable();
        }
    }
}
