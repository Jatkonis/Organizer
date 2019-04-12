using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Organizer.Core.Models;
using Organizer.Core.Services;

namespace Organizer.Data
{
    public class UserLocalRepository : IUserRepository
    {
        private List<User> AllUsers = new List<User>();
        public UserLocalRepository()
        {
            AllUsers.Add(new User() { UserId = 1, Login = "Peter", LastName = "LastName", Name = "Peter", Password = "123456", Email = "peter@email.com", Phone = "880012345" });
        }

        public void AddUser(User newUser)
        {
            if (newUser == null) throw new ArgumentNullException(nameof(newUser));

            AllUsers.Add(newUser);
        }

        public User GetUsersByLogin(string login)
        {
            if (login == null) throw new ArgumentNullException(nameof(login));

            var user = AllUsers.Find(x => x.Login == login);

            return user;
        }


    }
}
