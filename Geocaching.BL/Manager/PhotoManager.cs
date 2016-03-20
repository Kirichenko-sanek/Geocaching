using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Manager
{
    public class PhotoManager<T> : Manager<T>, IPhotoManager<T> where T : Photo
    {
        private readonly IPhotoRepository<Photo> _photoRepository;

        public PhotoManager(IPhotoRepository<Photo> photoRepository, IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
            _photoRepository = photoRepository;
        }  
    }
}
