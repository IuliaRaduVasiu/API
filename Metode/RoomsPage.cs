using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace API_tests
{
    public class RoomsPage
    {
        private string url;
        private string cookie;

        public RoomsPage(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

        public GameInfo CreateRoom(string roomName)
        {
            var request = HttpWebRequest.Create($"{url}/games/create/");
            request.Method = "POST"; 
            string body = $"name={roomName}&cardSetType=1&haveStories=true&confirmSkip=true&showVotingToObservers=true&autoReveal=true&changeVote=false&countdownTimer=false&countdownTimerValue=30"; 
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
            return JsonConvert.DeserializeObject<GameInfo>(json);
        }


        

        public WebResponse SetCradType (int cardType, string roomName)
        {
            var request = HttpWebRequest.Create($"{url}/games/create/");
            request.Method = "POST"; 
            string body = $"name={roomName}&cardSetType={cardType}&haveStories=true&confirmSkip=true&showVotingToObservers=true&autoReveal=true&changeVote=false&countdownTimer=false&countdownTimerValue=30"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            return response;
        }

        public WebResponse NewRoomName(string roomName, string newRoomName)
        {
            var roomInfo = CreateRoom(roomName);
            var request = HttpWebRequest.Create($"{url}/games/edit/");
            request.Method = "POST";
            var roomId = roomInfo;
            string body = $"id={roomId}&name={newRoomName}+test&cardSetType=1&haveStories=true&confirmSkip=true&showVotingToObservers=true&autoReveal=true&changeVote=false&countdownTimer=false&countdownTimerValue=30"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            
            return response;
        }


       
        public WebResponse DeteleRoom(string roomName)
        {
            var roomInfo = CreateRoom(roomName);
            var roomId = roomInfo.GameId;
            var request = HttpWebRequest.Create($"{url}/games/delete");
            request.Method = "DELETE";
            string body = $"id= {roomId}";
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            
            return response;   
        }



    }
}
