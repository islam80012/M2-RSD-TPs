using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Ado_Exemple3
{
    class Program
    {
        private static string SQL;
        private static OracleConnection conn;
        private static OracleCommand cmd;
        private static OracleDataAdapter da;
        private static DataSet ds;

        static void Main(string[] args)
        {
            //____________________________________________________________________// 
            try
            {
                string oradb = "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
                conn = new OracleConnection(oradb);
                conn.Open();
            }
            catch (OracleException)
            {
                Console.WriteLine("Erreur de connection à la base de données...."); ; }
                   conn.State.ToString();
                //____________________________________________________________________// 
                // Insertion d'un enregistrement fixe                                 // 
                //____________________________________________________________________// 
                //SQL = "INSERT INTO Etudiant VALUES (15,'salut', 'sam')"; 
                //cmd = new OracleCommand(SQL, conn); 
                //cmd.CommandType = CommandType.Text; 
                //da = new OracleDataAdapter(cmd); 
                //ds = new DataSet(); 
                //da.Fill(ds); 

                //____________________________________________________________________// 
                // Insertion d'un enregistrement variable                             // 
                //____________________________________________________________________// 
                bool response = true;
                while (response)
                {
                    int matricule; String nom; String prenom;
                    Console.Write(" Donner le matricule : "); matricule = int.Parse(Console.ReadLine());
                    Console.Write(" Donner le nom : "); nom = Console.ReadLine();
                    Console.Write(" Donner le prenom : "); prenom = Console.ReadLine();

                    SQL = "INSERT INTO Etudiant VALUES(" + @matricule + ",'" + @nom + "',' " + @prenom + "')";
                    cmd = new OracleCommand(SQL, conn);
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        //cmd.ExecuteNonQuery(); 
                        int nombre = cmd.ExecuteNonQuery();
                        Console.WriteLine(); Console.WriteLine(nombre + " Enregistrement ajout avec succès..."); 
                        //____________________________________________________________________// 
                        //Affichage de la table 
                        SQL = "SELECT * FROM Etudiant ORDER BY matricule";
                        cmd = new OracleCommand(SQL, conn);
                        cmd.CommandType = CommandType.Text;
                        da = new OracleDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        //____________________________________________________________________// 
                        DataTable etude = ds.Tables[0];

                        Console.WriteLine();
                        Console.WriteLine("Affichage du contenu de la table : ETUDIANT ");

                        for (int i = 0; i < etude.Rows.Count; i++)
                        {
                            Console.WriteLine(etude.Rows[i][0].ToString() + "\t\t" +
                            etude.Rows[i][1].ToString() + "\t\t" +
                              etude.Rows[i][2].ToString());
                        }

                        Console.WriteLine();
                        Console.WriteLine("Le nombre d'enregistrement de la table : " +
                                           (etude.Rows.Count + 1));
                        Console.WriteLine();
                        Console.Write("Tapez 'O' pour insérer d'autres enregistrements : ");
                        if ((Console.ReadLine()).ToUpper() != "O") { response = false; }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(); Console.WriteLine(" L'Enegistrement   existe déjà......"); } 
                }
                }
                //____________________________________________________________________// 
            }
        }