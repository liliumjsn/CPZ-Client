using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CPZ_Chat_Client.Helpers;
using CPZ_Chat_Client.Model;

namespace CPZ_Chat_Client.ViewModel
{
    public class ChatUserViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ChatUser> chatUsers;
        public ObservableCollection<ChatUser> ChatUsers
        {
            get
            {
                return chatUsers;
            }
            set
            {
                chatUsers = value;
                RaisePropertyChanged("ChatUsers");
            }
        }
        public ChatUserViewModel()
        {
            RESTConsumer.GetUsers(OnDataReady);
        }

        private ChatUser _selectedChatUser;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public ChatUser SelectedChatUser
        {
            get
            {
                return _selectedChatUser;
            }

            set
            {
                if(value != _selectedChatUser)
                {
                    _selectedChatUser = value;
                    Mediator.Notify("LoadChatPanelView", _selectedChatUser);
                }                
            }
        }

        private void OnDataReady(IEnumerable<ChatUser> response)
        {
            ChatUsers = new ObservableCollection<ChatUser>(response);
        }
    }
}
