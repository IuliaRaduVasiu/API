using Xunit;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using System;

namespace API_tests
{
    
    public class Tests

    {
     private const string adress = "https://www.planitpoker.com/api";
     private const string userName = "Iulia";
     private const string roomName = "Teste Room";
     private const string newName = "Test Room2";
     private const string storyName = "Test Story";
     private const int cardType = 4;
     private const int selectedCard = 6;
     private  int gameId = new GameInfo().GameId;
     private AuthentificationPage authentification = new AuthentificationPage();

        [Fact]
        public async void CreateRoom()
        {
             var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var roomDetails = new RoomBody
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<RoomsPageInterface.RoomActions>(client);
            var info = await roomActions.GetRoomInfo(roomDetails,roomDetails);
        }

              [Fact]
        public async void NewRommName()
        {
          var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var roomDetails = new RoomBody
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<RoomsPageInterface.RoomActions>(client);
            var info = await roomActions.GetRoomInfo(roomDetails, roomDetails);   

              var newRoomDetails = new RoomBody
            {
                name = newName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var newRoomName = RestService.For<RoomsPageInterface.NewRoomNameInterface>(client);
            var newInfo = await newRoomName.GetRoomInfo(newRoomDetails);
        }

              [Fact]
        public async void DeteleRoom()
        {
            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var roomDetails = new RoomBody
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<RoomsPageInterface.RoomActions>(client);
            var info = await roomActions.GetRoomInfo(roomDetails, roomDetails);
            var delete = RestService.For<RoomsPageInterface.DeleteRoom>(adress);
        }

             [Fact]
        public async void CardSelection()
        {
            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var roomDetails = new RoomBody
            {
                name = roomName,
                cardSetType = cardType,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<RoomsPageInterface.RoomActions>(client);
            var info = await roomActions.GetRoomInfo(roomDetails, roomDetails);
           
        }

              [Fact]
        public async void CreateStory()
        {
             var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var roomDetails = new RoomBody
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<RoomsPageInterface.RoomActions>(client);
            var info = await roomActions.GetRoomInfo(roomDetails,roomDetails);

            var storyDetails = new StoryBody
            {
                RoomId = new GameInfo().GameId,
                name = storyName
            };
            var storyActions = RestService.For<RoomPageInterface.StoryActions>(client);
            var storyInfo = await storyActions.GetStoryInfo(gameId, storyDetails);
        }


    }
}