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
                OnPropertyChanged("CurChatUser");
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
                OnPropertyChanged("PanelChatHistory");
            }
        }
        public ChatPanelViewModel(ChatUser chatUser)
        {
            CurChatUser = chatUser;
            CurChatUser.HasUnreadMessages = false;
            RESTConsumer.GetChatHistory(CurChatUser.Username, OnDataReady);
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

        private void OnDataReady(IEnumerable<Message> response)
        {
            PanelChatHistory = new ChatHistory(response);
        }
        public void RefreshChatHistory()
        {

        }
    }
}
