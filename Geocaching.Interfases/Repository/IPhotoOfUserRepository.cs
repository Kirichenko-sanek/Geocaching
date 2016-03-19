using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;

namespace Geocaching.Interfases.Repository
{
    public interface IPhotoOfUserRepository<T> : IRepository<T> where T : PhotoOfUser
    {
        PhotoOfUser GetPhotoUserByUserId(long idUser);
        IQueryable<PhotoOfUser> GetPhotoUser(long idUser);
    }
}
