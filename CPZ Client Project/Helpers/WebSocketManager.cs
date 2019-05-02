using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;
using System.Threading;

namespace CPZ_Chat_Client.Helpers
{
    public static class WebSocketManager
    {
        private static string uri = "ws://echo.websocket.org:80";
        private static WebSocket ws;
        private static bool isWsOpened = false;
        public static void InitializeWebSocketService()
        {
            ws = new WebSocket(uri);
            ws.Error += Ws_Error;
            ws.Opened += Ws_Opened;
            ws.MessageReceived += Ws_MessageReceived;
            ws.Closed += Ws_Closed;
            ws.Open();
        }
        public static void SendMessage(string message)
        {
            
        }
        private static void Ws_Opened(object sender, EventArgs e)
        {
            isWsOpened = true;
            ws.Send("test");
        }
        private static void Ws_Error(object sender, EventArgs e)
        {
            
        }
        private static void Ws_Closed(object sender, EventArgs e)
        {
            isWsOpened = false;
        }

        private static void Ws_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            int i = 0;
        }
    }
}
