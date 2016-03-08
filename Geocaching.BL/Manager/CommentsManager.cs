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
    public class CommentsManager<T> : Manager<T>, ICommentsManager<T> where T : Comment
    {
        private readonly ICommentRepository<Comment> _commentRepository;

        public CommentsManager(ICommentRepository<Comment> commentRepository, IRepository<T> repository,
            IValidator<T> validator) : base(repository, validator)
        {
            _commentRepository = commentRepository;
        }

        public IQueryable<Comment> GetCommentsByCacheId(long id)
        {
            return _commentRepository.GetCommentsByCacheId(id);
        }
    }
}
