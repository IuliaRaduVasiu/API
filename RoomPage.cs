using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Web;
using OpenQA.Selenium;
using Xunit;
using System;
using OpenQA.Selenium.Chrome;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
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
        public WebResponse CreateStory(string roomName, string storyName)
        {
            var roomInfo = CreateRoom(roomName);
            var roomId = roomInfo.GameId;
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
            
            return response;

        }
    }
}