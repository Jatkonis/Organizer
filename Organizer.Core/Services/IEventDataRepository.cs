using System.Collections.Generic;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public interface IEventDataRepository
    {
        void WriteToJson(List<Event> events);
        List<Event> ReadFromJson();
    }
}