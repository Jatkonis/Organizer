using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Organizer.Core.Models;
using Organizer.Core.Services;
using System;
using System.Collections.Generic;

namespace Organizer.Core.UnitTests
{
    //[TestClass]
    //public class SqlRepositoryTests
    //{
    //    List<Event> eventList = new List<Event>();
    //    private SqlRepository sut;

    //    [TestMethod]
    //    public void When_CreatingNewEvent_Then_ShouldAddEventToDataBase()
    //    {
    //        //Arrange
    //        eventList.Add(new Event() { Id = 1, Date = DateTime.Parse("2019.02.15"), ShortDescription = "Sandros", LongDescription = "Sandros Gimtadienis", Priority = 0 });
    //        eventList.Add(new Event() { Id = 2, Date = DateTime.Parse("2019.05.27"), ShortDescription = "Manto", LongDescription = "Manto Gimtadienis", Priority = 0 });

    //        var mock = new Mock<IEventStore>();
    //        mock.Setup(x => x.GetEventByDescription(It.IsAny<string>())).Returns(eventList);
    //        sut = new SqlRepository(mock.Object);



    //        //Act

    //        //Assert
    //    }

        //[TestMethod]
        //public void When_DeleteExistingEventById_Then_ShouldDeleteThatEventFromDataBase()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}

        //[TestMethod]
        //public void When__Then_()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}

        //[TestMethod]
        //public void Given__When__Then_()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}

        //[TestMethod]
        //public void Given__When__Then_()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}

   }
//}



//[TestMethod]
//public void Remove_ShouldDeteteEventById()
//{
//    //arange
//    var mock = new Mock<IEventRepositories>();
//    mock.Setup(x => x.GetAllEvents()).Returns(eventList);
//    _sut = new EventStore(mock.Object);            

//    //act
//    _sut.Remove(1);           

//    //assert
//    Assert.AreEqual(1, eventList.Count());
//}

//[TestMethod]
//public void Given_GetEventsByDescription_When_DisplayEvents_Then_ShowCorrectValue()
//{
//    // arrange
//    var actual = eventList.Find(x => x.ShortDescription == "Manto");            

//    //act
//    var fullList = _sut.GetEventByDescription("Manto");
//    var result = fullList.First();


//    //assert
//    Assert.AreEqual(actual.LongDescription, result.LongDescription);
//}

//[TestMethod]
//public void Given_ExistingEventListMember_When_UpdateEventInfo_Then_EventShouldBeUpdated()
//{
//    //arrage
//    var @event = eventList.Find(x => x.Id == 1);

//    @event.LongDescription = "Manto penktasis Gimtadienis";

//    //act            
//    var result = _sut.Update(@event);

//    //assert
//    Assert.AreEqual("Manto penktasis Gimtadienis", result.LongDescription);
//}

//[TestMethod]
//public void Given_EventsList_When_AddNewEventToList_Then_ListWasUpdated()
//{
//    //arrange

//    //act
//    _sut.Add(new Event { Id = 3, Date = new DateTime(2019, 06, 28), ShortDescription = "Pauliaus", LongDescription = "Pauliaus Gimtadienis", Priority = 0 });

//    //assert
//    Assert.AreEqual(3, eventList.Count);
//}