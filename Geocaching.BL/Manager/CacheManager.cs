using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Manager
{
    public class CacheManager<T> : Manager<T>, ICacheManager<T> where T : Cache
    {
        private readonly ICacheRepository<Cache> _cacheRepository; 

        public CacheManager(ICacheRepository<Cache> cacheRepository,IRepository<T> repository,IValidator<T> validator) : base(repository, validator)
        {
            _cacheRepository = cacheRepository;
        }

        public IQueryable<Cache> GetCachesByIdUser(long id)
        {
            return _cacheRepository.GetCachesByIdUser(id);
        }

        public IQueryable<Cache> Search(string name, double longitude, double latityde, string country, string region,
            string city)

        {
            return _cacheRepository.Search(name, longitude, latityde, country, region, city);
        }

        public IQueryable<Cache> SearchCacheUser(long id, string name, double longitude, double latityde,
            string country, string region,
            string city)
        {
            return _cacheRepository.SearchCacheUser(id, name, longitude, latityde, country, region, city);
        }
    }
}
