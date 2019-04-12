using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IUserLoginStatusService
    {
        // TODO: make this work with user object as opposed to user id.
        void SetLoggedInUser(User user);
        int GetLoggedInUserId();
        void LogOut();
    }
}
