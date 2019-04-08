using Organizer.Core.Models;
using Organizer.Web.Mappers;
using Organizer.Web.ViewModels;
using System;
using System.Linq;
using Xunit;

namespace Organizer.Web.UnitTestss
{
    public class EventMapperTests
    {
        [Fact]
        public void Given_Event_WhenMappingToViewModel_Then_AllPropertiesMappedCorrectly()
        {
            // Arrage          
            Event @event = new Event() { EventId = 10, Date = new DateTime(2019, 02, 15), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 };

            // Act
            EventViewModel result = EventMapper.MapToViewModel(@event);

            // Assert
            Assert.Equal(result.Id, @event.EventId);
            Assert.Equal(result.Date, @event.Date);
            Assert.Equal(result.ShortDescription, @event.ShortDescription);
            Assert.Equal(result.LongDescription, @event.LongDescription);
            Assert.Equal(result.Priority, @event.Priority);
        }

        [Fact]
        public void Given_EventViewModel_WhenMappingToEvent_Then_AllPropertiesMappedCorrectly()
        {
            // Arrage           

            EventViewModel eventview = new EventViewModel() { Id = 10, Date = DateTime.Parse("2019.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 };

            // Act
            Event result = EventMapper.MapFromViewModel(eventview);

            // Assert
            Assert.Equal(result.EventId, eventview.Id);
            Assert.Equal(result.Date, eventview.Date);
            Assert.Equal(result.ShortDescription, eventview.ShortDescription);
            Assert.Equal(result.LongDescription, eventview.LongDescription);
            Assert.Equal(result.Priority, eventview.Priority);
        }
    }
}
