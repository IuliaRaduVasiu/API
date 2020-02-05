
using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace API_tests
{
    public class RoomPageInterface
    {
        private string url;
        private string cookie;

        public RoomPageInterface(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

             public interface StoryActions
        {
            [Post("/stories/create/")]
            Task<StoryInfo> GetStory([Body(BodySerializationMethod.UrlEncoded)] StoryBody roomId, StoryBody name);

            [Post("/stories/get/")]
            Task<StoryList> GetStoryDetails([Body(BodySerializationMethod.UrlEncoded)] StoryDetailsBody roomDetails); //Intoarce o lista cu toare story-urile dintr-un room

            [Post("/stories/update/")]
            Task<StoryList> ChangeStoryName([Body(BodySerializationMethod.UrlEncoded)] UpdateStoryBody newStoryName);

            [Post("/stories/delete/")]
            Task<StoryList> DeleteStory([Body(BodySerializationMethod.UrlEncoded)] DeleteStoryBody storyId);

        }

            public interface StartVoting
            {
                [Post("/stories/next/")]
                Task<StartVotingDetails> Start([Body(BodySerializationMethod.UrlEncoded)] StartVotingBody gameId);

                [Post("/stories/vote/")]
                Task SelectedCard([Body(BodySerializationMethod.UrlEncoded)] VotingBody gameId);
            }

            public interface FinishVoting
            {
                [Post("/stories/finish/")]
                Task Finish([Body(BodySerializationMethod.UrlEncoded)] FinishVotingBody gameId);
            }
            
    }
}