using System;
using Organizer.Core.Models;
using Organizer.Web.ViewModels;

namespace Organizer.Web.Mappers
{
    public class UserMapper
    {
        public static User MapFromViewModelUser(UserViewModel viewModelUser)
        {
            if (viewModelUser == null) throw new ArgumentNullException(nameof(viewModelUser));

            return new User()
            {
                Login = viewModelUser.Login,
                Password = viewModelUser.Password,
                Name = viewModelUser.Name,
                LastName = viewModelUser.LastName,
                Email = viewModelUser.Email,
                Phone = viewModelUser.Phone
            };
        }

        public static UserViewModel MapToViewModelUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return new UserViewModel()
            {
                Login = user.Login,
                Password = user.Password,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone
            };
        }
    }
}
