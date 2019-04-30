using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Model
{
    public class ChatHistory : ObservableCollection<Message>
    {
        public ChatHistory()
        {

        }

        public ChatHistory(IEnumerable<Message> collection)
        {
            foreach (Message msg in collection)
            {
                this.Add(msg);
            }
        }
        public IDisposable Subscribe(IObserver<Message> observer)
        {
            throw new NotImplementedException();
        }
    }
}
