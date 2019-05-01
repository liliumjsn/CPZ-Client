using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Model
{
    public static class MyProfile
    {
        private static ChatUser _chatUserObject;
        public static string DefaultUsername
        {
            get
            {
                return Environment.UserName;
            }
        }

        public static ChatUser ChatUserObject
        {
            get
            {
                if (_chatUserObject != null) return _chatUserObject;
                else return new ChatUser() { Username = MyProfile.DefaultUsername};
            }
            set
            {
                _chatUserObject = value;
            }
        }
    }
}
