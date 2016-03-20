using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class PhotoOfUserRepository<T> : Repository<T>, IPhotoOfUserRepository<T> where T : PhotoOfUser
    {
        public PhotoOfUserRepository(DataContext context) : base(context)
        {
            
        }

        public PhotoOfUser GetPhotoUserByUserId(long idUser)
        {
            return _context.PhotoOfUser.FirstOrDefault(x => (x.id_user == idUser && x.main_photo == true));
        }

        public IQueryable<PhotoOfUser> GetPhotoUser(long idUser)
        {
            return _context.PhotoOfUser.Where(x => (x.id_user == idUser && x.main_photo == false));
        }

        public PhotoOfUser GetPhootOfUserByPhoto(long idPhoto)
        {
            return _context.PhotoOfUser.FirstOrDefault(x => x.id_photo == idPhoto);
        }
    }
}
