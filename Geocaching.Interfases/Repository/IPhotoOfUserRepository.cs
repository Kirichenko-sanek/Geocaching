using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Repository
{
    public interface IPhotoOfUserRepository<T> : IRepository<T> where T : PhotoOfUser
    {
        PhotoOfUser GetPhotoUserByUserId(long idUser);
        IQueryable<PhotoOfUser> GetPhotoUser(long idUser);
        PhotoOfUser GetPhootOfUserByPhoto(long idPhoto);
    }
}
