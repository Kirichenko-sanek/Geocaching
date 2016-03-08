using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface ICommentsManager<T> : IManager<T> where T : Comment
    {
        IQueryable<Comment> GetCommentsByCacheId(long id);
    }
}
