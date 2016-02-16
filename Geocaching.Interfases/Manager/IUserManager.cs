using Geocaching.Core;

namespace Geocaching.Interfases.Manager
{
    public interface IUserManager<T> : IManager<T> where T : User
    {
        User GetUserByEmail(string email);
        void SentConfirmMail(T entity, string url);
        void SendPassRecovery(T entity, string newPassword);
        void ActivateUser(T enity);
    }
}
