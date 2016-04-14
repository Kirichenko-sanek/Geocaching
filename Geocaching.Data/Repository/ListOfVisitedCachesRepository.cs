using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class ListOfVisitedCachesRepository<T> : Repository<T>, IListOfVisitedCachesRepository<T> where T : ListOfVisitedCaches
    {
        public ListOfVisitedCachesRepository(DataContext context) : base(context)
        {
            
        }

        public IQueryable<ListOfVisitedCaches> GetCacheByIdUser(long id)
        {
            return _context.ListOfVisitedCaches.Where(x => x.id_user == id);
        }

        public IQueryable<ListOfVisitedCaches> GetCacheByIdCache(long id)
        {
            return _context.ListOfVisitedCaches.Where(x => x.id_cache == id);
        }

        public IQueryable<ListOfVisitedCaches> SearchCache(long id, string name, double longitude, double latityde,
            string country, string region,
            string city)
        {
            return
                _context.ListOfVisitedCaches.Where(
                    x =>
                        (x.id_user == id) &&
                        (x.cache.name == name || x.cache.address.longitude == longitude ||
                         x.cache.address.latitude == latityde || x.cache.address.country == country ||
                         x.cache.address.region == region || x.cache.address.city == city));
        }
    }
}
