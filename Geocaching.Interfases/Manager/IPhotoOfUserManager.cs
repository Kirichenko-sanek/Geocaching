using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface IPhotoOfUserManager<T> : IManager<T> where T : PhotoOfUser
    {
        PhotoOfUser GetPhotoUserByUserId(long idUser);
        IQueryable<PhotoOfUser> GetPhotoUser(long idUser);
    }
}
