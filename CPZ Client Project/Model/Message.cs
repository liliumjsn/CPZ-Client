using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPZ_Chat_Client.Model
{
    public class Message
    {
        private bool isMine;
        private string content;
        private DateTime timestamp;

        public string Content { get => content; set => content = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public bool IsMine { get => isMine; set => isMine = value; }
    }
}
