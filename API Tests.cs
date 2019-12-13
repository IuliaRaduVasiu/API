using Xunit;

namespace API_tests
{
    
    public class Class1
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
        public void AuthenticationTest()
        {
            //Scenario: Authentification page
            // Given the user is in the authentification page
            // When he inputs the username

            var response = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            // A temporary user is created

            Assert.NotNull(response);
        }

        [Fact]
        public void RoomCreation()
        {
            //Scenario: Creating a room
            //Given the user has created a username
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user creates a room
            var room = new RoomsPage(adress, cookies);
            room.CreateRoom("Test Room");

            //Then the room is created
            Assert.NotNull(room);
        }

        [Fact]
        public void CardType()
        {
            //Screnatio: Setting the card type
            //Given the user created a temporary username
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user creates a room
            var room = new RoomsPage(adress, cookies);

            //Then the user can set a card type
            var setCardType = room.SetCradType(cardType, roomName);
            Assert.NotNull(setCardType);
        }

        [Fact]
        public void ChangeRoomName()
        {
            //Scenario: Changing the room name
            //Given a user creates a username in the application
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user creates a room
            var room = new RoomsPage(adress, cookies);
            var gameInfo = room.CreateRoom("Test Room");

            //Then the user can change the room name
            var changeRoomName = room.NewRoomName("Test Room","Test Room Gigel");
            Assert.NotNull(changeRoomName);
        }
        
        [Fact]
        public void DeteleRoom()
        {
            //Scenario: Deleting a room
            //Given a user creates a username in the application
            var cookies = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user creates a room
            var room = new RoomsPage(adress, cookies);
            var gameInfo = room.CreateRoom("test");

            //Then the user can delete the room
           var deleteRoom = room.DeteleRoom(roomName);
            Assert.NotNull(deleteRoom);
        }

        [Fact]
        public void CreateStory()
        {
            //Scenario: Creating a story
            //Given a user creates a username in the application
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user creates a room
            var roomsPage = new RoomsPage(adress, cookie);
            var gameInfo = roomsPage.CreateRoom("test");
            var gameId = gameInfo.GameId.ToString();
            var storyCreation = new RoomPage(adress, cookie);
            storyCreation.CreateStory(gameInfo.GameId.ToString(), "story");
            var storyDetails = storyCreation.GetStoryDetails(gameId);

            //Then the user can create a story
            Assert.Equal("story", storyDetails.Title);
        }

            [Fact]
            public void ChangeStoryName()
        {
            //Scenario: Changeing the story name
            // Given a user creates a temporary account
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            // When the user creates a voting session
            var roomsPage = new RoomsPage(adress, cookie);
            var gameInfo = roomsPage.CreateRoom("test");
            var storyCreation  = new RoomPage(adress, cookie);
            var gameId = gameInfo.GameId.ToString();
            var story = storyCreation.CreateStory(gameId, "story");
            var storyId = storyCreation.GetStoryDetails(gameId).Id.ToString();
            var newStoryName = storyCreation.NewStoryName(storyId ,"story3");
            var newStoryDetails = storyCreation.NewStoryDetails(gameId).Title.ToString();

            //Then the user cand change the name
            Assert.Equal("story3", newStoryDetails);
        }

            [Fact]
            public void DeteleteStory()
        {
            //Scenario: Deleting a story
            //Given a user creates a temporary account
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user creates a voting session
            var roomsPage = new RoomsPage(adress, cookie);
            var gameInfo = roomsPage.CreateRoom("test");
            var storyCreation  = new RoomPage(adress, cookie);
            var gameId = gameInfo.GameId.ToString();
            var story = storyCreation.CreateStory(gameId, "story");
            var storyDetails = storyCreation.GetStoryDetails(gameId).Id.ToString();
            var deleteAStory = storyCreation.DeleteStory(gameId, storyDetails);

            //Then the user can detele a story
            Assert.NotNull(deleteAStory);
        }


        [Fact]
        public void StartVoting()
        {
            //Scenario: Starting a voting session
            //Given a user creates a temporary account
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user creates a room
            var room = new RoomsPage(adress, cookie);
            var gameInfo = room.CreateRoom("test");
            var gameId = gameInfo.GameId.ToString();
            var storyCreation  = new RoomPage(adress, cookie);
            var story = storyCreation.CreateStory(gameId, "story");
            var storyDetails = storyCreation.GetStoryDetails(gameId);
            var startVoting = storyCreation.StartVoting(gameId);

            //Then the user cand start a voting session
            Assert.NotEqual(startVoting.ToString(), "0");
        }

        [Fact]
         public void CardSelection()
        {
            //Scenario: Card selectio
            //Given a user creates a temporary account
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user start a voting session
            var room = new RoomsPage(adress, cookie);
            var gameInfo = room.CreateRoom("test");
            var gameId = gameInfo.GameId.ToString();
            var storyCreation  = new RoomPage(adress, cookie);
            var story = storyCreation.CreateStory(gameId, "story");
            var storyDetails = storyCreation.GetStoryDetails(gameId);
            var startVoting = storyCreation.StartVoting(gameId);
            var cardSelectio = storyCreation.CardSelection(gameId, selectedCard);

            //Then the user can select a card
            Assert.NotNull(cardSelectio);

        }

            [Fact]
         public void FinishVoting()
        {
            //Scenario: Card selectio
            //Given a user creates a temporary account
            var cookie = authentification.Authentication($"{adress}/authentication/anonymous", userName);

            //When the user start a voting session
            var room = new RoomsPage(adress, cookie);
            var gameInfo = room.CreateRoom("test");
            var gameId = gameInfo.GameId.ToString();
            var storyCreation  = new RoomPage(adress, cookie);
            var story = storyCreation.CreateStory(gameId, "story");
            var storyDetails = storyCreation.GetStoryDetails(gameId);
            var startVoting = storyCreation.StartVoting(gameId);
            storyCreation.CardSelection(gameId, selectedCard);
            var finishVoting = storyCreation.FnishVoting(gameId, selectedCard);

            //Then the user cand finish the voting session
            Assert.NotNull(finishVoting);
        }

    }
}



