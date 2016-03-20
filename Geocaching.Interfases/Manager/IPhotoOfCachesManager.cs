using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface IPhotoOfCachesManager<T> : IManager<T> where T : PhotoOfCaches
    {
        IQueryable<PhotoOfCaches> GetPhotoOfCachesByCacheId(long idCache);
        PhotoOfCaches GetPhootOfCachesByPhoto(long idPhoto);
    }
}
