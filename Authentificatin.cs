using System.Net;
using System.IO;
using System.Text;

namespace API_tests
{
    public class AuthentificationPage
    {
        public string Authentication(string adress,string userName)
        {
            var request = HttpWebRequest.Create(adress);
            request.Method = "POST"; 
            string body = $"name={userName}"; 
            byte[] byteArray = Encoding.UTF8.GetBytes(body);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            var response = request.GetResponse();
            var setCookie = response.Headers["set-cookie"]; 

           return setCookie;
        }
    }
}

  
