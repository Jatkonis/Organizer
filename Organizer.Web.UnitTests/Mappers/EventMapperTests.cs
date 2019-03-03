using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Organizer.Core.Models;
using Organizer.Web.Mappers;
using Organizer.Web.ViewModels;

namespace Organizer.Web.UnitTests
{
    [TestClass]
    public class EventMapperTests
    {
        [TestMethod]
        public void Given_Event_WhenMappingToViewModel_Then_AllPropertiesMappedCorrectly()
        {
            // Arrage           

            Event @event = new Event() { Id = 10, Date = new DateTime(2019, 02, 15), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 };

            // Act
            EventViewModel result = EventMapper.MapToViewModel(@event);

            // Assert
            Assert.AreEqual(result.Id, @event.Id);
            Assert.AreEqual(result.Date, @event.Date);
            Assert.AreEqual(result.ShortDescription, @event.ShortDescription);
            Assert.AreEqual(result.LongDescription, @event.LongDescription);
            Assert.AreEqual(result.Priority, @event.Priority);
        }

        [TestMethod]
        public void Given_EventViewModel_WhenMappingToEvent_Then_AllPropertiesMappedCorrectly()
        {
            // Arrage           

            EventViewModel eventview = new EventViewModel() { Id = 10, Date = DateTime.Parse("2019.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 };

            // Act
            Event result = EventMapper.MapFromViewModel(eventview);

            // Assert
            Assert.AreEqual(result.Id, eventview.Id);
            Assert.AreEqual(result.Date, eventview.Date);
            Assert.AreEqual(result.ShortDescription, eventview.ShortDescription);
            Assert.AreEqual(result.LongDescription, eventview.LongDescription);
            Assert.AreEqual(result.Priority, eventview.Priority);            
        }
    }
}
