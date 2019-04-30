using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private string composingMessage;
        private ChatUser curChatUser;
        private ChatHistory panelChatHistory;
        public string ComposingMessage
        {
            get
            {
                return composingMessage;
            }
            set
            {
                if (value != composingMessage)
                {
                    composingMessage = value;
                    OnPropertyChanged("ComposingMessage");
                    SendMessageCommand.RaiseCanExecuteChanged();
                }               
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
            CurChatUser.HasUnreadMessages = false;
            LoadChatHistory();
            SendMessageCommand = new ChatCommand<string>(OnSend, CanSend);            
        }

        private bool CanSend(string str)
        {
            return ComposingMessage != null && ComposingMessage.Length>0;
        }

        private void OnSend(string message)
        {
            //handle message send on REST post
            PanelChatHistory.Add(new Message
            {
                //Handle sender correctly, make myprofile static
                IsMine = true,
                Content = ComposingMessage,
                Timestamp = DateTime.Now
            });
            ComposingMessage = "";
        }

        //TODO: call REST to get history for curUser
        //now it's static
        public void LoadChatHistory()
        {
            ChatHistory chatHistory = new ChatHistory();

            /*
            chatHistory.Add(new Message
            {
                IsMine = false,
                Content = "Hello",
                Timestamp = new DateTime(2019, 03, 28, 22, 35, 5,
                new CultureInfo("en-UK", false).Calendar)
            });
            chatHistory.Add(new Message
            {
                IsMine = true,
                Content = "Hi "+ CurChatUser.Username,
                Timestamp = new DateTime(2019, 03, 28, 22, 37, 5,
                new CultureInfo("en-UK", false).Calendar)
            });
            chatHistory.Add(new Message
            {
                IsMine = false,
                Content = "How are you",
                Timestamp = new DateTime(2019, 03, 28, 22, 38, 5,
                new CultureInfo("en-UK", false).Calendar)
            });
            chatHistory.Add(new Message
            {
                IsMine = true,
                Content = "Fine",
                Timestamp = new DateTime(2019, 03, 28, 22, 39, 5,
                new CultureInfo("en-UK", false).Calendar)
            });
            */
            var response = RESTConsumer.GetChatHistory(CurChatUser.Username);
            if (response != null) chatHistory = new ChatHistory(response);
            PanelChatHistory = chatHistory;
        }
        public void RefreshChatHistory()
        {

        }
    }
}
