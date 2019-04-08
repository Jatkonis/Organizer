//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Organizer.Core.Models;
//using Organizer.Core.Services;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace Organizer.Core.UnitTests
//{
//    [TestClass]
//    public class TextFileRepositoryTests
//    {
//        private string _path;
//        [TestInitialize]
//        public void Setup()
//        {
//            var basePath = AppDomain.CurrentDomain.BaseDirectory;
//            _path = Path.Combine(basePath, "database.txt");
//        }        

//        //---- Write to Repository Method ----
//        [TestMethod]
//        public void Given_EvnetList_When_ThereIsNoFileYet_Then_CreateNewFile()
//        {
//            //Arrange
//            if (File.Exists(_path))
//            {
//                File.Delete(_path);
//            }
//            var sut = new TextFileRepository();

//            //Act
//            sut.WriteToRepository(new List<Event>());

//            //Assert
//            Assert.IsTrue(File.Exists(_path));
//        }

//        [TestMethod]
//        public void Given_EventsList_When_WriteNewEventsToFile_Then_WriteCorrectData()
//        {
//            //Arrange
//            if (File.Exists(_path))
//            {
//                File.Delete(_path);
//            }
//            var sut = new TextFileRepository();

//            List<Event> eventList = new List<Event>();

//            eventList.Add(new Event() { Id = 10, Date = DateTime.Parse("2019.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 });
//            eventList.Add(new Event() { Id = 11, Date = DateTime.Parse("2019.05.27"), ShortDescription = "Manto", LongDescription = "Manto Gimtadienis", Priority = 0 });

//            //Act
//            sut.WriteToRepository(eventList);

//            //Assert
//            Assert.AreEqual(2, File.ReadAllLines(_path).Length);
//        }

//        [TestMethod]
//        public void Given_EvnetList_When_ThereIsFileAlready_Then_UpadteExistingFile()
//        {
//            //Arrange
//            File.Delete(_path);

//            List<string> lines = new List<string>();
//            lines.Add("10,2020.01.01,Naujieji Metai,2020 Naujieji metai,Yes");
//            lines.Add("11,2020.02.01,Vasario 2, 2020 Vasario antroji,No");
//            lines.Add("12,2020.03.01,Kovo 1,2020 Kovo pirmoji,Yes");
//            File.WriteAllLines(_path, lines);
//            List<Event> eventList = new List<Event>();

//            List<string> textdata = File.ReadAllLines(_path).ToList();

//            foreach (var line in textdata)
//            {
//                string[] unit = line.Split(',');
//                Event @event = new Event();
//                @event.Id = Int32.Parse(unit[0]);
//                @event.Date = DateTime.Parse(unit[1]);
//                @event.ShortDescription = unit[2];
//                @event.LongDescription = unit[3];
//                if (unit[4] == "Yes")
//                {
//                    @event.Priority = PriorityType.Yes;
//                }
//                else
//                {
//                    @event.Priority = PriorityType.No;
//                }

//                eventList.Add(@event);
//            }

//            var sut = new TextFileRepository();

//            eventList.Add(new Event() { Id = 13, Date = DateTime.Parse("2020.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros 2020 Gimtadienis", Priority=PriorityType.Yes });

//            //Act
//            sut.WriteToRepository(eventList);

//            //Assert
//            Assert.AreEqual(4, File.ReadAllLines(_path).Length);
//        }

//        // ----- Read From Repository Method
//        [TestMethod]
//        public void Given_TextFile_When_ReadingDataBase_Then_ImportDataCorrectly()
//        {
//            //arrange
//            File.Delete(_path);

//            List<string> lines = new List<string>();

//            lines.Add("10,2020.01.01,Naujieji Metai,2020 Naujieji metai,Yes");
//            lines.Add("11,2020.02.01,Vasario 2, 2020 Vasario antroji,No");
//            lines.Add("12,2020.03.01,Kovo 1,2020 Kovo pirmoji,Yes");
//            File.WriteAllLines(_path, lines);

//            var sut = new TextFileRepository();

//            // act
//            var result = sut.ReadFromRepository();
//            Event @event = result.Find(x => x.Id == 10);

//            //assert            
//            Assert.AreEqual(3, result.Count);
//            Assert.AreEqual("Naujieji Metai", @event.ShortDescription);
//            Assert.AreEqual("2020 Naujieji metai", @event.LongDescription);
//            Assert.AreEqual(PriorityType.Yes, @event.Priority);
//        }
//    }
//}
