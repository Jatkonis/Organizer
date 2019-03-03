using System;
using System.Collections.Generic;
using System.Linq;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public class EventStore : IEventStore
    {
        private readonly IEventDataRepository _dataRepository;
        public EventStore(IEventDataRepository dataRepository)
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }
        
        public Event GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid Event id");
            
            var events = _dataRepository.ReadFromJson();
            return events.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetEventByDescription(string shortDescription)
        {
            if (string.IsNullOrWhiteSpace(shortDescription)) throw new ArgumentException("Short description is required.");            

            var events = _dataRepository.ReadFromJson();
            return from e in events
                   where string.IsNullOrEmpty(shortDescription) || e.ShortDescription.StartsWith(shortDescription)
                   orderby e.Date
                   select e;
        }

        public Event Update(Event updatedEvent)
        {
            if (updatedEvent == null) throw new ArgumentNullException(nameof(updatedEvent));

            var events = _dataRepository.ReadFromJson();
            var @event = events.SingleOrDefault(e => e.Id == updatedEvent.Id);
            if (@event != null)
            {
                @event.Date = updatedEvent.Date;
                @event.ShortDescription = updatedEvent.ShortDescription;
                @event.LongDescription = updatedEvent.LongDescription;               
                @event.Priority = updatedEvent.Priority;                
            }

            _dataRepository.WriteToJson(events);
            return @event;
        }

        public Event Add(Event newEvent)
        {
            if (newEvent == null) throw new ArgumentNullException(nameof(newEvent));
            
            var events = _dataRepository.ReadFromJson();
            events.Add(newEvent);            
            newEvent.Id = events.Max(e => e.Id) + 1;
                  

            _dataRepository.WriteToJson(events);

            return newEvent;
        }

        public Event Remove(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid Event id");

            var events = _dataRepository.ReadFromJson();
            var @event = events.SingleOrDefault(e => e.Id == id);
            if (@event != null)
            {
                events.Remove(@event);
            }

            _dataRepository.WriteToJson(events);
            return @event;
        }
    }
}
