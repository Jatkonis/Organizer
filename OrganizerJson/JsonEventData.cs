using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerJson
{
    public class JsonEventData : IEventData
    {
        List<Event> events;
        public JsonEventData()
        {
            events = new List<Event>();
        }

        public List<Event> ReadFromJson()
        {            
            var currentJsonFile = File.ReadAllText(@"C:\Code\OrganizerJson\datebase.json");
            var events = JsonConvert.DeserializeObject<List<Event>>(currentJsonFile);
            return events;
        }

        public void SaveToJson(List<Event> events)
        {
            string finalEventListInJson = JsonConvert.SerializeObject(events, Formatting.Indented);
            File.WriteAllText(@"C:\Code\OrganizerJson\datebase.json", finalEventListInJson);
        }

        public Event GetById(int id)
        {
            events = ReadFromJson();
            return events.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetEventByDescription(string shortDescription)
        {
            events = ReadFromJson();
            return from e in events
                   where string.IsNullOrEmpty(shortDescription) || e.ShortDescription.StartsWith(shortDescription)
                   orderby e.Date
                   select e;
        }

        public Event Update(Event updatedEvent)
        {
            events = ReadFromJson();
            var eventt = events.SingleOrDefault(e => e.Id == updatedEvent.Id);
            if (eventt != null)
            {
                eventt.Date = updatedEvent.Date;
                eventt.ShortDescription = updatedEvent.ShortDescription;
                eventt.LongDescription = updatedEvent.LongDescription;
                eventt.Priority = updatedEvent.Priority;                
            }

            SaveToJson(events);
            return eventt;
        }

        public Event Add(Event newEvent)
        {
            events = ReadFromJson();
            events.Add(newEvent);
            newEvent.Id = events.Max(e => e.Id) + 1;

            SaveToJson(events);

            return newEvent;
        }

        public Event Remove(int id)
        {
            events = ReadFromJson();
            var eventt = events.SingleOrDefault(e => e.Id == id);
            if (eventt != null)
            {
                events.Remove(eventt);
            }

            SaveToJson(events);
            return eventt;
        }
    }
}
