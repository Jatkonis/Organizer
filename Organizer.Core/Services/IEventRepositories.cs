using System.Collections.Generic;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IEventRepositories
    {
        Event GetEventById(int Id);
        List<Event> GetAllEvents();
        void AddEvent(Event @event);
        void UpdateEvent(Event @event);
        void DeleteEvent(int Id);        
    }
}