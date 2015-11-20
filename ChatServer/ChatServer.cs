using ChatShared;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Akka.Remote;

namespace ChatServer
{
    class ChatServer : TypedActor,
        IHandle<RegisterMessage>,
        IHandle<SendMessage>,
        IHandle<DisconnectMessage>,
        IHandle<DisassociatedEvent>
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
            SendOnlineUserMessage();
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

        private void SendOnlineUserMessage()
        {
            string[] users = clients.Where(x => x.Key != Self).Select(x => x.Value).ToArray();
            foreach (IActorRef client in clients.Keys)
            {
                client.Tell(new OnlineUserMessage { Users = users });
            }
        }

        public void Handle(DisconnectMessage msg)
        {
            UserDisconnected();
        }

        private void UserDisconnected()
        {
            if (clients.ContainsKey(Sender))
            {
                string userName;
                bool isUserName = clients.TryGetValue(Sender, out userName);
                clients.Remove(Sender);
                if (isUserName)
                {
                    Self.Tell(new SendMessage { Message = "User " + userName + " has left the akka chat!" }, Self);
                }
            }
            SendOnlineUserMessage();
        }

        public void Handle(DisassociatedEvent message)
        {
            UserDisconnected();
        }
    }
}
