using System;
using System.Net;
using System.Net.Sockets;

namespace UdpServeur
{
    class serveur
    {
        static void Main(string[] args)
        {
            int P = 8080;	//port de connexion
            IPEndPoint ip = null;

            //Demarage su serveur
            Console.WriteLine("Demarage du serveur...");
            UdpClient serveur = new UdpClient(P);

            bool loop = true;

            while (loop)
            {
                //Attente de connexion
                Console.WriteLine("Attente de connexion(s)...");
                byte[] tmp = serveur.Receive(ref ip);

                //Conversion des bytes en string (chaine de caractere)
                string data = new System.Text.ASCIIEncoding().GetString(tmp);

                //Dechifrage de la commande -->ip:port:command
                string[] cmd = data.Split(new char[] { ':' });

                //adresse ip
                string host = cmd[0];

                //port de connexion
                int port = Int32.Parse(cmd[1]);

                //recuperation de nb1 du signe et de nb2
                int nb1 = Int32.Parse(cmd[2]);
                string signe = cmd[3];
                int nb2 = Int32.Parse(cmd[4]);

                int resultat = 0;
                Console.WriteLine("Operation --> " + nb1 + " " + signe + " " + nb2);

                //execution de la commande
                switch (signe)
                {
                    case "+": resultat = nb1 + nb2; break;
                    case "-": resultat = nb1 - nb2; break;
                    case "*": resultat = nb1 * nb2; break;
                    case "/": resultat = nb1 / nb2; break;
                    case "<>": resultat = 0; loop = false; break;
                    default: resultat = 0; break;
                }//fin du switch
                string reponse = nb1 + " " + signe + " " + nb2 + " = " + resultat;

                //conversion du resultat en bytes
                byte[] rep = System.Text.Encoding.ASCII.GetBytes(reponse.ToCharArray());
                serveur.Send(rep, rep.Length, host, port);

            }//fin du while
            //arret du serveur
            Console.WriteLine("Arret du serveur...");
            Console.WriteLine("Arret du serveur... *Entree* pour terminer.");
            Console.ReadLine();
        }
    }
}
