using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ObligatoriskOpgaveTCPServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the echo server");
            TcpListener listener = new TcpListener(IPAddress.Loopback, 2121);
            listener.Start();
            while (true)
            {
                TcpClient socket = Methods.ClientAcceptor(listener);
                Task task1 = Task.Run(() => Methods.EchoMessagereader(socket));
            }
        }
    }
}
