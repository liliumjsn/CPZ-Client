using System;
using System.Collections.ObjectModel;
using CPZ_Chat_Client.Helpers;
using CPZ_Chat_Client.Model;

namespace CPZ_Chat_Client.ViewModel
{
    public class ChatUserViewModel
    {
        public ObservableCollection<ChatUser> ChatUsers
        {
            get;
            set;
        }
        public ChatUserViewModel()
        {
            LoadChatUsers();
        }

        private ChatUser _selectedChatUser;

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

        public void LoadChatUsers()
        {
            //TODO: connect to REST to get users
            
            ObservableCollection<ChatUser> chatUsers = new ObservableCollection<ChatUser>();
            var reponse = RESTConsumer.GetUsers();
            if(reponse != null) chatUsers = new ObservableCollection<ChatUser>(reponse);

            /*
            chatUsers.Add(new ChatUser { Username = "Mark", IsOnline = true, HasUnreadMessages=true});
            chatUsers.Add(new ChatUser { Username = "Allen", IsOnline = true, HasUnreadMessages = false });
            chatUsers.Add(new ChatUser { Username = "Linda", IsOnline = false, HasUnreadMessages = false });
            chatUsers.Add(new ChatUser { Username = "Lizzy", IsOnline = false, HasUnreadMessages = false });
            chatUsers.Add(new ChatUser { Username = "Paul", IsOnline = false, HasUnreadMessages = false });
            */


            ChatUsers = chatUsers;
        }
    }
}
