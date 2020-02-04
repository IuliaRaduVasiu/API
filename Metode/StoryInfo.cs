using System.Collections.Generic;
using Newtonsoft.Json;

namespace API_tests
{
    public class StoryInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("gameId")]
        public int GameId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("shownTitle")]
        public string ShownTitle { get; set; }

        [JsonProperty("isCurrent")]
        public bool IsCurrent { get; set; }

        [JsonProperty("estimate")]
        public object Estimate { get; set; }

        [JsonProperty("estimateText")]
        public object EstimateText { get; set; }

        [JsonProperty("minEstimateText")]
        public string MinEstimateText { get; set; }

        [JsonProperty("maxEstimateText")]
        public string MaxEstimateText { get; set; }

        [JsonProperty("fastest")]
        public string Fastest { get; set; }

        [JsonProperty("slowest")]
        public string Slowest { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("votingStart")]
        public object VotingStart { get; set; }

        [JsonProperty("votingDuration")]
        public object VotingDuration { get; set; }

        [JsonProperty("averageVotingTime")]
        public object AverageVotingTime { get; set; }

        [JsonProperty("haveStories")]
        public bool HaveStories { get; set; }

        [JsonProperty("votes")]
        public List<object> Votes { get; set; }
    }

}