using Organizer.Core.Models;
using Organizer.Web.ViewModels;

namespace Organizer.Web.Mappers
{
    public class UserMapper
    {
        public static User MapFromViewModelUser(UserViewModel viewModelUser)
        {
            return new User()
            {
                UserId = viewModelUser.UserId,
                Login = viewModelUser.Login,
                Password = viewModelUser.Password,
                Name = viewModelUser.Name,
                Surename = viewModelUser.Surename,
                Email = viewModelUser.Email,
                Phone = viewModelUser.Phone
            };
        }

        public static UserViewModel MapToViewModelUser(User user)
        {
            if (user != null)
            {
                return new UserViewModel()
                {
                    UserId = user.UserId,
                    Login = user.Login,
                    Password = user.Password,
                    Name = user.Name,
                    Surename = user.Surename,
                    Email = user.Email,
                    Phone = user.Phone
                };
            }
            return null;            
        }
    }
}
