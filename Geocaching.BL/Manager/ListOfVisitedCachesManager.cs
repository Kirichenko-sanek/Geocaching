using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Manager
{
    public class ListOfVisitedCachesManager<T> : Manager<T>,IListOfVisitedCachesManager<T> where T : ListOfVisitedCaches
    {
        private readonly IListOfVisitedCachesRepository<ListOfVisitedCaches> _listOfVisitedCachesRepository;

        public ListOfVisitedCachesManager(
            IListOfVisitedCachesRepository<ListOfVisitedCaches> listOfVisitedCachesRepository, IRepository<T> repository,
            IValidator<T> validator) : base(repository, validator)
        {
            _listOfVisitedCachesRepository = listOfVisitedCachesRepository;
        }

        public IQueryable<ListOfVisitedCaches> GetCacheByIdUser(long id)
        {
            return _listOfVisitedCachesRepository.GetCacheByIdUser(id);
        }

        public IQueryable<ListOfVisitedCaches> GetCacheByIdCache(long id)
        {
            return _listOfVisitedCachesRepository.GetCacheByIdCache(id);
        }

        public IQueryable<ListOfVisitedCaches> SearchCache(long id, string name, double longitude, double latityde,
            string country, string region,
            string city)
        {
            return _listOfVisitedCachesRepository.SearchCache(id, name, longitude, latityde, country, region, city);
        }
    }
}
