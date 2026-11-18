
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemotingServer
{
    class RemoteMain
    {
        static void Main(string[] args)
        {
            TcpChannel channel =
                new TcpChannel(8085);

            ChannelServices.RegisterChannel(
                channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteOperation),
                "RemoteOperation",
                WellKnownObjectMode.Singleton);

            Console.WriteLine(
                "Serveur Remoting demarre...");

            Console.WriteLine(
                "Port : 8085");

            Console.WriteLine(
                "En attente du client...");

            Console.ReadLine();
        }
    }
}
