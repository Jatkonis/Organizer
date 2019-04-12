using Moq;
using Organizer.Core.Models;
using Organizer.Core.Services;
using Organizer.Core.Services.Implementation;
using Xunit;

namespace Organizer.Core.UnitTests.Services
{
    public class UserAuthenticationTests
    { 
        [Theory]
        [InlineData("Peter", "123456", "Peter")]
        public void Given_UserLoginAndPassword_When_UICallGetUser_Then_ReturnCorrectData(string login, string password, string expectedResult)
        {
            //Arrange
            var user = new User() { Login = "Peter", Password = "123456", Name = "Peter", LastName = "LastName", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUsersByLogin("Peter")).Returns(user);
            var loginServiceMock = new Mock<IUserLoginStatusService>();

            var sut = new UserAuthenticationService(userRepositoryMock.Object, loginServiceMock.Object);

            //Act
            var result = sut.LoginUser(login, password);

            //Assert
            Assert.Equal(expectedResult, result.Name);
        }

        [Theory]
        [InlineData("John", "123456")]
        [InlineData("Peter", "123")]
        public void Given_UserLoginAndPassword_When_UICallGetUser_Then_ReturnNullWhenPasswordWasIncorrect(string login, string password)
        {
            //Arrange
            var user = new User() { Login = "Peter", Password = "123456", Name = "Peter", LastName = "LastName", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };

            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetUsersByLogin("Peter")).Returns(user);

            var loginServiceMock = new Mock<IUserLoginStatusService>();
            var sut = new UserAuthenticationService(mock.Object, loginServiceMock.Object);

            //Act
            var result = sut.LoginUser(login, password);

            //Assert
            Assert.Null(result);
        }
    }
}
