using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Repository;

namespace Geocaching.Data.Repository
{
    public class CommentRepository<T> : Repository<T>, ICommentRepository<T> where T : Comment
    {
        public CommentRepository(DataContext context) : base(context)
        {
            
        }

        public IQueryable<Comment> GetCommentsByCacheId(long id)
        {
            return _context.Comments.Where(x => x.id_cache == id);
        }
    }
}
