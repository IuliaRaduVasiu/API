using System.Net.Http;
using System.Net;
using System.IO;
using System.Web;
using OpenQA.Selenium;
using Xunit;
using System;
using OpenQA.Selenium.Chrome;

namespace API_tests
{
    
    public class Class1
    {
     private const string adress = "https://www.planitpoker.com/api/authentication/anonymous";
     private const string roomAdress = "https://www.planitpoker.com/api/games/create/";
     private const string newRoomNameAdress = "https://www.planitpoker.com/api/games/edit/";
     private const string deleteRoomAdress = "https://www.planitpoker.com/api/games/delete";
     private const string storyAdress = "https://www.planitpoker.com/api/stories/create/";
     private const string userName = "Iulia";
     private const string roomName = "Teste Room";
     private const string newRoomName = "API Test Room";
     private const string storyName = "Test Story";
     private const string cardType = "4";

      private CallsClass calls = new CallsClass();
     private RoomsPage rooms = new RoomsPage();


        [Fact]
        public void AuthenticationTest()
        {

            var response = calls.Authentication(adress, userName);
            Assert.NotNull(response);
        }

        [Fact]
        public void RoomCreation()
        {
            var room = rooms.CreateRoom(roomAdress, adress,userName,roomName);
            Assert.NotNull(room);
        }
        [Fact]
        public void CardType()
        {
            var setCardType = rooms.SetCradType(cardType, roomAdress, adress,userName,roomName);
            Assert.NotNull(setCardType);
        }
        [Fact]
        public void ChangeRoomName()
        {
            var chageRoomName = rooms.NewRoomName(newRoomNameAdress,newRoomName);
        }
        
        [Fact]
        public void DeteleRoom()
        {
            var room = rooms.CreateRoomForDelete(roomAdress, adress,userName,roomName);
            var deleteRoom = rooms.DeteleRoom(deleteRoomAdress, roomAdress, adress, userName, roomName);
        }

        // [Fact]
        // public void CreateStory()
        // {
        //     var story  = new RoomPage().CreateStory(storyAdress, storyName);
        // }
    }
}



