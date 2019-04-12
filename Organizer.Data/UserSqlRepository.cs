using System;
using System.Linq;
using Organizer.Core.Models;
using Organizer.Core.Services;

namespace Organizer.Data
{
    public class UserSqlRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserSqlRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext)); ;
        }

        public void AddUser(User newUser)
        {
            if (newUser == null) throw new ArgumentNullException(nameof(newUser));

            _appDbContext.Users.Add(newUser);
            _appDbContext.SaveChanges();
        }

        public User GetUsersByLogin(string login)
        {
            if (login == null) throw new ArgumentNullException(nameof(login));

            var user = _appDbContext.Users.FirstOrDefault(x => x.Login == login);
            return user;                
        }
    }
}
