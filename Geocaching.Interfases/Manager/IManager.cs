using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface IManager<T> where T : BaseEntity
    {
        void Add(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        void Save();
        void Update(T entity);
        T GetById(long id);        
    }
}
