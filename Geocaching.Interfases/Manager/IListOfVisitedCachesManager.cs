using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface IListOfVisitedCachesManager<T> : IManager<T> where T : ListOfVisitedCaches
    {
        IQueryable<ListOfVisitedCaches> GetCacheByIdUser(long id);
    }
}
