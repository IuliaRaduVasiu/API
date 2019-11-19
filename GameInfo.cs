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
    public class GameInfo
    {
        public int GameId { get; set; }
        
        public string GameCode { get; set; }
    }
}