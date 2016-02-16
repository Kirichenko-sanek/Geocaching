using Geocaching.Core;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Manager
{
    public class PhotoOfUserManager<T> : Manager<T>, IPhotoOfUserManager<T> where T : PhotoOfUser
    {
        private readonly IPhotoOfUserRepository<PhotoOfUser> _photoOfUserRepository;

        public PhotoOfUserManager(IPhotoOfUserRepository<PhotoOfUser> photoOfUserRepository, IRepository<T> repository,
            IValidator<T> validator) : base(repository, validator)
        {
            _photoOfUserRepository = photoOfUserRepository;
        }

        public PhotoOfUser GetPhotoUserByUserId(long idUser)
        {
            return _photoOfUserRepository.GetPhotoUserByUserId(idUser);
        }
    }
}
