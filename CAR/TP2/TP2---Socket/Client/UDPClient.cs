using System;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class UDPClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialisation du client...");
            client proc = new client(8081, "127.0.0.1", 8080);
            string x, y, signe, command, resultat = "";

            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("COMMANDE -> Pour quitter x = 0\n");

                //entrer x
                Console.Write("x     = "); x = Console.ReadLine();

                //terminer si x = 0
                if (Int32.Parse(x) == 0) break;

                //entrer le signe
                Console.Write("signe : "); signe = Console.ReadLine();

                //entrer y
                Console.Write("y     = "); y = Console.ReadLine();

                command = x + ":" + signe + ":" + y;

                proc.Execute(command, ref resultat);
                Console.WriteLine("RESULTAT -> " + resultat);
            }
        }
    }
}
