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
            // Arrange          
            var user = new User() { Login = "Peter", Name = "Name", LastName = "LastName", Password = "123456", Email = "vardas@gmail.com", Phone = "867518491", UserId = 3 };

            // Act
            var result = UserMapper.MapToViewModelUser(user);

            // Assert
            Assert.Equal(result.Login, user.Login);
            Assert.Equal(result.Name, user.Name);
            Assert.Equal(result.LastName, user.LastName);
            Assert.Equal(result.Password, user.Password);
            Assert.Equal(result.Email, user.Email);
            Assert.Equal(result.Phone, user.Phone);
        }

        [Fact]
        public void Given_UserViewModel_WhenMappingToEvent_Then_AllPropertiesMappedCorrectly()
        {
            // Arrange           

            var userView = new UserViewModel() { Login = "Peter", Name = "Name", LastName = "LastName", Password = "123456", Email = "vardas@gmail.com", Phone = "867518491"};

            // Act
            var result = UserMapper.MapFromViewModelUser(userView);

            // Assert
            Assert.Equal(result.Login, userView.Login);
            Assert.Equal(result.Name, userView.Name);
            Assert.Equal(result.LastName, userView.LastName);
            Assert.Equal(result.Password, userView.Password);
            Assert.Equal(result.Email, userView.Email);
            Assert.Equal(result.Phone, userView.Phone);
        }
    }
}
