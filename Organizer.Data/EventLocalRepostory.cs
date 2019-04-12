using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Organizer.Core.Models;
using Organizer.Core.Services;

namespace Organizer.Data
{
    public class EventLocalRepository : IEventRepository
    {
        private List<Event> AllEvents = new List<Event>();

        public EventLocalRepository()
        {
            AllEvents.Add(new Event() { UserId = 1, Date = DateTime.Parse("2019.02.15"), EventId = 1, ShortDescription = "Test1", LongDescription = "LongTest1", Priority = PriorityType.Yes });
            AllEvents.Add(new Event() { UserId = 1, Date = DateTime.Parse("2019.02.16"), EventId = 2, ShortDescription = "Test2", LongDescription = "LongTest2", Priority = PriorityType.Yes });
            AllEvents.Add(new Event() { UserId = 1, Date = DateTime.Parse("2019.02.17"), EventId = 3, ShortDescription = "Test3", LongDescription = "LongTest3", Priority = PriorityType.Yes });

        }

        public void Add(Event @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
            AllEvents.Add(@event);

            AllEvents[AllEvents.Count - 1].EventId = AllEvents.Count(); // Manually added EventId, because in SQL this job is done by SQL.

        }

        public void Delete(int id)
        {
            var @event = AllEvents.FirstOrDefault(x => x.EventId == id);
            AllEvents.Remove((@event));
        }

        public Event GetById(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            return AllEvents.FirstOrDefault(x => x.EventId == id);
        }

        public List<Event> GetAll()
        {
            return AllEvents;
        }

        public void Update(Event @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
            var eventForUpdate = AllEvents.FirstOrDefault(x => x.EventId == @event.EventId);
            if (eventForUpdate != null)
            {
                eventForUpdate.Date = @event.Date;
                eventForUpdate.ShortDescription = @event.ShortDescription;
                eventForUpdate.LongDescription = @event.LongDescription;
                eventForUpdate.Priority = @event.Priority;
            }
        }
    }
}
