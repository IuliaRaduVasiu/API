using Newtonsoft.Json;

namespace API_tests
{
    public class GameInfo
    {
        [JsonProperty("gameId")]
        public int GameId { get; set; }
        
        [JsonProperty("gameCode")]
        public string GameCode { get; set; }
    }
}