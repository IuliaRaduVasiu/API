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

        public StoryInfo GetStoryDetails(string roomInfo, string storyName)
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

        public WebResponse NewStoryName(string roomInfo, string storyName, string newStoryName)
{
            var storyInfo = GetStoryDetails(roomInfo, storyName);
            var storyId = storyInfo;
            var request = HttpWebRequest.Create($"{url}/stories/details/");
            request.Method = "POST"; 
            string body = $"storyId={storyId}&gameId={roomInfo}"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Cookie", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            
            return response;
        }

        public WebResponse StartVoting (string roomInfo)
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
            
            return response;
        }
    }
}