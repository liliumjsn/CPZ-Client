﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Model
{
    public class ChatUser : INotifyPropertyChanged
    {
        private string username;
        private bool isOnline;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username != value)
                {
                    username = value;
                    RaisePropertyChanged("Username");
                }
            }
        }

        public bool IsOnline {
            get
            {
                return isOnline;
            }
            set
            {
                if (isOnline != value)
                {
                    isOnline = value;
                    RaisePropertyChanged("IsOnline");
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
