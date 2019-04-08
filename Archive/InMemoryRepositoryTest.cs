//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Organizer.Core.Models;
//using Organizer.Core.Services;
//using System;
//using System.Collections.Generic;



//namespace Organizer.Core.UnitTests
//{
//    [TestClass]
//    public class InMemoryRepositoryTest
//    {
//        List<Event> fullList = new List<Event>();

//        [TestInitialize]
//        public void Setup()
//        {
//            fullList.Add(new Event() { Id = 1, Date = new DateTime(2019, 04, 01), ShortDescription = "Balandzio 1", LongDescription = "Melagiu diena", Priority = PriorityType.Yes });
//            fullList.Add(new Event() { Id = 2, Date = new DateTime(2019, 05, 01), ShortDescription = "Geguzes 1", LongDescription = "Paskutinis pavasario menesis", Priority = PriorityType.No });
//            fullList.Add(new Event() { Id = 3, Date = new DateTime(2019, 06, 01), ShortDescription = "Birzelio 1", LongDescription = "Vasaros pradzia", Priority = PriorityType.Yes });
//        }

//        [TestMethod]
//        public void Given_EventList_When_DisplayAllEvents_Then_ShowExistingEventsFromLocalMemory()
//        {
//            //arrange
//            var sut = new InMemoryRepository();

//            //act
//            var result = sut.ReadFromRepository();
//            Event @event = result.Find(x => x.Id == 1);

//            //assert
//            Assert.AreEqual(3, result.Count);
//            Assert.AreEqual("Balandzio 1", @event.ShortDescription);
//        }

//        [TestMethod]
//        public void Given__ExistingMemory_When_AddNewEvent_Then_ShouldUpdateExistingMemory()
//        {
//            //arrange            
//            var sut = new InMemoryRepository();

//            fullList.Add(new Event() { Id = 4, Date = new DateTime(2020, 09, 01), ShortDescription = "Rugsejo 1", LongDescription = "Mokslu pradzia", Priority = PriorityType.No});
            
//            //act
//            sut.WriteToRepository(fullList);

//            //assert
//            Assert.AreEqual(4, fullList.Count);
//        }
//    }
//}
