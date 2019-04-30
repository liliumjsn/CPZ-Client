using CPZ_Chat_Client.Helpers;
using CPZ_Chat_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.ViewModel
{
    public class PanelViewSelector : BindableBase
    {

        public PanelViewSelector()
        {
            CurrentViewModel = new InformationViewModel();
            Mediator.Register("LoadChatPanelView", LoadChatPanelView);
            Mediator.Register("LoadInformationView", LoadInformationView);
            Mediator.Register("Error", LoadInformationErrorView);
        }

        private BindableBase currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }
        private void LoadChatPanelView(object args)
        {
           CurrentViewModel = new ChatPanelViewModel(args as ChatUser);
        }
        private void LoadInformationView(object args)
        {
            CurrentViewModel = new InformationViewModel();
        }
        private void LoadInformationErrorView(object args)
        {
            CurrentViewModel = new InformationViewModel(args as Information);
        }

    }
}