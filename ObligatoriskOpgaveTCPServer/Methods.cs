using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ObligatoriskOpgaveTCPServer
{
    public class Methods
    {

        public static List<FootballPlayer> Players = new List<FootballPlayer>()
        {
            new FootballPlayer(-5, "Bob1", 50, 60),
            new FootballPlayer(-6, "Tim2", 60, 50)
        };

        public static TcpClient ClientAcceptor(TcpListener listener)
        {
            Console.WriteLine("Waiting for client");
            TcpClient socket = listener.AcceptTcpClient();
            Console.WriteLine("Connected to client");
            return socket;
        }
        public static void EchoMessagereader(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);
            while (socket.Connected)
            {
                string command = reader.ReadLine();
                string input = reader.ReadLine();
                if (command == "HentAlle")
                {
                    writer.WriteLine(GetAll(Players));
                }
                if (command == "Hent")
                {
                    writer.WriteLine(GetById(Players, int.Parse(input)));
                }
                if (command == "Gem")
                {
                    AddPlayer(input);
                }


                writer.Flush();

            }
        }

        public static string GetAll(List<FootballPlayer> list)
        {
            return JsonSerializer.Serialize(list);
        }

        public static string GetById(List<FootballPlayer> list, int id)
        {
            FootballPlayer foundPlayer = null;
            foreach (FootballPlayer player in list)
            {
                if (player.Id == id)
                {
                    foundPlayer = player;
                }
            }
            if (foundPlayer == null)
            {
                return "No player matched that ID";
            }

            return JsonSerializer.Serialize(foundPlayer);
        }

        public static void AddPlayer(string playerToAdd)
        {
            Players.Add(JsonSerializer.Deserialize<FootballPlayer>(playerToAdd));
            return;
        }
    }
}
