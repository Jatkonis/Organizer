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
            // TODO: from Defensive Coding - is it possible the given ID is lower or less than 0? 
            var events = _dataRepository.Read();
            return events.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetEventByDescription(string shortDescription)
        {
            // TODO: from Defensive Coding - is it possible the given shortDescription is null/empty string? What will happen if it is?
            var events = _dataRepository.Read();
            return from e in events
                   where string.IsNullOrEmpty(shortDescription) || e.ShortDescription.StartsWith(shortDescription)
                   orderby e.Date
                   select e;
        }

        public Event Update(Event updatedEvent)
        {
            // TODO: from Defensive Coding - can updatedEvent be null? If it can - what will happen?
            var events = _dataRepository.Read();
            var @event = events.SingleOrDefault(e => e.Id == updatedEvent.Id);
            if (@event != null)
            {
                @event.Date = updatedEvent.Date;
                @event.ShortDescription = updatedEvent.ShortDescription;
                @event.LongDescription = updatedEvent.LongDescription;
                @event.Priority = updatedEvent.Priority;                
            }

            _dataRepository.Write(events);
            return @event;
        }

        public Event Add(Event newEvent)
        {
            if (newEvent == null) throw new ArgumentNullException(nameof(newEvent));

            // TODO: from Defensive Coding - can newEvent be null? If it can - what will happen?
            var events = _dataRepository.Read();
            events.Add(newEvent);
            newEvent.Id = events.Max(e => e.Id) + 1; // BUG: when list is empty -> this crashes.

            _dataRepository.Write(events);

            return newEvent;
        }

        public Event Remove(int id)
        {
            // TODO: from Defensive Coding - is it possible the given ID is lower or less than 0? 

            var events = _dataRepository.Read();
            var @event = events.SingleOrDefault(e => e.Id == id);
            if (@event != null)
            {
                events.Remove(@event);
            }

            _dataRepository.Write(events);
            return @event;
        }
    }
}
