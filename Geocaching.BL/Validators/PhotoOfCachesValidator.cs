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
    public class PhotoOfCachesValidator : IValidator<PhotoOfCaches>
    {
        private readonly IRepository<PhotoOfCaches> _photoOfCachesRepository;

        public PhotoOfCachesValidator(IRepository<PhotoOfCaches> photoOfCachesRepository)
        {
            _photoOfCachesRepository = photoOfCachesRepository;
        }

        public bool IsValid(PhotoOfCaches entity)
        {
            return IsExists(entity.id) || IsExists(entity.id_cache);
        }

        public bool IsExists(long id)
        {
            return _photoOfCachesRepository.GetByID(id) != null;
        }
    }
}
