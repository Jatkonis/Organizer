//using System;
//using System.Collections.Generic;
//using System.IO;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Newtonsoft.Json;
//using Organizer.Core.Models;
//using Organizer.Core.Services;

//namespace Organizer.Core.UnitTests
//{
//    [TestClass]
//    public class JsonEventDataRepositoryTests
//    {
//        string path;
//        List<Event> eventList = new List<Event>();

//        [TestInitialize]        
//        public void Setup()
//        {                  
//            var basePath = AppDomain.CurrentDomain.BaseDirectory;
//            path = Path.Combine(basePath, "datebase.json");

//            eventList.Add(new Event() { Id = 1, Date = DateTime.Parse("2019.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 });
//            eventList.Add(new Event() { Id = 2, Date = DateTime.Parse("2019.05.27"), ShortDescription = "Manto", LongDescription = "Manto Gimtadienis", Priority = 0 });

//            File.Delete(path);
//            var fileInJsonFormat = JsonConvert.SerializeObject(eventList, Formatting.Indented);
//            File.WriteAllText(path, fileInJsonFormat);
//        }

//        [TestMethod]
//        public void Given_DatabaseFileNotExist_When_WritingToDatabase_Then_ShouldCreateEmptyFile()
//        {
//            // arrange
//            if (File.Exists(path))
//            {
//                File.Delete(path);
//            }
//            var sut = new JsonEventDataRepository();
            
//            // act
//            sut.WriteToRepository(new List<Event>());

//            // assert
//            Assert.IsTrue(File.Exists(path));
//        }


//        [TestMethod]
//        public void Given_DatabaseExist_When_WritingToDatabase_Then_ShouldWriteToExistingFile()
//        {
//            // arrange     
//            var sut = new JsonEventDataRepository();
//            eventList.Add(new Event { Id = 3, Date = new DateTime(2019, 09, 01), ShortDescription = "Rugsejo 1", LongDescription = "Mokslo svente Rugsejo pirmoji", Priority = 0 });            

//            // act   
//            sut.WriteToRepository(eventList);

//            // assert
//            var updatedJsonFile = File.ReadAllText(path);
//            var allEvents = JsonConvert.DeserializeObject<List<Event>>(updatedJsonFile);

//            Assert.AreEqual(allEvents.Count, 3);

//        }

//        [TestMethod]
//        public void Given_DatabaseFileNotExist_When_ReadingFromDatabase_Then_ShouldCreateEmptyFile()
//        {
//            // arrange            
//            if (File.Exists(path))
//            {
//                File.Delete(path);
//            }
//            var sut = new JsonEventDataRepository();

//            // act
//            var result = sut.ReadFromRepository();

//            // assert
//            Assert.IsTrue(File.Exists(path));
//        }

//        [TestMethod]
//        public void Given_DatabaseExist_When_ReadingFromDatabase_Then_ShouldReadExistingItems()
//        {
//            // arrange
//            var sut = new JsonEventDataRepository();           

//            var existingDataInJsonFormat = File.ReadAllText(path);
//            var actual = JsonConvert.DeserializeObject<List<Event>>(existingDataInJsonFormat);
            
//            // act
//            var result = sut.ReadFromRepository();

//            // assert
//            Assert.AreEqual(result.Count, actual.Count);       
//        }

//        [TestMethod]
//        public void Given_DatabaseExist_When_ReadingEmptyDatabaseFile_Then_ShouldReturnEmptyList()
//        {
//            // arrange            
//            File.WriteAllText(path, string.Empty);

//            var sut = new JsonEventDataRepository();
            
//            // act
//            var result = sut.ReadFromRepository();

//            // assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(0, result.Count);
//        }
//    }
//}
