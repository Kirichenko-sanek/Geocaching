using Geocaching.Core;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Validators
{
    public class PhotoOfUserValidator : IValidator<PhotoOfUser>
    {
        private readonly IRepository<PhotoOfUser> _photoOfUserRepository;

        public PhotoOfUserValidator(IRepository<PhotoOfUser> photoOfUserRepository)
        {
            _photoOfUserRepository = photoOfUserRepository;
        }

        public bool IsValid(PhotoOfUser entity)
        {
            return IsExists(entity.id_user)
                   && entity.photo != null;
        }

        public bool IsExists(long id)
        {
            return _photoOfUserRepository.GetByID(id) != null;
        }
    }
}
