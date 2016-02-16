using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Interfases.Repository;
using Geocaching.Core;

namespace Geocaching.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private readonly IDbSet<T> _entities;

        public Repository(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public void Add(T entity)
        {
            _entities.Add(entity);
        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
        public IQueryable<T> GetAll()
        {
            return _entities;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            Save();
        }
        public T GetByID(long id)
        {
            return _entities.Find(id);
        }
    }
}
