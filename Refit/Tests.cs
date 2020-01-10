using Xunit;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;


namespace API_tests
{
    
    public class Tests

    {
     private const string adress = "https://www.planitpoker.com/api";
     private const string userName = "Iulia";
     private const string roomName = "Teste Room";
     private const string newRoomName = "API Test Room";
     private const string storyName = "Test Story";
     private const int cardType = 4;
     private const int selectedCard = 6;
    private Authentification authentification = new Authentification();
    
    
              [Fact]
        public async void DeteleRoom()
        {
            //Scenario: Deleting a room
            //Given a user creates a username in the application
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user creates a room
            var room = new RoomsPage(adress, cookies);

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
            var gameinfo = RestService.For<RoomActions>(adress);
            var delete = RestService.For<DeleteRoom>(adress);
            var roomSomething = await gameinfo.GetRoomInfo(roomDetails);

            //Then the user can delete the room
        }

    }
}