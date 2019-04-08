//using System;
//using System.Collections.Generic;
//using System.IO;
//using Newtonsoft.Json;
//using Organizer.Core.Models;

//namespace Organizer.Core.Services
//{
//    public class JsonEventDataRepository : IEventRepositories
//    {
//        private readonly string _path;

//        public JsonEventDataRepository()
//        {
//            var basePath = AppDomain.CurrentDomain.BaseDirectory;
//            _path = Path.Combine(basePath, "datebase.json");
//        }

//        public void WriteToRepository(List<Event> events)
//        {
//            var finalEventListInJson = JsonConvert.SerializeObject(events, Formatting.Indented);
//            File.WriteAllText(_path, finalEventListInJson);
//        }

//        public List<Event> ReadFromRepository()
//        {
//            if (File.Exists(_path) == false)
//            {
//                File.WriteAllText(_path, string.Empty);
//            }

//            var currentJsonFile = File.ReadAllText(_path);
//            var events = JsonConvert.DeserializeObject<List<Event>>(currentJsonFile);

//            return events ?? new List<Event>();
//        }
//    }
//}