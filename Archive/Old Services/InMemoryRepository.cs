//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Organizer.Core.Models;

//namespace Organizer.Core.Services
//{
//    public class InMemoryRepository : IEventRepositories
//    {
//        List<Event> fullList = new List<Event>()
//        {
//            new Event() { Id = 1, Date = new DateTime(2019, 04, 01), ShortDescription = "Balandzio 1", LongDescription = "Melagiu diena", Priority = PriorityType.Yes },
//            new Event() { Id = 2, Date = new DateTime(2019, 05, 01), ShortDescription = "Geguzes 1", LongDescription = "Paskutinis pavasario menesis", Priority = PriorityType.No },
//            new Event() { Id = 3, Date = new DateTime(2019, 06, 01), ShortDescription = "Birzelio 1", LongDescription = "Vasaros pradzia", Priority = PriorityType.Yes },
//        };             

//        public List<Event> ReadFromRepository()
//        {
//            return fullList.ToList();
//        }

//        public void WriteToRepository(List<Event> events)
//        {
//            fullList = new List<Event>(events);
//        }
//    }
//}
