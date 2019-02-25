using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerJson
{
    // TODO: already mentioned this somewhere, but the only public methods in your class should be the ones that the interface enforces you to use.
    public class JsonEventData : IEventData
    {
        // TODO: by c# convention, make this explicit private, so everyone knows your intent.
        // TODO: by c# naming convention, rename this to _events and make readonly - readonly because the instance of list is created in constructor.
        List<Event> events;
        public JsonEventData()
        {
            events = new List<Event>();
        }

        // TODO: ENCAPSULATION - this method should be private because user of class doesn't need to use it
        public List<Event> ReadFromJson()
        {
            // TODO: hardcoded DB file path.
            // TODO: either make it configurable - move the path to the file into the appsettings.json file and read it from there
            // TODO: or use the path of the current application folder by using AppDomain.CurrentDomain.BaseDirectory
            var currentJsonFile = File.ReadAllText(@"C:\Code\OrganizerJson\datebase.json");

            // TODO: look for naming collision in class. The below events is the same as class level member this.events - you can't tell by simply looking at which one it returns
            var events = JsonConvert.DeserializeObject<List<Event>>(currentJsonFile);
            return events;
        }

        // TODO: Same as above - make this private and encapsulate.
        public void SaveToJson(List<Event> events)
        {
            // TODO: var VS specific type. Prefer var, but if you're using types - do that consistently.
            string finalEventListInJson = JsonConvert.SerializeObject(events, Formatting.Indented);
            
            // TODO: hardcoded DB file path
            File.WriteAllText(@"C:\Code\OrganizerJson\datebase.json", finalEventListInJson);
        }

        public Event GetById(int id)
        {
            // TODO: from Defensive Coding - is it possible the given ID is lower or less than 0? 
            events = ReadFromJson();
            return events.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetEventByDescription(string shortDescription)
        {
            // TODO: from Defensive Coding - is it possible the given shortDescription is null/empty string? What will happen if it is?
            events = ReadFromJson();
            return from e in events
                   where string.IsNullOrEmpty(shortDescription) || e.ShortDescription.StartsWith(shortDescription)
                   orderby e.Date
                   select e;
        }

        public Event Update(Event updatedEvent)
        {
            // TODO: from Defensive Coding - can updatedEvent be null? If it can - what will happen?
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
            // TODO: from Defensive Coding - can newEvent be null? If it can - what will happen?
            events = ReadFromJson();
            events.Add(newEvent);
            newEvent.Id = events.Max(e => e.Id) + 1;

            SaveToJson(events);

            return newEvent;
        }

        public Event Remove(int id)
        {
            // TODO: from Defensive Coding - is it possible the given ID is lower or less than 0? 

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
