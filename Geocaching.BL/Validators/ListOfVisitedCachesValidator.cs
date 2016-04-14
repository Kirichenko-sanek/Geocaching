using Geocaching.Core;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Validators
{
    public class ListOfVisitedCachesValidator :IValidator<ListOfVisitedCaches>
    {
        private readonly IRepository<ListOfVisitedCaches> _listOfVsitedCacheRepository;

        public ListOfVisitedCachesValidator(IRepository<ListOfVisitedCaches> listOfVsitedCacheRepository)
        {
            _listOfVsitedCacheRepository = listOfVsitedCacheRepository;
        }

        public bool IsValid(ListOfVisitedCaches entyty)
        {
            return IsExists(entyty.id_user)
                || IsExists(entyty.id_cache);
        }

        public bool IsExists(long id)
        {
            return _listOfVsitedCacheRepository.GetByID(id) != null;
        }
    }
}
