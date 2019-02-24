using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerJson
{
    public interface IEventData
    {
        IEnumerable<Event> GetEventByDescription(string shortDescription);
        Event GetById(int id);
        Event Update(Event updatedEvent);
        Event Add(Event newEvent);
        Event Remove(int id);
    }
}
