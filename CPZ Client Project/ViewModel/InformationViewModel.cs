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
        public Information _mInformation;

        public InformationViewModel()
        {
            LoadInitialInfo();
        }
        public void LoadInitialInfo()
        {
            Information mInformation = new Information()
            {
                Title = "Welcome",
                Message = "Start chatting now"
            };

            _mInformation = mInformation;
        }
    }
}
