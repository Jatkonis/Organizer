using System;
using System.Collections.Generic;
using System.Linq;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public class EventStore : IEventStore
    {
        private readonly IEventRepositories _dataRepository;

        public EventStore(IEventRepositories dataRepository)
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        public Event GetById(int eventId)
        {
            if (eventId <= 0) throw new ArgumentException("Invalid Event id");
            return _dataRepository.GetEventById(eventId);
        }

        public IEnumerable<Event> GetEventByDescription(string shortDescription)
        {
            if (shortDescription == null) throw new ArgumentException("Short description is required.");

            var events = _dataRepository.GetAllEvents();
            return from e in events
                   where string.IsNullOrEmpty(shortDescription) || e.ShortDescription.StartsWith(shortDescription)
                   orderby e.Date
                   select e;
        }

        public void Update(Event updatedEvent)
        {
            _dataRepository.UpdateEvent(updatedEvent);            
        }

        public void Add(Event newEvent)
        {
            if (newEvent == null) throw new ArgumentNullException(nameof(newEvent));

            _dataRepository.AddEvent(newEvent);            
        }

        public void Remove(int eventId)
        {
            if (eventId <= 0) throw new ArgumentException("Invalid Event id");

            _dataRepository.DeleteEvent(eventId);            
        }
    }
}
