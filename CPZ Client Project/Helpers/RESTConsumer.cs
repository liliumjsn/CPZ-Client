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
        

        public static async void GetUsers(Action<IEnumerable<ChatUser>> action)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    RESTConstants.AddHeaders(client);
                    string url = RESTConstants.serverUrl + RESTConstants.usersUrl;
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
        //TODO: send userd id, NOT username
        public static async void GetChatHistory(string username, Action<IEnumerable<Message>> action)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    RESTConstants.AddHeaders(client);
                    string url = RESTConstants.serverUrl + "/" + username;
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
        //TODO: unfinished
        public static async void GetRecents(string username, Action<IEnumerable<Message>> action)
        {
            
        }
        //TODO: unfinished
        public static async void GetNewMessages(string username, Action<IEnumerable<Message>> action)
        {
            
        }
        //TODO: unfinished
        public static async void GetGroups(string username, Action<IEnumerable<Message>> action)
        {

        }
    }
}
