using ProductManagerApp.Domain.Core;

namespace ProductManagerApp.Domain.Interfaces
{
    public interface IAuth
    {
        User GetByCredentials(string email, string password);
        User GetByEmail(string email);
        void AddNewUser(User user);
    }
}
