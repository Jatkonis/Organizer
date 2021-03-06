﻿using Organizer.Core.Models;
using Organizer.Core.Services;
using Organizer.Core.Services.Implementation;
using Xunit;

namespace Organizer.Core.UnitTests.Services
{
    public class UserLoginStatusTests
    {
        private UserLoginStatusService _sut;
       //private User user;

        public UserLoginStatusTests()
        {
            //User user = new User() { Login = "Paulius", Password = "123456", Name = "Paulius", Surename = "Pavarde", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };
            _sut = new UserLoginStatusService();
        }

        [Fact]
        public void Given_UserData_When_ChangeLoginStatus_Then_UserIDSaved()
        {
            //Arrage
            User user = new User() { Login = "Paulius", Password = "123456", Name = "Paulius", LastName = "Pavarde", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };

            //Act
            _sut.SetLoggedInUser(user);

            //Assert
            Assert.Equal(5, _sut.GetLoggedInUserId());
        }

        [Fact]
        public void When_AskedForLogedInUser_Then_UserIDReturn()
        {
            //Arrage
            User user = new User() { Login = "Paulius", Password = "123456", Name = "Paulius", LastName = "Pavarde", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };

            //Act
            _sut.SetLoggedInUser(user);
            int result = _sut.GetLoggedInUserId();

            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void When_CallLogOutMethonkedForLogedInUser_Then_UserIDEqualToZero()
        {
            //Arrage
            User user = new User() { Login = "Paulius", Password = "123456", Name = "Paulius", LastName = "Pavarde", Email = "paulius@gmail.com", Phone = "75111", UserId = 5 };

            //Act
            _sut.LogOut();

            //Assert
            Assert.Equal(0, _sut.GetLoggedInUserId());
        }
    }
}
