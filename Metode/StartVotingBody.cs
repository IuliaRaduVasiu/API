using Newtonsoft.Json;

namespace API_tests
{
    public class StartVotingBody
    {
        [JsonProperty("gameId")]
        public int GameId { get; set; }
    }
}