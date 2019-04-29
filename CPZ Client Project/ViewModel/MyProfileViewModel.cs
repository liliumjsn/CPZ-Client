using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPZ_Chat_Client.Model;

namespace CPZ_Chat_Client.ViewModel
{
    public class MyProfileViewModel
    {
        private MyProfile profile;
        public MyProfile Profile
        {
            get
            {
                return profile;
            }
            set
            {
                profile = value;
            }
        }
        public MyProfileViewModel()
        {
            LoadProfile();
        }
        public void LoadProfile()
        {
            MyProfile mProfile = new MyProfile() {
                Username = Environment.UserName
            };
            Profile = mProfile;
        }
    }
}
