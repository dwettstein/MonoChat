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
                Config.AkkaIp = args[0];
                Console.WriteLine("Set chat host IP to: " + Config.AkkaIp);
            }
            Config.setConfig();
            var system = ActorSystem.Create(Config.AkkaServer, Config.AkkaConfig);
            IActorRef server = system.ActorOf<ChatServer>(Config.AkkaServer);
            system.EventStream.Subscribe(server, typeof(DisassociatedEvent));
            Console.Read();
        }
    }
}
