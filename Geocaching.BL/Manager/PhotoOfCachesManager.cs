using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Manager
{
    public class PhotoOfCachesManager<T> : Manager<T>, IPhotoOfCachesManager<T> where T : PhotoOfCaches
    {
        private readonly IPhotoOfCachesRepository<PhotoOfCaches> _photoOfCachesRepository;

        public PhotoOfCachesManager(IPhotoOfCachesRepository<PhotoOfCaches> photoOfCachesRepository,
            IRepository<T> repository, IValidator<T> validator) : base(repository, validator)
        {
            _photoOfCachesRepository = photoOfCachesRepository;
        }

        public IQueryable<PhotoOfCaches> GetPhotoOfCachesByCacheId(long idCache)
        {
            return _photoOfCachesRepository.GetPhotoOfCachesByCacheId(idCache);
        }

        public PhotoOfCaches GetPhootOfCachesByPhoto(long idPhoto)
        {
            return _photoOfCachesRepository.GetPhootOfCachesByPhoto(idPhoto);
        }
    }
}
