using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Organizer.Core.Models;
using Organizer.Core.Services;
using Organizer.Core.Services.Implementation;
using Xunit;

namespace Organizer.Core.UnitTests.Services
{
    public class EventStoreTests
    {
        readonly List<Event> eventList = new List<Event>();
        private EventStore _sut;

        public EventStoreTests()
        {
            eventList.Add(new Event() { EventId = 1, Date = DateTime.Parse("2019.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0, UserId = 1});
            eventList.Add(new Event() { EventId = 2, Date = DateTime.Parse("2019.05.27"), ShortDescription = "Manto", LongDescription = "Manto Gimtadienis", Priority = 0, UserId = 1});
        }    
        
        [Fact]
        public void GetEventByDescription_WithEmptyString_ShouldReturnFullList()
        {
            // arrange            
            var userId = 1;
            var mock = new Mock<IEventRepository>();
            mock.Setup(x => x.GetAll()).Returns(eventList);
            _sut = new EventStore(mock.Object);

            // act
            var result = _sut.GetByDescriptionForUser("", userId);

            // assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetEventByDescription_WithValue_ShouldReturnCorrectItem()
        {
            // arrange            
            var userId = 1;
            var mock = new Mock<IEventRepository>();
            mock.Setup(x => x.GetAll()).Returns(eventList);
            _sut = new EventStore(mock.Object);


            // act
            var fullList = _sut.GetByDescriptionForUser("Sandros", userId);
            var result = fullList.FirstOrDefault(x => x.EventId == 1);

            // assert
            Assert.Equal("Sandros Gimtadienis", result.LongDescription);
        }

        [Fact]
        public void When_CreatingNewEvent_Then_SQLRepositoryAddEventShouldBeCalled()
        {
            //Arrange
            var mock = new Mock<IEventRepository>();
            mock.Setup(x => x.Add(It.IsAny<Event>()));
            var sut = new EventStore(mock.Object);

            //Act
            sut.Add(new Event());

            //Assert
            mock.VerifyAll();
        }

        [Fact]
        public void When_CreatingDeletingEvent_Then_SQLRepositoryRemoveShouldBeCalled()
        {
            //Arrange
            var mock = new Mock<IEventRepository>();
            mock.Setup(x => x.Delete(It.IsAny<int>()));
            var sut = new EventStore(mock.Object);

            //Act
            sut.Remove(4);

            //Assert
            mock.VerifyAll();
        }

        [Fact]
        public void When_UpdatingEvvent_Then_SQLRepositoryUpdateEventShouldBeCalled()
        {
            //Arrange
            var mock = new Mock<IEventRepository>();
            mock.Setup(x => x.Update(It.IsAny<Event>()));
            var sut = new EventStore(mock.Object);

            //Act
            sut.Update(new Event());

            //Assert
            mock.VerifyAll();
        }
    }
}
