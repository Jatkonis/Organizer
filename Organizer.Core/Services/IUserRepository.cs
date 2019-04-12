using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IUserRepository
    {
        void AddUser(User newUser);
        User GetUsersByLogin(string login);
    }
}