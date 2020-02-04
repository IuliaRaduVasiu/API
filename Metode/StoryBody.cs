using Newtonsoft.Json;
namespace API_tests
{
        public class StoryBody
    {
        [JsonProperty("gameId")]
          public int RoomId {get; set; }
          public string name {get; set;}

    }
}