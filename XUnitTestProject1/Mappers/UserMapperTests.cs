using Organizer.Core.Models;
using Organizer.Web.Mappers;
using Organizer.Web.ViewModels;
using Xunit;

namespace Organizer.Web.UnitTestss
{
    public class UserMapperTests
    {
        [Fact]
        public void Given_User_WhenMappingToViewModel_Then_AllPropertiesMappedCorrectly()
        {
            // Arrage          
            User user = new User() { Login = "Paulius", Name = "Vardas", Surename = "Pavarde", Password = "123456", Email = "vardas@gmail.com", Phone = "867518491", UserId = 3 };

            // Act
            UserViewModel result = UserMapper.MapToViewModelUser(user);

            // Assert
            Assert.Equal(result.Login, user.Login);
            Assert.Equal(result.Name, user.Name);
            Assert.Equal(result.Surename, user.Surename);
            Assert.Equal(result.Password, user.Password);
            Assert.Equal(result.Email, user.Email);
            Assert.Equal(result.Phone, user.Phone);
            Assert.Equal(result.UserId, user.UserId);
        }

        [Fact]
        public void Given_UserViewModel_WhenMappingToEvent_Then_AllPropertiesMappedCorrectly()
        {
            // Arrage           

            UserViewModel userView = new UserViewModel() { Login = "Paulius", Name = "Vardas", Surename = "Pavarde", Password = "123456", Email = "vardas@gmail.com", Phone = "867518491", UserId = 3 };

            // Act
            User result = UserMapper.MapFromViewModelUser(userView);

            // Assert
            Assert.Equal(result.Login, userView.Login);
            Assert.Equal(result.Name, userView.Name);
            Assert.Equal(result.Surename, userView.Surename);
            Assert.Equal(result.Password, userView.Password);
            Assert.Equal(result.Email, userView.Email);
            Assert.Equal(result.Phone, userView.Phone);
            Assert.Equal(result.UserId, userView.UserId);
        }
    }
}
