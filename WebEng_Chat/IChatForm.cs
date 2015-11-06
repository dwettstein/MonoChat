using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEng_Chat
{
    interface IChatForm
    {
        void MessageReceived(string msg);
    }
}
