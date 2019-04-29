using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPZ_Chat_Client.Helpers;
using CPZ_Chat_Client.Model;

namespace CPZ_Chat_Client.ViewModel
{
    public class InformationViewModel : BindableBase
    {
        private Information information;

        public Information Information
        {
            get
            {
                return information;
            }
            set
            {
                information = value;
            }
        }

        public InformationViewModel()
        {
            LoadInitialInfo();
        }
        public void LoadInitialInfo()
        {
            Information mInformation = new Information()
            {
                Title = "Welcome",
                Message = "Select a user to start chatting"
            };

            Information = mInformation;
        }
    }
}
