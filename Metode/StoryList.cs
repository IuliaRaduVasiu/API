using System.Collections.Generic;
using Newtonsoft.Json;

namespace API_tests
{
     public class StoryList
    {
        [JsonProperty("stories")]
        public List<StoryInfo> Stories { get; set; }

        [JsonProperty("storiesCount")]
        public int StoriesCount { get; set; }
    }
}