using Geocaching.Core;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Validators
{
    public class CacheValidator :IValidator<Cache>
    {
        private readonly IRepository<Cache> _cacheRepository;

        public CacheValidator(IRepository<Cache> cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public bool IsValid(Cache entyty)
        {
            return IsExists(entyty.id_user) || IsExists(entyty.id) || entyty.address != null ;

        }

        public bool IsExists(long id)
        {
            return _cacheRepository.GetByID(id) != null;
        }
    }
}
