using Moq;
using Organizer.Core.Models;
using Organizer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Organizer.Core.UnitTests
{
    public class UserAuthenticationTests
    { 
        [Fact]
        public void Given_UserLoginAndPassword_When_UICallGetUser_Then_ReturnCorecctData()
        {
            //Arrange
            User user = new User() { Login = "Paulius", Password = "123456", Name = "Paulius", Surename = "Pavarde", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };

            var mock = new Mock<IUserRepositories>();
            mock.Setup(x => x.GetUsersByLogin("Paulius")).Returns(user);
            var sut = new UserAuthentication(mock.Object);

            //Act
            var result = sut.GetUser("Paulius", "123456");

            //Assert
            Assert.Equal("Paulius", result.Name);
        }

        [Fact]
        public void Given_UserLoginAndPassword_When_UICallGetUser_Then_ReturnNullWhenePasswordWasIncorect()
        {
            //Arrange
            User user = new User() { Login = "Paulius", Password = "123456", Name = "Paulius", Surename = "Pavarde", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };

            var mock = new Mock<IUserRepositories>();
            mock.Setup(x => x.GetUsersByLogin("Paulius")).Returns(user);
            var sut = new UserAuthentication(mock.Object);

            //Act
            var result = sut.GetUser("Paulius", "123");

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Given_UserLoginAndPassword_When_UICallGetUser_Then_ReturnNullWheneLoginWasIncorect()
        {
            //Arrange
            User user = new User() { Login = "Paulius", Password = "123456", Name = "Paulius", Surename = "Pavarde", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };

            var mock = new Mock<IUserRepositories>();
            mock.Setup(x => x.GetUsersByLogin("Paulius")).Returns(user);
            var sut = new UserAuthentication(mock.Object);

            //Act
            var result = sut.GetUser("Pauliuss", "123456");

            //Assert
            Assert.Null(result);
        }
    }
}
