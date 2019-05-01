using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Helpers
{
    public static class RESTConstants
    {       
        public static string serverUrl = "https://my-json-server.typicode.com/liliumjsn/CPZ-JSON-Test";
        //public static string serverUrl = "";
        public static string connectUrl = "/api/users/connect/";
        public static string usersUrl = "/Users";
        public static string contentType = "application/json";
        public static string userAgent = "CPZ-Client";
        public static void AddHeaders(WebClient client)
        {
            client.Headers.Add(HttpRequestHeader.UserAgent, RESTConstants.userAgent);
            client.Headers.Add(HttpRequestHeader.ContentType, RESTConstants.contentType);
        }
    }
}
