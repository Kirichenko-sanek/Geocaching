using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface IPhotoOfUserManager<T> : IManager<T> where T : PhotoOfUser
    {
        PhotoOfUser GetPhotoUserByUserId(long idUser);
    }
}
