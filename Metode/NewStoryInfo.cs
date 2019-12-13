using System.Collections.Generic;


namespace API_tests
{
    public class NewStoryInfo
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public string ShownTitle { get; set; }
        public bool IsCurrent { get; set; }
        public object Estimate { get; set; }
        public object EstimateText { get; set; }
        public string MinEstimateText { get; set; }
        public string MaxEstimateText { get; set; }
        public string Fastest { get; set; }
        public string Slowest { get; set; }
        public int Status { get; set; }
        public object VotingStart { get; set; }
        public object VotingDuration { get; set; }
        public object AverageVotingTime { get; set; }
        public bool HaveStories { get; set; }
        public List<object> Votes { get; set; }
    }

}