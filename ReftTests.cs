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
     private const string newStoryName = "Gigel";
     private const int cardType = 4;
     private const int selectedCard = 6;
    
     private AuthentificationPage authentification = new AuthentificationPage();
        [Fact]
        public async void Authentification()
        {
            //Scenario: Authentification page
            // Given the user is in the authentification page
            // When he inputs the username

             var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // A temporary user is created

            Assert.NotNull(response);
        }



        [Fact]
        public async void CreateRoom()
        {
             //Scenario: Creating a room
            //Given the user has created a username
             var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

              //When the user creates a room

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
            var info = await roomActions.GetRoomInfo(roomDetails);

            //Then the room is created

            Assert.NotNull(info);
        }
              [Fact]
        public async void NewRommName()
        {
             //Scenario: Changing the room name
            //Given a user creates a username in the application

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a room

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
            var info = await roomActions.GetRoomInfo(roomDetails);   

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

            //Then the user can change the room name
            Assert.NotNull(newInfo);
        }

              [Fact]
        public async void DeteleRoom()
        {
            //Scenario: Deleting a room
            //Given a user creates a username in the application

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a room

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
            var info = await roomActions.GetRoomInfo(roomDetails);

            //Then the user can delete the room
            var delete = RestService.For<RoomsPageInterface.DeleteRoom>(adress);


        }

             [Fact]
        public async void CardSelection()
        {
            //Screnatio: Setting the card type
            //Given the user created a temporary username

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a room

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

            //Then the user can set a card type
            var info = await roomActions.GetRoomInfo(roomDetails);
        }

              [Fact]
        public async void CreateStory()
        {
             //Scenario: Creating a story
            //Given a user creates a username in the application

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a room

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
            var info = await roomActions.GetRoomInfo(roomDetails);

            var storyDetails = new StoryBody
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<RoomPageInterface.StoryActions>(client);
            var storyInfo = await storyActions.GetStory(storyDetails, storyDetails);

              var allStoryNameDetails = new StoryDetailsBody 
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<RoomPageInterface.StoryActions>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            //Then the user can create a story
            Assert.Equal(allStoryDetails.Stories[0].Title, storyName);
        }


              [Fact]
        public async void NewStoryName()
        {
            //Scenario: Changeing the story name
            // Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // When the user creates a voting session

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
            var info = await roomActions.GetRoomInfo(roomDetails);

            var storyDetails = new StoryBody
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<RoomPageInterface.StoryActions>(client);
            var storyInfo = await storyActions.GetStory(storyDetails, storyDetails);

            var allStoryNameDetails = new StoryDetailsBody 
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<RoomPageInterface.StoryActions>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            
             var newStoryNameDetails = new UpdateStoryBody 
            {
                StoryId = allStoryDetails.Stories[0].Id,
                Title = newStoryName
            };
            var newstoryDetailsList = RestService.For<RoomPageInterface.StoryActions>(client);
            var newStoryDetails = await storyDetailsList.ChangeStoryName(newStoryNameDetails);

            allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            //Then the user cand change the name
            Assert.Equal(allStoryDetails.Stories[0].Title, newStoryName);
        }

                 [Fact]
        public async void DeleteStory()
        {
            //Scenario: Deleting a story
            //Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a voting session

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
            var info = await roomActions.GetRoomInfo(roomDetails);

            var storyDetails = new StoryBody
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<RoomPageInterface.StoryActions>(client);
            var storyInfo = await storyActions.GetStory(storyDetails, storyDetails);

            var allStoryNameDetails = new StoryDetailsBody 
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<RoomPageInterface.StoryActions>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            var deleteDetails = new DeleteStoryBody
            {
                GameId = info.GameId,
                StoryId = allStoryDetails.Stories[0].Id
            };
            var deleteStoryDetails = RestService.For<RoomPageInterface.StoryActions>(client);

            //Then the user can detele a story

            var deleteInfo = await deleteStoryDetails.DeleteStory(deleteDetails);

        }

             [Fact]
             public async void StartVoting()
        {
            //Scenario: Starting a voting session
            //Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

             //When the user creates a room

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
            var info = await roomActions.GetRoomInfo(roomDetails);

            var storyDetails = new StoryBody
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<RoomPageInterface.StoryActions>(client);
            var storyInfo = await storyActions.GetStory(storyDetails, storyDetails);

              var allStoryNameDetails = new StoryDetailsBody 
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<RoomPageInterface.StoryActions>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

               var startBody = new  StartVotingBody
            {
                GameId = info.GameId
            };
            var stratActions = RestService.For<RoomPageInterface.StartVoting>(client);
            var startDetails = await stratActions.Start(startBody);

            //Then the user cand start a voting session
            Assert.NotNull(stratActions);
        }

            [Fact]
             public async void SelectCard()
        {
            //Scenario: Card selectio
            //Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user start a voting session

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
            var info = await roomActions.GetRoomInfo(roomDetails);

            var storyDetails = new StoryBody
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<RoomPageInterface.StoryActions>(client);
            var storyInfo = await storyActions.GetStory(storyDetails, storyDetails);

              var allStoryNameDetails = new StoryDetailsBody 
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<RoomPageInterface.StoryActions>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

               var startBody = new  StartVotingBody
            {
                GameId = info.GameId
            };
            var stratActions = RestService.For<RoomPageInterface.StartVoting>(client);
            var startDetails = await stratActions.Start(startBody);

            var selectedVote = new VotingBody
            {
                GameId = info.GameId,
                Vote = selectedCard
            };
            var voteActions = RestService.For<RoomPageInterface.StartVoting>(client);

            //Then the user can select a card
        }

            [Fact]
             public async void FinishVotingSession()
        {
            //Scenario: Card selectio
            //Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user start a voting session

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
            var info = await roomActions.GetRoomInfo(roomDetails);

            var storyDetails = new StoryBody
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<RoomPageInterface.StoryActions>(client);
            var storyInfo = await storyActions.GetStory(storyDetails, storyDetails);

              var allStoryNameDetails = new StoryDetailsBody 
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<RoomPageInterface.StoryActions>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

               var startBody = new  StartVotingBody
            {
                GameId = info.GameId
            };
            var stratActions = RestService.For<RoomPageInterface.StartVoting>(client);
            var startDetails = await stratActions.Start(startBody);

            var selectedVote = new VotingBody
            {
                GameId = info.GameId,
                Vote = selectedCard
            };
            var voteActions = RestService.For<RoomPageInterface.StartVoting>(client);   

            
            var finishVotingBody = new FinishVotingBody
            {
                GameId = info.GameId,
                Estimate = selectedCard
            };
            var finishVotingActions = RestService.For<RoomPageInterface.FinishVoting>(client); 

            //Then the user cand finish the voting session
        }
    }
}