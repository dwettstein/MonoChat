using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShared
{
    public class Config
    {
        public static readonly string AkkaClient = "ChatClient";
        public static readonly string AkkaServer = "ChatServer";
        public static readonly string AkkaIp = "localhost";
        public static readonly int AkkaPort = 1234;
        public static readonly string AkkaServerSelection = "akka.tcp://" + AkkaServer + "@" + AkkaIp + ":" + AkkaPort + "/user/" + AkkaServer;
        public static readonly Akka.Configuration.Config AkkaConfig = Akka.Configuration.ConfigurationFactory.ParseString(@"
        akka {  
            actor {
                provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
            }
            remote {
                helios.tcp {
                    transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
		            applied-adapters = []
		            transport-protocol = tcp
		            port = " + AkkaPort + @"
		            hostname = " + AkkaIp + @"
                }
            }
        }
        ");
    }
}
