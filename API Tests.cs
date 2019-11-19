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
     private const string adress = "https://www.planitpoker.com/api";
     private const string roomAdress = "https://www.planitpoker.com/api/games/create/";
     private const string newRoomNameAdress = "https://www.planitpoker.com/api/games/edit/";
     private const string deleteRoomAdress = "https://www.planitpoker.com/api/games/delete";
     private const string storyAdress = "https://www.planitpoker.com/api/stories/create/";
     private const string userName = "Iulia";
     private const string roomName = "Teste Room";
     private const string newRoomName = "API Test Room";
     private const string storyName = "Test Story";
     private const int cardType = 4;

      private AuthentificationPage authentification = new AuthentificationPage();


        [Fact]
        public void AuthenticationTest()
        {

            var response = authentification.Authentication($"{adress}/authentication/anonymous", userName);
            Assert.NotNull(response);
        }

        [Fact]
        public void RoomCreation()
        {
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);
            var room = new RoomsPage(adress, cookies);
            room.CreateRoom("Test Room");

            Assert.NotNull(room);
        }

        [Fact]
        public void CardType()
        {
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);
            var room = new RoomsPage(adress, cookies);
            var setCardType = room.SetCradType(cardType, roomName);
            Assert.NotNull(setCardType);
        }

        [Fact]
        public void ChangeRoomName()
        {
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);
            var room = new RoomsPage(adress, cookies);
            var gameInfo = room.CreateRoom("Test Room");
            var changeRoomName = room.NewRoomName("Test Room","Test Room Gigel");
        }
        
        [Fact]
        public void DeteleRoom()
        {
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);
            var room = new RoomsPage(adress, cookies);
            var gameInfo = room.CreateRoom("test");
           var deleteRoom = room.DeteleRoom(roomName);
        }

        [Fact]
        public void CreateStory()
        {
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);
            var room = new RoomsPage(adress, cookie);
            var gameInfo = room.CreateRoom("test");
            var story  = new RoomPage(adress, cookie);
            story.CreateStory("test", "story");
        }
    }
}



