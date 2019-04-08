//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Organizer.Core.Models;

//namespace Organizer.Core.Services
//{
//    public class TextFileRepository : IEventRepositories
//    {
//        private string _path;

//        public TextFileRepository()
//        {
//            var basePath = AppDomain.CurrentDomain.BaseDirectory;
//            _path = Path.Combine(basePath, "database.txt");
//        }       

//        public void WriteToRepository(List<Event> events)
//        {
//            List<string> output = new List<string>();
//            foreach (var item in events)
//            {
//                output.Add($"{item.Id},{item.Date},{item.ShortDescription},{item.LongDescription},{item.Priority}");
//            }

//            File.WriteAllLines(_path, output);
//        }

//        public List<Event> ReadFromRepository()
//        {
//            if (File.Exists(_path) == false)
//            {
//                File.WriteAllText(_path, string.Empty);
//            }

//            List<Event> events = new List<Event>();
//            List<string> lines = File.ReadAllLines(_path).ToList();

//            foreach (var line in lines)
//            {
//                string[] unit = line.Split(',');
//                Event @event = new Event();
//                @event.Id = Int32.Parse(unit[0]);
//                @event.Date = DateTime.Parse(unit[1]);
//                @event.ShortDescription = unit[2];
//                @event.LongDescription = unit[3];
//                if (unit[4] == PriorityType.Yes.ToString())
//                {
//                    @event.Priority = PriorityType.Yes;
//                }                
//                else
//                {
//                    @event.Priority = PriorityType.No;
//                }               
                
//                events.Add(@event);
//            }
//            return events;
//        }
//    }
//}
