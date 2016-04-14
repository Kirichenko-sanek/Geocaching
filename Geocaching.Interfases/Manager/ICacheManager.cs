using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface ICacheManager<T> : IManager<T> where T : Cache
    {
        IQueryable<Cache> GetCachesByIdUser(long id);

        IQueryable<Cache> Search(string name, double longitude, double latityde, string country, string region,
            string city);

        IQueryable<Cache> SearchCacheUser(long id, string name, double longitude, double latityde,
            string country, string region,
            string city);
    }
}
