using Moq;
using Organizer.Core.Models;
using Organizer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Organizer.Core.UnitTests
{
    public class EventStoreTests
    {
        List<Event> eventList = new List<Event>();
        private EventStore _sut;

        public EventStoreTests()
        {
            eventList.Add(new Event() { EventId = 1, Date = DateTime.Parse("2019.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 });
            eventList.Add(new Event() { EventId = 2, Date = DateTime.Parse("2019.05.27"), ShortDescription = "Manto", LongDescription = "Manto Gimtadienis", Priority = 0 });
        }    
        
        [Fact]
        public void GetEventByDescription_WithEmtyString_ShouldReturnFullList()
        {
            // arrange            
            var mock = new Mock<IEventRepositories>();
            mock.Setup(x => x.GetAllEvents()).Returns(eventList);
            _sut = new EventStore(mock.Object);

            // act
            var result = _sut.GetEventByDescription("");

            // assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetEventByDescription_WithValue_ShouldReturnCorectItem()
        {
            // arrange            
            var mock = new Mock<IEventRepositories>();
            mock.Setup(x => x.GetAllEvents()).Returns(eventList);
            _sut = new EventStore(mock.Object);


            // act
            var fullList = _sut.GetEventByDescription("Sandros");
            var result = fullList.FirstOrDefault(x => x.EventId == 1);

            // assert
            Assert.Equal("Sandros Gimtadienis", result.LongDescription);
        }

        [Fact]
        public void When_CreatingNewEvent_Then_SQLRepositoryAddEventShouldBeCalled()
        {
            //Arrange
            var mock = new Mock<IEventRepositories>();
            mock.Setup(x => x.AddEvent(It.IsAny<Event>()));
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
            var mock = new Mock<IEventRepositories>();
            mock.Setup(x => x.DeleteEvent(It.IsAny<int>()));
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
            var mock = new Mock<IEventRepositories>();
            mock.Setup(x => x.UpdateEvent(It.IsAny<Event>()));
            var sut = new EventStore(mock.Object);

            //Act
            sut.Update(new Event());

            //Assert
            mock.VerifyAll();
        }
    }
}
