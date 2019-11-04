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

namespace API_tests
{
    public class RoomPage
    {
        public WebResponse CreateStory(string storyAdress, string storyName)
        {
            var request = HttpWebRequest.Create(storyAdress);
            request.Method = "POST"; 
            string body = $"gameId=407659&name={storyName}"; 
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