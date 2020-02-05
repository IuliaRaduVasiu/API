using Newtonsoft.Json;
namespace API_tests
{
        public class VotingBody
    {
        [JsonProperty("gameId")]
          public int GameId {get; set; }

          [JsonProperty("vote")]
          public int Vote {get; set;}

    }
}