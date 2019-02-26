using System.Collections.Generic;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IEventStore
    {
        IEnumerable<Event> GetEventByDescription(string shortDescription);
        Event GetById(int id);
        Event Update(Event updatedEvent);
        Event Add(Event newEvent);
        Event Remove(int id);
    }
}
