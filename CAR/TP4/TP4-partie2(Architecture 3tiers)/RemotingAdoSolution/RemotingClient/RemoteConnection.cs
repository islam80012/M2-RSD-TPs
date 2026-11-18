
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using RemotingInterface;

namespace RemotingClient
{
    public static class RemoteConnection
    {
        public static IRemoteOperation operation;

        public static void Connect()
        {
            TcpChannel channel = new TcpChannel(0);

            ChannelServices.RegisterChannel(
                channel, false);

            operation = (IRemoteOperation)
                RemotingServices.Connect(
                    typeof(IRemoteOperation),
                    "tcp://localhost:8085/RemoteOperation");
        }
    }
}
