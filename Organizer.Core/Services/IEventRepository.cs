using System.Collections.Generic;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IEventRepository
    {
        Event GetById(int id);
        List<Event> GetAll();
        void Add(Event @event);
        void Update(Event @event);
        void Delete(int id);        
    }
}