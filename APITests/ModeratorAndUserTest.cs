using Xunit;

namespace API_tests
{
    
    public class ModeratorAndUser
    {
     private const string adress = "https://www.planitpoker.com/api";
     private const string userName = "Iulia";
     private const string roomName = "Teste Room";
     private const string newRoomName = "API Test Room";
     private const string storyName = "Test Story";
     private const int cardType = 4;
     private const int selectedCard = 6;
     private AuthentificationPage authentification = new AuthentificationPage();
       
         [Fact]
         public void ModeratorVotingSession()
        {
            //Scenario: Moderator creates a voting session
            //Given a user creates a temporary account with moderator attributions
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the modetarotor starts a voting session
            var room = new RoomsPage(adress, cookie);
            var gameInfo = room.CreateRoom("test");
            var gameId = gameInfo.GameId.ToString();
            var storyCreation  = new RoomPage(adress, cookie);
            var story = storyCreation.CreateStory(gameId, "story");
            var storyDetails = storyCreation.GetStoryDetails(gameId);
            var startVoting = storyCreation.StartVoting(gameId);

            //Then the moderator can start the voting session
            Assert.NotEqual(startVoting.ToString(), "0");
        }

           [Fact]
         public void GuestAuthentification()
        {
            //Scenario: Moderator creates a voting session
            //Given a user creates a temporary account with moderator attributions
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the modetarotor starts a voting session
            var room = new RoomsPage(adress, cookie);
            var gameInfo = room.CreateRoom("test");
            var gameId = gameInfo.GameId.ToString();
            var storyCreation  = new RoomPage(adress, cookie);
            var story = storyCreation.CreateStory(gameId, "story");
            var storyDetails = storyCreation.GetStoryDetails(gameId);
            var startVoting = storyCreation.StartVoting(gameId);
            var gameCode = gameInfo.GameCode.ToString();
            var guestCookie = authentification.Authentication($"{adress}/authentication/anonymous", "Gigel");

            //Then the moderator can start the voting session
            Assert.NotNull(guestCookie);
        }

            [Fact]
        public void GuestVotingSession()
        {
            //Scenario: Moderator creates a voting session
            //Given a user creates a temporary account with moderator attributions
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the modetarotor starts a voting session
            var room = new RoomsPage(adress, cookie);
            var gameInfo = room.CreateRoom("test");
            var gameId = gameInfo.GameId.ToString();
            var storyCreation  = new RoomPage(adress, cookie);
            var story = storyCreation.CreateStory(gameId, "story");
            var storyDetails = storyCreation.GetStoryDetails(gameId);
            var startVoting = storyCreation.StartVoting(gameId);
            storyCreation.CardSelection(gameId, selectedCard);
            var guestCookie = authentification.Authentication($"{adress}/authentication/anonymous", "Gigel");
            var guestCard = storyCreation.CreateStory(gameId, "story");
            var finishVoting = storyCreation.FnishVoting(gameId, selectedCard);
            
            //Then the moderator can start the voting session
            Assert.NotNull(finishVoting);
        }
        

    }
}