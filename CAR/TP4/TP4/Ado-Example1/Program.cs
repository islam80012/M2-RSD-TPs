using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ado_Exemple1;

namespace TP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Appel méthode Connect() pour se connecter à la base de données Oracle */
            string strConn = Connection.Connect();

            /* Requête SELECT : Appel GetEtudiants() pour afficher le contenu de "Etudiant" */
            Console.WriteLine("Exemple de requête SELECT ...");
            Console.WriteLine();
            Connection.GetEtudiants();

            /* Requête INSERT : Appel PutEtudiant() pour insérer un tuple dans "Etudiant" */
            Console.WriteLine("Exemple de requête INSERT ...");
            Console.WriteLine();
            int compteur = Connection.PutEtudiants();

            Console.WriteLine(" La table 'Etudiant' contient " + compteur + " tuples");

            /* Appel méthode Terminate() pour fermer la connection */
            Connection.Terminate();
            Console.Read();
        }
    }
}
