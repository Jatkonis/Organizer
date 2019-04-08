using System;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public class UserAuthentication : IUserAuthentication
    {
        private readonly IUserRepositories _userRepositories;
        

        public UserAuthentication(IUserRepositories userRepositories)
        {
            _userRepositories = userRepositories ?? throw new ArgumentNullException(nameof(userRepositories));            
        }

        public User GetUser(string login, string password)
        {
            User user = GetUserFromDataBase(login);
            if (user != null)
            {
                bool accesToLogin = ValiteUserLogin(user, password);
                if (accesToLogin == true)
                {                    
                    return user;
                }
                return null;
            }
            return null;                     
        }

        private User GetUserFromDataBase(string login)
        {
            User user = _userRepositories.GetUsersByLogin(login);            
            return user;
        }

        private bool ValiteUserLogin(User user, string password)
        {            
            if (user.Password == password)
            {
                return true;
            }
            return false;              
        }
    }
}
