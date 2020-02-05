using Newtonsoft.Json;

namespace API_tests
{
    public class DeleteStoryBody
    {
        [JsonProperty("gameId")]
        public int GameId { get; set; }
        
        [JsonProperty("storyId")]
        public int StoryId { get; set; }
    }
}