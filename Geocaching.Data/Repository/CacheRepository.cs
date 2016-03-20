using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;


namespace Geocaching.Data.Repository
{
    public class CacheRepository<T> : Repository<T>, ICacheRepository<T> where T : Cache
    {
        public CacheRepository(DataContext context) : base(context)
        {
            
        }

        public IQueryable<Cache> GetCachesByIdUser(long id)
        {
            return _context.Caches.Where(x => x.id_user == id);
        }

        public IQueryable<Cache> Search(string name, double longitude, double latityde, string country, string region,
            string city)
        {
            return
                _context.Caches.Where(
                    x =>
                        (x.name == name || x.address.longitude == longitude || x.address.latitude == latityde ||
                         x.address.country == country || x.address.region == region || x.address.city == city));
        }
    }
}
