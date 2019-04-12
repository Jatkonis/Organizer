using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Organizer.Core.Models;

namespace Organizer.Core.Services.Implementation
{
    public class EventStore : IEventStore
    {
        private readonly IEventRepository _eventRepository;

        public EventStore(IEventRepository dataRepository)
        {
            _eventRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        public IEnumerable<Event> GetByDescriptionForUser(string shortDescription, int userId)
        {
            var events = _eventRepository.GetAll(); // TODO: move filtering for userID into the repository.
            return from e in events
                where (string.IsNullOrEmpty(shortDescription) || e.ShortDescription.StartsWith(shortDescription)) && e.UserId == userId
                orderby e.Date
                select e;
        }

        public Event GetById(int eventId)
        {
            if (eventId <= 0) throw new ArgumentException("Invalid Event id");
            return _eventRepository.GetById(eventId);
        }

        public void Update(Event updatedEvent)
        {
            if (updatedEvent == null) throw new ArgumentNullException(nameof(updatedEvent));

            _eventRepository.Update(updatedEvent);
        }

        public void Add(Event newEvent)
        {
            if (newEvent == null) throw new ArgumentNullException(nameof(newEvent));
            
            _eventRepository.Add(newEvent);            
        }

        public void Remove(int eventId)
        {
            if (eventId <= 0) throw new ArgumentException("Invalid Event id");

            _eventRepository.Delete(eventId);            
        }
    }
}
