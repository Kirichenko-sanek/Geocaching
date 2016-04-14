using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Repository
{
    public interface IPhotoOfCachesRepository<T> : IRepository<T> where T : PhotoOfCaches
    {
        IQueryable<PhotoOfCaches> GetPhotoOfCachesByCacheId(long idCache);
        PhotoOfCaches GetPhootOfCachesByPhoto(long idPhoto);
    }
}
