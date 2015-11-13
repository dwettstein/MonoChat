using ChatShared;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using Akka.Remote;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create(Config.AkkaServer, Config.AkkaConfig);
            IActorRef server = system.ActorOf<ChatServer>(Config.AkkaServer);
            system.EventStream.Subscribe(server, typeof(DisassociatedEvent));
            Console.Read();
        }
    }
}
