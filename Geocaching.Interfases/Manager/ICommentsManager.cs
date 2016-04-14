using System.Linq;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface ICommentsManager<T> : IManager<T> where T : Comment
    {
        IQueryable<Comment> GetCommentsByCacheId(long id);
    }
}
