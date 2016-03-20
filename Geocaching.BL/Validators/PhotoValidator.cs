using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Validators
{
    public class PhotoValidator:IValidator<Photo>
    {
        private readonly IRepository<Photo> _photoRepository;

        public PhotoValidator(IRepository<Photo> photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public bool IsValid(Photo entyty)
        {
            return IsExists(entyty.id) || entyty.photo_of_caches != null || entyty.photo_of_user != null;
        }

        public bool IsExists(long id)
        {
            return _photoRepository.GetByID(id) != null;
        }
    }
}
