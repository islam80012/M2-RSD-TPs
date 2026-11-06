using System;
using System.Collections.Generic;
using System.Text;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace Ado_Exemple1
{
    static class Connection
    {
        private static string SQL;
        private static OracleConnection conn;
        private static OracleCommand cmd;
        private static OracleDataAdapter da;
        private static DataSet ds;
        //_____________________________________________________________________// 
        // Première méthode 
        public static string Connect()
        {
            try
            {
                string oradb = "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
                conn = new OracleConnection(oradb);
                conn.Open();
            }
            catch (OracleException e)
            {
                return e.Message;
            }
            return conn.State.ToString();
        }
        //_____________________________________________________________________// 
        // Deuxième méthode 
        public static void GetEtudiants()
        {
            SQL = "SELECT * FROM Etudiant";
            cmd = new OracleCommand(SQL, conn);
            cmd.CommandType = CommandType.Text;

            da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            /* Affichage du contenu de la table */
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine(ds.Tables[0].Rows[i][0].ToString() + "\t\t" +
                ds.Tables[0].Rows[i][1].ToString() + "\t\t" +
                ds.Tables[0].Rows[i][2].ToString());
            }
            Console.WriteLine("________________________________________________");
            Console.WriteLine();
        }

        //_____________________________________________________________________// 
        // Troisième méthode 
        public static int PutEtudiants()
        {
            int matricule; string nom, prenom;

            Console.Write("Matricule : "); matricule = int.Parse(Console.ReadLine());
            Console.Write("Nom : "); nom = Console.ReadLine();
            Console.Write("Prénom : "); prenom = Console.ReadLine();

            /* Ajout d'un enregistrement variable */
            SQL = "INSERT INTO Etudiant VALUES(" + @matricule + ",'" + @nom + "','" + @prenom +
                                               "')";

            cmd = new OracleCommand(SQL, conn);
            cmd.CommandType = CommandType.Text;
            int nombre = cmd.ExecuteNonQuery();

            Console.WriteLine(); Console.WriteLine(nombre + " Enregistrement ajouté avec succès..."); 


            SQL = "SELECT * FROM Etudiant;";
            cmd = new OracleCommand(SQL, conn);
            cmd.CommandType = CommandType.Text;

            da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            /* Affichage du contenu de la table */
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine(ds.Tables[0].Rows[i][0].ToString() + "\t\t" +
                ds.Tables[0].Rows[i][1].ToString() + "\t\t" +
                ds.Tables[0].Rows[i][2].ToString());
            }
            Console.WriteLine();
            return (ds.Tables[0].Rows.Count);
        }

        //_____________________________________________________________________// 
        // Quatrième méthode 
        public static void Terminate()
        {
            conn.Close();
        }
        //_____________________________________________________________________// 
    }
}