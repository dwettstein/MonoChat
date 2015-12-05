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
            if (args.Length > 0)
            {
                Config.AkkaServerIp = args[0];
                Console.WriteLine("Set chat host IP to: " + Config.AkkaServerIp);
            }
            Config.setServerConfig();
            var system = ActorSystem.Create(Config.AkkaServer, Config.AkkaServerConfig);
            IActorRef server = system.ActorOf<ChatServer>(Config.AkkaServer);
            system.EventStream.Subscribe(server, typeof(DisassociatedEvent));
            Console.Read();
        }
    }
}
