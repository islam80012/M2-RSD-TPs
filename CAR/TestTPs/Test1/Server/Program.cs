using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using Interfaces;

namespace Serveur
{
    // Application Console : Sociale (assemblage des composants + publication Remoting)
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cs = "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";

                // 1. Création des composants et connexion de leurs interfaces
                IAssure assurance = new Assurance(cs);          // fournit IAssure
                IFiltre affiche = new Affiche();                // fournit IFiltre
                IAdhere adherent = new Adherent(affiche);       // requiert IFiltre, fournit IAdhere
                Sociale sociale = new Sociale(assurance, adherent);   // requiert IAssure + IAdhere

                // 2. Canal TCP + publication de l'objet Sociale
                //    TypeFilterLevel.Full : le client envoie des objets AdherentInfo au serveur
                BinaryServerFormatterSinkProvider fournisseurServeur = new BinaryServerFormatterSinkProvider();
                fournisseurServeur.TypeFilterLevel = TypeFilterLevel.Full;
                BinaryClientFormatterSinkProvider fournisseurClient = new BinaryClientFormatterSinkProvider();

                Hashtable proprietes = new Hashtable();
                proprietes["port"] = 1069;

                TcpChannel canal = new TcpChannel(proprietes, fournisseurClient, fournisseurServeur);
                ChannelServices.RegisterChannel(canal, false);
                RemotingServices.Marshal(sociale, "Sociale", typeof(ISociale));

                Console.WriteLine("Serveur démarré : tcp://localhost:1069/Sociale");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur au démarrage du serveur : " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
