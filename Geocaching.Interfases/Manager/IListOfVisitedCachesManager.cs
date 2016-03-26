using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface IListOfVisitedCachesManager<T> : IManager<T> where T : ListOfVisitedCaches
    {
        IQueryable<ListOfVisitedCaches> GetCacheByIdUser(long id);
        IQueryable<ListOfVisitedCaches> GetCacheByIdCache(long id);

        IQueryable<ListOfVisitedCaches> SearchCache(long id, string name, double longitude, double latityde,
            string country, string region,
            string city);
    }
}
