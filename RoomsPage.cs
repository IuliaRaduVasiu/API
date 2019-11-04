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
using Newtonsoft.Json.Linq;

namespace API_tests
{
    public class RoomsPage
    {
        public WebResponse CreateRoom(string roomAdress, string adress, string userName,string roomName)
        {
            var cookie = new CallsClass().Authentication(adress ,userName);
            var request = HttpWebRequest.Create(adress);
            request.Method = "POST"; 
            string body = $"name={roomName}&cardSetType=1&haveStories=true&confirmSkip=true&showVotingToObservers=true&autoReveal=true&changeVote=false&countdownTimer=false&countdownTimerValue=30"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("cookies", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
          
            return response;

        }

        public WebResponse SetCradType (string cardSetType, string roomAdress, string adress, string userName,string roomName)
        {
            var cookie = new CallsClass().Authentication(adress ,userName);
            var request = HttpWebRequest.Create(adress);
            request.Method = "POST"; 
            string body = $"name={roomName}&cardSetType={cardSetType}&haveStories=true&confirmSkip=true&showVotingToObservers=true&autoReveal=true&changeVote=false&countdownTimer=false&countdownTimerValue=30"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("cookies", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            return response;
        }

        public WebResponse NewRoomName(string adress, string newRoomName)
        {
            var request = HttpWebRequest.Create(adress);
            request.Method = "POST";
            string body = $"id=406011&name={newRoomName}+test&cardSetType=1&haveStories=true&confirmSkip=true&showVotingToObservers=true&autoReveal=true&changeVote=false&countdownTimer=false&countdownTimerValue=30"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            
            return response;
        }


         public int CreateRoomForDelete(string roomAdress, string adress, string userName,string roomName)
        {
           // var cookie = new CallsClass().Authentication(adress ,userName);
            var request = HttpWebRequest.Create(adress);
            request.Method = "POST"; 
            string body = $"name={roomName}&cardSetType=1&haveStories=true&confirmSkip=true&showVotingToObservers=true&autoReveal=true&changeVote=false&countdownTimer=false&countdownTimerValue=30"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            var cookie = request.Headers["cookie"]; 
           // request.Headers.Add("cookies", cookie);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            JObject responseJson = JObject.Parse(response.ToString());
            int roomId = Convert.ToInt32(responseJson.SelectToken("gameId"));
            return roomId;
        }
        public WebResponse DeteleRoom(string deleteAdress, string roomAdress, string adress, string userName,string roomName)
        {
            var roomId = CreateRoomForDelete(roomAdress, adress, userName, roomName);
            var request = HttpWebRequest.Create(deleteAdress);
            //var roomId = room;
            request.Method = "DELETE";
            string body = $"id= {roomId}";
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            var response = request.GetResponse();
            
            return response;   
        }
    }
}
