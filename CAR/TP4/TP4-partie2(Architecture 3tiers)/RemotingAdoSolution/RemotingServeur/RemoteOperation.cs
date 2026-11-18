
using Oracle.DataAccess.Client;
using RemotingInterface;
using System;
using System.Data;

namespace RemotingServer
{
    public class RemoteOperation : MarshalByRefObject,
                                  IRemoteOperation
    {
        // Une seule déclaration de la connexion
        // lien vers une BD oracle 21C service /XEPDB1  : "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
        // lien vers Prof BD : 
        private string oradb =
             "Data Source = 10.145.254.1/XE; User Id = oracle; Password = manager;";

        // Méthode pour créer une connexion
        private OracleConnection GetConnection()
        {
            return new OracleConnection(oradb);
        }

        // Afficher tous les étudiants
        public DataTable Afficher()
        {
            using (OracleConnection con = GetConnection())
            {
                con.Open();

                string SQL = "SELECT * FROM Etudiant";

                OracleDataAdapter adapter =
                    new OracleDataAdapter(SQL, con);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                return dt;
            }
        }

        // Ajouter un étudiant
        public int Ajouter(int matricule, string nom, string prenom)
        {
            using (OracleConnection con = GetConnection())
            {
                con.Open();

                string SQL = "INSERT INTO Etudiant VALUES (:mat, :nom, :prenom)";

                OracleCommand cmd = new OracleCommand(SQL, con);

                cmd.Parameters.Add(":mat", matricule);
                cmd.Parameters.Add(":nom", nom);
                cmd.Parameters.Add(":prenom", prenom);

                return cmd.ExecuteNonQuery();
            }
        }

        // Supprimer un étudiant
        public int Supprimer(int matricule)
        {
            using (OracleConnection con = GetConnection())
            {
                con.Open();

                string SQL =
                    "DELETE FROM Etudiant WHERE matricule = :mat";

                OracleCommand cmd = new OracleCommand(SQL, con);

                cmd.Parameters.Add(":mat", matricule);

                return cmd.ExecuteNonQuery();
            }
        }

        // Modifier un étudiant
        public int Modifier(int matricule, string nom, string prenom)
        {
            using (OracleConnection con = GetConnection())
            {
                con.Open();

                string SQL =
                    "UPDATE Etudiant SET nom = :nom, prenom = :prenom " +
                    "WHERE matricule = :mat";

                OracleCommand cmd = new OracleCommand(SQL, con);

                cmd.Parameters.Add(":nom", nom);
                cmd.Parameters.Add(":prenom", prenom);
                cmd.Parameters.Add(":mat", matricule);

                return cmd.ExecuteNonQuery();
            }
        }

        // Rechercher un étudiant
        public DataTable Rechercher(int matricule)
        {
            using (OracleConnection con = GetConnection())
            {
                con.Open();

                string SQL =
                    "SELECT * FROM Etudiant WHERE matricule = :mat";

                OracleDataAdapter adapter =
                    new OracleDataAdapter(SQL, con);

                adapter.SelectCommand.Parameters.Add(":mat", matricule);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                return dt;
            }
        }

        // Garder l'objet Remoting vivant
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
