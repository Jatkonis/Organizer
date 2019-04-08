using System;
using System.Linq;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public class UserSqlRepository : IUserRepositories
    {
        private readonly AppDbContext _appDbContext;

        public UserSqlRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext)); ;
        }

        public void AddUser(User newUser)
        {
            _appDbContext.Users.Add(newUser);
            _appDbContext.SaveChanges();
        }

        public void DeleteUser(User deleteUser)
        {            
            _appDbContext.Remove(deleteUser);
            _appDbContext.SaveChanges();
        }

        public User GetUsersByLogin(string login)
        {
            User user = _appDbContext.Users.FirstOrDefault(x => x.Login == login);
            return user;                
        }

        public void UpdateUser(User updatedUser)
        {
            _appDbContext.Users.Remove(updatedUser);
            _appDbContext.SaveChanges();
        }
    }
}
