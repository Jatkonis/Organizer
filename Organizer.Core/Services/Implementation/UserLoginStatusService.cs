using Organizer.Core.Models;

namespace Organizer.Core.Services.Implementation
{
    public class UserLoginStatusService : IUserLoginStatusService
    {        
        private int UserId { get; set; }

        public void SetLoggedInUser(User user)
        {
            UserId = user.UserId; 
        }

        public int GetLoggedInUserId()
        {   
            return UserId;
        }

        public void LogOut()
        {
            UserId = 0;
        }
    }
}
