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

        public static async void GetUsers(Action<IEnumerable<ChatUser>> action)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, userAgent);
                    client.Headers.Add(HttpRequestHeader.ContentType, contentType);
                    string url = serverUrl + usersUrl;
                    var response = await client.DownloadStringTaskAsync(url);
                    IEnumerable<ChatUser> users = JsonConvert.DeserializeObject<IEnumerable<ChatUser>>(response);
                    action(users);
                }
                catch (Exception ex)
                {
                    Mediator.Notify("LoadInformationView", new Information() { Title = "Oops!", Message = "Connecting to server failed!" });
                }
            }
        }

        public static async void GetChatHistory(string username, Action<IEnumerable<Message>> action)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, userAgent);
                    client.Headers.Add(HttpRequestHeader.ContentType, contentType);
                    string url = serverUrl + "/" + username;
                    var response = await client.DownloadStringTaskAsync(url);
                    IEnumerable<Message> chatHistory = JsonConvert.DeserializeObject<IEnumerable<Message>>(response);
                    action(chatHistory);
                }
                catch (Exception ex)
                {
                    Mediator.Notify("LoadInformationView", new Information() { Title = "Oops!", Message = "Connecting to server failed!" });
                }
            }
        }
    }
}
