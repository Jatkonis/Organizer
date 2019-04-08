using System.Collections.Generic;
using System.Linq;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public class EventSqlRepository : IEventRepositories
    {
        private readonly AppDbContext _appDbContext;
        
        public EventSqlRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddEvent(Event @event)
        {
            _appDbContext.Events.Add(@event);
            _appDbContext.SaveChanges();
        }

        public void DeleteEvent(int Id)
        {
            var @event = _appDbContext.Events.FirstOrDefault(x => x.EventId == Id);
            _appDbContext.Events.Remove(@event);
            _appDbContext.SaveChanges();
        }

        public List<Event> GetAllEvents()
        {
            return _appDbContext.Events.ToList();
        }

        public Event GetEventById(int Id)
        {
            return _appDbContext.Events.FirstOrDefault(x => x.EventId == Id);            
        }

        public void UpdateEvent(Event @event)
        {
            _appDbContext.Events.Update(@event);
            _appDbContext.SaveChanges();
        }
    }
}
