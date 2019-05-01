using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPZ_Chat_Client.Helpers;
using CPZ_Chat_Client.Model;

namespace CPZ_Chat_Client.ViewModel
{
    public class MyProfileViewModel
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public MyProfileViewModel()
        {
            LoadProfile();
            //RESTProducer.Connect();
        }
        public void LoadProfile()
        {
            Username = MyProfile.DefaultUsername;
        }
    }
}
