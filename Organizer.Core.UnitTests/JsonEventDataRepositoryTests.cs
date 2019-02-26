using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Organizer.Core.Models;
using Organizer.Core.Services;

namespace Organizer.Core.UnitTests
{
    [TestClass]
    public class JsonEventDataRepositoryTests
    {
        // given ... when ... then ...
        [TestMethod]
        public void Given_DatabaseFileNotExist_When_WritingToDatabase_Then_ShouldCreateEmptyFile()
        {
            // arrange
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(basePath, "datebase.json");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            var sut = new JsonEventDataRepository();
            
            // act
            sut.Write(new List<Event>());

            // assert
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void Given_DatabaseExist_When_WritingToDatabase_Then_ShouldWriteToExistingFile()
        {
            // arrange
            throw new NotImplementedException();
            // act
            // assert
        }

        [TestMethod]
        public void Given_DatabaseFileNotExist_When_ReadingFromDatabase_Then_ShouldCreateEmptyFile()
        {
            // arrange
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(basePath, "datebase.json");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            var sut = new JsonEventDataRepository();

            // act
            var result = sut.Read();

            // assert
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void Given_DatabaseExist_When_ReadingFromDatabase_Then_ShouldReadExistingItems()
        {
            // arrange
            throw new NotImplementedException();
            // act
            // assert
        }

        [TestMethod]
        public void Given_DatabaseExist_When_ReadingEmptyDatabaseFile_Then_ShouldReturnEmptyList()
        {
            // arrange
            // TODO: move repeating path logic to TestInitialise method

            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(basePath, "datebase.json");
            File.WriteAllText(path, string.Empty);

            var sut = new JsonEventDataRepository();
            
            // act
            var result = sut.Read();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestInitialize]
        public void TestSetup()
        {
            
        }
    }
}
