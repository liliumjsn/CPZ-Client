using CPZ_Chat_Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Helpers
{
    public static class RESTProducer
    {
        //TODO: fix action type
        public async static void Connect(ChatUser myProfileObject, Action<IEnumerable<ChatUser>> action)
        {
            using (WebClient client = new WebClient())
            {       
                try
                {
                    var serializerSettings = new JsonSerializerSettings();
                    serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    string myParameters = JsonConvert.SerializeObject(myProfileObject, serializerSettings);
                    client.Headers.Add(HttpRequestHeader.UserAgent, RESTConstants.userAgent);
                    client.Headers.Add(HttpRequestHeader.ContentType, RESTConstants.contentType);
                    string response = await client.UploadStringTaskAsync(RESTConstants.serverUrl + RESTConstants.connectUrl, myParameters);
                    IEnumerable<ChatUser> users = JsonConvert.DeserializeObject<IEnumerable<ChatUser>>(response);
                    //TODO: i also need my profile settings, sto parse it accordingly
                    action(users);
                }
                    catch (Exception ex)
                {
                    Mediator.Notify("LoadInformationView", new Information() { Title = "Oops!", Message = "Connecting to server failed!" });
                }
            }
        }

        //TODO: unfinished
        public static async void SendMessage(string username, Action<IEnumerable<Message>> action)
        {

        }
        //TODO: unfinished
        public static async void SendBroadcast(string username, Action<IEnumerable<Message>> action)
        {

        }
    }
}
