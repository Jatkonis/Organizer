using System.Collections.Generic;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IEventStore
    {
        IEnumerable<Event> GetByDescriptionForUser(string searchTerm, int userId);
        Event GetById(int id);
        void Update(Event updatedEvent);
        void Add(Event newEvent);
        void Remove(int id);
    }
}
