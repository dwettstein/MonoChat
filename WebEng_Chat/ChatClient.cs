using ChatShared;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebEng_Chat
{
    class ChatClient : IChatForm
    {
        private IChatForm chatForm;
		private IActorRef client;

        public ChatClient(IChatForm chatForm)
        {
            this.chatForm = chatForm;
			var system = ActorSystem.Create(Config.AkkaClient + (new Random()).Next(999999), Config.AkkaConfig);
			system.ActorSelection(Config.AkkaServerSelection);
			client = system.ActorOf(Props.Create(() => new Client(this)));
        }

        public void RegisterMessage(string name)
        {
            if (client != null) client.Tell(new RegisterMessage { Name = name });
        }
        
        public void SendMessage(string msg)
        {
            if (client != null) client.Tell(new SendMessage { Message = msg });
        }

        public void Disconnect()
        {
			if (client != null) client.Tell(new DisconnectMessage());
        }
    
        public void MessageReceived(string msg)
        {
			chatForm.MessageReceived(msg);
        }

        public void OnlineUsersChanged(string[] users)
        {
            chatForm.OnlineUsersChanged(users);
        }
    }

    class Client : TypedActor,
        IHandle<SendMessage>,
        IHandle<ReceiveMessage>,
        IHandle<DisconnectMessage>,
        IHandle<OnlineUserMessage>
    {
        private readonly ChatClient chatClient;
        private readonly ActorSelection server;

        public Client(ChatClient chatClient)
        {
            this.chatClient = chatClient;
            this.server = Context.ActorSelection(Config.AkkaServerSelection);
        }

        public void Handle(DisconnectMessage msg)
        {
            if (server != null) server.Tell(msg, Self);
        }

        public void Handle(RegisterMessage msg)
        {
            if (server != null) server.Tell(msg, Self);
        }

        public void Handle(SendMessage msg)
        {
            if (server != null) server.Tell(msg, Self);
        }

        public void Handle(ReceiveMessage msg)
        {
            chatClient.MessageReceived(msg.Message);
        }

        public void Handle(OnlineUserMessage msg)
        {
            chatClient.OnlineUsersChanged(msg.Users);
        }
    }
}
