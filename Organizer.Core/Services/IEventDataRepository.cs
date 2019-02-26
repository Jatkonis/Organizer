using System.Collections.Generic;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IEventDataRepository
    {
        void Write(List<Event> events);
        List<Event> Read();
    }
}