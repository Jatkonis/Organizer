using Organizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Core.Services
{
    public interface IUserRepositories
    {
        void AddUser(User newUser);
        void UpdateUser(User updatedUser);        
        void DeleteUser(User deleteUser);
        User GetUsersByLogin(string login);
    }
}
