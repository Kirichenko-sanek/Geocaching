using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Repository
{
    public interface ICommentRepository<T> : IRepository<T> where T : Comment
    {
        IQueryable<Comment> GetCommentsByCacheId(long id);
    }
}
