using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public class UserLoginStatus : IUserLoginStatus
    {        
        private int UserId { get; set; }

        public void SetLogedInUser(User user)
        {
            UserId = user.UserId; 
        }

        public int GetLogedInUserId()
        {   
            return UserId;
        }

        public void LogOut()
        {
            UserId = 0;
        }
    }
}
