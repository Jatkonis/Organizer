using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Organizer.Core.Models;
using Organizer.Core.Services;

namespace Organizer.Core.UnitTests
{
    [TestClass]
    public class EventStoreTests
    {
        List<Event> eventList = new List<Event>();

        [TestInitialize]
        public void Setup()
        {
            eventList.Add(new Event() { Id = 1, Date = DateTime.Parse("2019.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 });
            eventList.Add(new Event() { Id = 2, Date = DateTime.Parse("2019.05.27"), ShortDescription = "Manto", LongDescription = "Manto Gimtadienis", Priority = 0 });                     
        }

        [TestMethod]
        public void Given_GetById_When_DisplayEvents_Then_ShowCorrectValue()
        {
            // arrange
            var mock = new Mock<IEventDataRepository>();
            mock.Setup(x => x.ReadFromJson()).Returns(eventList);
            var actual = eventList.Find(x => x.Id == 1);

            EventStore sut = new EventStore(mock.Object);

            // act
            var result = sut.GetById(1);

            // assert
            Assert.AreEqual(result.LongDescription, actual.LongDescription);

        }
        [TestMethod]
        public void Given_GetEventByDescription_When_DisplayEvents_Then_ShowCorrectValue()
        {
            // arrange
            var mock = new Mock<IEventDataRepository>();
            mock.Setup(x => x.ReadFromJson()).Returns(eventList);
            var actual = eventList.Find(x => x.ShortDescription == "Manto");

            EventStore sut = new EventStore(mock.Object);

            //act
            var fullList = sut.GetEventByDescription("Manto");
            var result = fullList.FirstOrDefault(x => x.ShortDescription == "Manto");


            //assert
            Assert.AreEqual(result.LongDescription, actual.LongDescription);
        }

        [TestMethod]
        public void Given_ExistingEventListMember_When_UpdateEventInfo_Then_EventShouldBeUpdated()
        {
            //arrage
            var mock = new Mock<IEventDataRepository>();
            mock.Setup(x => x.ReadFromJson()).Returns(eventList);
            EventStore sut = new EventStore(mock.Object);

            var @event = eventList.Find(x => x.Id == 1);

            @event.Id = @event.Id;
            @event.ShortDescription = @event.ShortDescription;
            @event.LongDescription = "Manto penktasis Gimtadienis";
            @event.Priority = @event.Priority;

            //act            
            var result = sut.Update(@event);

            //assert
            Assert.AreEqual("Manto penktasis Gimtadienis", result.LongDescription);
        }

        [TestMethod]
        public void Given_EventsList_When_AddNewEventToList_Then_ListWasUpdated()
        {
            //arrange
            var mock = new Mock<IEventDataRepository>();
            mock.Setup(x => x.ReadFromJson()).Returns(eventList);
            var sut = new EventStore(mock.Object);

            //act
            sut.Add(new Event { Id = 3, Date = new DateTime(2019, 06, 28), ShortDescription = "Pauliaus", LongDescription = "Pauliaus Gimtadienis", Priority = 0 });
           
            //assert
            Assert.AreEqual(eventList.Count, 3);
        }

        [TestMethod]
        public void Given_EventList_When_RemoveEvent_Then_ListShoudBeUpdated()
        {
            //arange
            var mock = new Mock<IEventDataRepository>();
            mock.Setup(x => x.ReadFromJson()).Returns(eventList);
            var sut = new EventStore(mock.Object);

            //act
            sut.Remove(2);

            //assert
            Assert.AreEqual(eventList.Count, 2);
        }
    }
}


