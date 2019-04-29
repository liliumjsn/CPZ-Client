using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Model
{
    public class Message
    {
        private string sender;
        private string content;
        private DateTime timestamp;

        public string Content { get => content; set => content = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public string Sender { get => sender; set => sender = value; }
    }
}
