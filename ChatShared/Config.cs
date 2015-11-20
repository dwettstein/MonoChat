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
        public static string AkkaIp = "0.0.0.0"; // default value, listen on all addresses
        public static int AkkaPort = 1234; // default value
        public static string AkkaServerSelection;
        public static Akka.Configuration.Config AkkaConfig;

        public static void setConfig()
        {
            AkkaServerSelection = "akka.tcp://" + AkkaServer + "@" + AkkaIp + ":" + AkkaPort + "/user/" + AkkaServer;

            AkkaConfig = Akka.Configuration.ConfigurationFactory.ParseString(@"
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
}
