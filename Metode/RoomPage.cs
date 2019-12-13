using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace API_tests
{
    public class RoomPage
    {
        private string url;
        private string cookie;

        public RoomPage(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }
        public WebResponse CreateStory(string roomId, string storyName)
        {

            var request = HttpWebRequest.Create($"{url}/stories/create/");
            request.Method = "POST"; 
            string body = $"gameId={roomId}&name={storyName}"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var json = streamReader.ReadToEnd();

            return response;

        }

            public StoryInfo GetStoryDetails(string roomInfo)
        {
            var request = HttpWebRequest.Create($"{url}/stories/get/");
            request.Method = "POST";
            string body = $"gameId={roomInfo}&page=1&skip=0&perPage=25&status=0";
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var json = streamReader.ReadToEnd();
            var storyList = JsonConvert.DeserializeObject<StoryList>(json);
            var storycontent = storyList;
            var element = storycontent;
            return storyList.Stories[0];
        }

        public WebResponse NewStoryName(string storyId,  string newStoryName)
        {
            var request = HttpWebRequest.Create($"{url}/stories/update/");
            request.Method = "POST"; 
            string body = $"storyId={storyId}&title={newStoryName}&estimate="; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var json = streamReader.ReadToEnd();
            
            return response;
        }

            public NewStoryInfo NewStoryDetails(string roomInfo)
        {
            var request = HttpWebRequest.Create($"{url}/stories/get/");
            request.Method = "POST";
            string body = $"gameId={roomInfo}&page=1&skip=0&perPage=25&status=0";
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var json = streamReader.ReadToEnd();
            var storyList = JsonConvert.DeserializeObject<NewStoryList>(json);
            var storycontent = storyList;
            var element = storycontent;
            return storyList.Stories[0];
        }

        public WebResponse DeleteStory(string roomInfo, string storyId)
        {

            var request = HttpWebRequest.Create($"{url}/stories/delete/");
            request.Method = "POST"; 
            string body = $"gameId={roomInfo}&storyId={storyId}"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            
            return response;
        }

        public StartVotingInfo StartVoting (string roomInfo)
        {
            var request = HttpWebRequest.Create($"{url}/stories/next/");
            request.Method = "POST"; 
            string body = $"gameId={roomInfo}"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<StartVotingInfo>(json);
        }

        public WebResponse CardSelection (string roomInfo, int selectedCard)
        {
            var request = HttpWebRequest.Create($"{url}/stories/vote/");
            request.Method = "POST"; 
            string body = $"gameId={roomInfo}&vote={selectedCard}"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var json = streamReader.ReadToEnd();

            return response;
        }

            public WebResponse FnishVoting (string roomInfo, int selectedCard)
        {
            var request = HttpWebRequest.Create($"{url}/stories/finish/");
            request.Method = "POST"; 
            string body = $"gameId={roomInfo}&estimate={selectedCard}"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var json = streamReader.ReadToEnd();

            return response;
        }

    }
}