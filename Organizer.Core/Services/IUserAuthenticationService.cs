using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IUserAuthenticationService
    {
        // TODO: make this method a command.
        User LoginUser(string login, string password);
    }
}