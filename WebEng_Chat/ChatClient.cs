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

        public ChatClient(IChatForm chatForm, string name)
        {
            this.chatForm = chatForm;
			var system = ActorSystem.Create(Config.AkkaClient + (new Random()).Next(999999), Config.AkkaConfig);
			system.ActorSelection(Config.AkkaServerSelection);
			client = system.ActorOf(Props.Create(() => new Client(this, name)));
        }
        
        public void SendMessage(string msg)
        {
			client.Tell(new SendMessage { Message = msg });
        }

        public void Disconnect()
        {
			client.Tell(new DisconnectMessage());
        }
    
        public void MessageReceived(string msg)
        {
			chatForm.MessageReceived(msg);
        }
    }

    class Client : TypedActor,
        IHandle<SendMessage>,
        IHandle<ReceiveMessage>,
        IHandle<DisconnectMessage>
    {
        private readonly ChatClient chatClient;
        private readonly ActorSelection server;

        public Client(ChatClient chatClient, string name)
        {
            this.chatClient = chatClient;
            this.server = Context.ActorSelection(Config.AkkaServerSelection);
            this.server.Tell(new RegisterMessage { Name = name }, Self);
        }

        public void Handle(DisconnectMessage msg)
        {
            server.Tell(msg, Self);
        }

        public void Handle(SendMessage msg)
        {
            server.Tell(msg, Self);
        }

        public void Handle(ReceiveMessage msg)
        {
            chatClient.MessageReceived(msg.Message);
        }
    }
}
