using CPZ_Chat_Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Helpers
{
    public static class RESTConsumer
    {

        private static string serverUrl = "https://my-json-server.typicode.com/liliumjsn/CPZ-JSON-Test";
        private static string usersUrl = "/Users";
        private static string contentType = "application/json";
        private static string userAgent = "CPZ-Client";

        public static IEnumerable<ChatUser> GetUsers()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, userAgent);
                    client.Headers.Add(HttpRequestHeader.ContentType, contentType);
                    string url = serverUrl + usersUrl;
                    var response = client.DownloadString(url);
                    IEnumerable<ChatUser> users = JsonConvert.DeserializeObject<IEnumerable<ChatUser>>(response);
                    return users;
                }
                catch (Exception ex)
                {
                    Mediator.Notify("Error", new Information() { Title = "Oops!", Message = "Connecting to server failed!" });
                }
                return null;
            }
        }

        public static IEnumerable<Message> GetChatHistory(string username)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, userAgent);
                    client.Headers.Add(HttpRequestHeader.ContentType, contentType);
                    string url = serverUrl + "/" + username;
                    var response = client.DownloadString(url);
                    IEnumerable<Message> chatHistory = JsonConvert.DeserializeObject<IEnumerable<Message>>(response);
                    return chatHistory;
                }
                catch (Exception ex)
                {
                    Mediator.Notify("Error", new Information() { Title = "Oops!", Message = "Connecting to server failed!" });
                }
                return null;
            }
        }
    }
}
