using ChatShared;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create(Config.AkkaServer, Config.AkkaConfig);
            system.ActorOf<ChatServer>(Config.AkkaServer);
            Console.Read();
        }
    }
}
