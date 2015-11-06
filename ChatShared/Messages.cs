using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShared
{
    public class DisconnectMessage { }

    public class ReceiveMessage
    {
        public string Message { get; set; }
    }

    public class SendMessage
    {
        public string Message { get; set; }
    }

    public class RegisterMessage
    {
        public string Name { get; set; }
    }
}
