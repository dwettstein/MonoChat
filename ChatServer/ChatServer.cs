using ChatShared;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class ChatServer : TypedActor,
        IHandle<RegisterMessage>,
        IHandle<SendMessage>,
        IHandle<DisconnectMessage>
    {
        private Dictionary<IActorRef, string> clients = new Dictionary<IActorRef, string>();

        public ChatServer()
        {
            clients.Add(Self, "Server");
        }

        private string FormatMessage(string name, string msg)
        {
            return System.DateTime.Now.ToString("hh:mm:ss") + "  " + name + ":  " + msg;
        }

        public void Handle(RegisterMessage msg)
        {
            clients.Add(Sender, msg.Name);
            Self.Tell(new SendMessage { Message = "User " + msg.Name + " joined the akka chat!" }, Self);
        }

        public void Handle(SendMessage msg)
        {
            if (clients.ContainsKey(Sender))
            {
                foreach (IActorRef client in clients.Keys)
                {
                    client.Tell(new ReceiveMessage { Message = FormatMessage(clients[Sender], msg.Message) });
                }
            }
        }

        public void Handle(DisconnectMessage msg)
        {
            if (clients.ContainsKey(Sender))
            {
                clients.Remove(Sender);
            }
        }
    }
}
