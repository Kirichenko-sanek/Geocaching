using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocaching.Core;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Validators
{
    public class CommentsValidator : IValidator<Comment>
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentsValidator(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public bool IsValid(Comment entity)
        {
            return IsExists(entity.id_user)
                   && IsExists(entity.id_cache)
                   || IsExists(entity.id);
        }

        public bool IsExists(long id)
        {
            return _commentRepository.GetByID(id) != null;
        }
    }
}
