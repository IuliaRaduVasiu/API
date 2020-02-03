
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
            Task<StoryInfo> GetStory([Body(BodySerializationMethod.UrlEncoded)] int gameId, StoryBody name);
            

        }
    }
}