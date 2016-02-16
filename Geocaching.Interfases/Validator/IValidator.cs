using Geocaching.Core;

namespace Geocaching.Interfases.Validator
{
    public interface IValidator<in T> where T : BaseEntity
    {
        bool IsValid(T entity);
        bool IsExists(long id);
    }
}
