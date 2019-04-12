using System;
using System.Collections.Generic;
using System.Linq;
using Organizer.Core.Models;
using Organizer.Core.Services;

namespace Organizer.Data
{
    public class EventSqlRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;
        
        public EventSqlRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public void Add(Event @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            _appDbContext.Events.Add(@event);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            var @event = _appDbContext.Events.FirstOrDefault(x => x.EventId == id);
            if (@event == null)
            {
                return;
            }

            _appDbContext.Events.Remove(@event);
            _appDbContext.SaveChanges();
        }

        public List<Event> GetAll()
        {
            return _appDbContext.Events.ToList();
        }

        public Event GetById(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return _appDbContext.Events.FirstOrDefault(x => x.EventId == id);
        }

        public void Update(Event @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            _appDbContext.Events.Update(@event);
            _appDbContext.SaveChanges();
        }
    }
}
