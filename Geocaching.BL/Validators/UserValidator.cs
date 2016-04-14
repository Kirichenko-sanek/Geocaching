using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Validators
{
    public class UserValidator : IValidator<User>
    {
        private readonly IRepository<User> _userRepository;

        public UserValidator(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsValid(User entity)
        {
            return _userRepository.GetAll().FirstOrDefault(m => m.email == entity.email) == null
                  && !string.IsNullOrEmpty(entity.first_name)
                  && !string.IsNullOrEmpty(entity.last_name)
                  && !string.IsNullOrEmpty(entity.email)
                  && !string.IsNullOrEmpty(entity.password)
                  && !string.IsNullOrEmpty(entity.password_salt);
        }

        public bool IsExists(long id)
        {
            return _userRepository.GetByID(id) != null;
        }
    }
}
