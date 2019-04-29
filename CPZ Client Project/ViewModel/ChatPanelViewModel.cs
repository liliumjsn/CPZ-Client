using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPZ_Chat_Client.Helpers;
using CPZ_Chat_Client.Model;

namespace CPZ_Chat_Client.ViewModel
{
    public class ChatPanelViewModel:BindableBase
    {
        public ChatCommand<string> SendMessageCommand { get; set; }
        private Message composingMessage;
        private ChatUser curChatUser;
        private ChatHistory panelChatHistory;
        public Message ComposingMessage
        {
            get
            {
                return composingMessage;
            }
            set
            {
                composingMessage = value;
                SendMessageCommand.RaiseCanExecuteChanged();
            }
        }
        public ChatUser CurChatUser
        {
            get
            {
                return curChatUser;
            }
            set
            {
                curChatUser = value;
            }
        }
        public ChatHistory PanelChatHistory
        {
            get
            {
                return panelChatHistory;
            }
            set
            {
                panelChatHistory = value;
            }
        }
        public ChatPanelViewModel(ChatUser chatUser)
        {
            CurChatUser = chatUser;
            LoadChatHistory();
            SendMessageCommand = new ChatCommand<string>(OnSend, CanSend);
            
        }

        private bool CanSend(string str)
        {
            return ComposingMessage != null;
        }

        private void OnSend(string message)
        {
            //handle message send
        }

        //TODO: call REST to get history for curUser
        //now it's static
        public void LoadChatHistory()
        {
            ChatHistory chatHistory = new ChatHistory();

            chatHistory.Add(new Message
            {
                Sender = "Mark",
                Content = "Hello",
                Timestamp = new DateTime(2019, 03, 28, 22, 35, 5,
                new CultureInfo("en-US", false).Calendar)
            });
            chatHistory.Add(new Message
            {
                Sender = "LiliumJSN",
                Content = "Hi Mark",
                Timestamp = new DateTime(2019, 03, 28, 22, 37, 5,
                new CultureInfo("en-US", false).Calendar)
            });
            chatHistory.Add(new Message
            {
                Sender = "Mark",
                Content = "How are you",
                Timestamp = new DateTime(2019, 03, 28, 22, 38, 5,
                new CultureInfo("en-US", false).Calendar)
            });
            chatHistory.Add(new Message
            {
                Sender = "LiliumJSN",
                Content = "Fine",
                Timestamp = new DateTime(2019, 03, 28, 22, 39, 5,
                new CultureInfo("en-US", false).Calendar)
            });


            PanelChatHistory = chatHistory;
        }
        public void RefreshChatHistory()
        {

        }
    }
}
