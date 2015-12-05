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
        public static int AkkaPort = 0; // default value
        public static string AkkaServerIp = "127.0.0.1"; // default value
        public static int AkkaServerPort = 8081; // default value
        public static string AkkaServerSelection;
        public static Akka.Configuration.Config AkkaConfig;
        public static Akka.Configuration.Config AkkaServerConfig;

        public static void setConfig()
        {
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

        public static void setServerConfig()
        {
            AkkaServerSelection = "akka.tcp://" + AkkaServer + "@" + AkkaServerIp + ":" + AkkaServerPort + "/user/" + AkkaServer;
            Console.WriteLine("AkkaServerSelection: " + AkkaServerSelection);

            AkkaServerConfig = Akka.Configuration.ConfigurationFactory.ParseString(@"
                akka {  
                    actor {
                        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                    }
                    remote {
                        helios.tcp {
                            transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
		                    applied-adapters = []
		                    transport-protocol = tcp
		                    port = " + AkkaServerPort + @"
		                    hostname = " + AkkaServerIp + @"
                        }
                    }
                }
                ");
        }
    }
}
