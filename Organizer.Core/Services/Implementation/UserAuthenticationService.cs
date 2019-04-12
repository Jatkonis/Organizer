using System;
using Organizer.Core.Models;

namespace Organizer.Core.Services.Implementation
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserLoginStatusService _loginStatusService;

        public UserAuthenticationService(IUserRepository userRepository, IUserLoginStatusService loginStatusService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _loginStatusService = loginStatusService ?? throw new ArgumentNullException(nameof(loginStatusService));
        }

        public User LoginUser(string login, string password)
        {
            var user = GetUserFromDataBase(login);
            if (user == null)
            {
                return null;
            }

            var accessToLogin = ValidateUserLogin(user, password);
            if (accessToLogin == false)
            {
                return null;
            }

            _loginStatusService.SetLoggedInUser(user);
            return user;
        }

        private User GetUserFromDataBase(string login)
        {
            var user = _userRepository.GetUsersByLogin(login);            
            return user;
        }

        private bool ValidateUserLogin(User user, string password)
        {            
            if (user.Password == password)
            {
                return true;
            }
            return false;              
        }
    }
}
