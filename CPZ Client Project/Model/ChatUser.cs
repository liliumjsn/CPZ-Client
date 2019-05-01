using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Model
{
    public class ChatUser : INotifyPropertyChanged
    {
        private int _id;
        private string _username;
        private bool _is_active;
        private bool _is_staff;
        private DateTime _last_login;
        private bool _is_new;
        //TODO: To be removed?
        private bool hasUnreadMessages;
                
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    RaisePropertyChanged("Username");
                }
            }
        }

        public bool Is_active
        {
            get
            {
                return _is_active;
            }
            set
            {
                if (_is_active != value)
                {
                    _is_active = value;
                    RaisePropertyChanged("Is_active");
                }
            }
        }
        public DateTime Last_login
        {
            get
            {
                return _last_login;
            }
            set
            {
                if (_last_login != value)
                {
                    _last_login = value;
                    RaisePropertyChanged("Last_login");
                }
            }
        }        
        public bool Is_staff {
            get
            {
                return _is_staff;
            }
            set
            {
                _is_staff = value;
                RaisePropertyChanged("Is_staff");
            }
        }
        public bool Is_new
        {
            get
            {
                return _is_new;
            }
            set
            {
                _is_new = value;
                RaisePropertyChanged("Is_new");
            }
        }
        public bool HasUnreadMessages
        {
            get
            {
                return hasUnreadMessages;
            }
            set
            {
                if (hasUnreadMessages != value)
                {
                    hasUnreadMessages = value;
                    RaisePropertyChanged("HasUnreadMessages");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
