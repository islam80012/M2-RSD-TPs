using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using Interfaces;

namespace Serveur
{
    // Composant Assurance : fournit IAssure, accès à la BD via ADO.Net
    public class Assurance : IAssure
    {
        private readonly string chaineConnexion;

        public Assurance(string chaineConnexion)
        {
            this.chaineConnexion = chaineConnexion;
        }

        //_____________________________________________________________________//
        public CaisseSociale RechercherCaisse(string type)
        {
            const string sql =
                "SELECT CODE, DESIGNATION, TYPE, NB_ADHERENT, ADRESSE, DATE_CREATION " +
                "FROM SOCIALE WHERE TYPE = :ptype";

            using (OracleConnection con = new OracleConnection(chaineConnexion))
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                cmd.BindByName = true;
                cmd.Parameters.Add("ptype", OracleDbType.Varchar2).Value = type;
                con.Open();

                using (OracleDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;     // aucune caisse de ce type

                    CaisseSociale c = new CaisseSociale();
                    c.Code = Convert.ToInt32(rd["CODE"]);
                    c.Designation = rd["DESIGNATION"].ToString();
                    c.Type = rd["TYPE"].ToString();
                    c.NbAdherent = rd["NB_ADHERENT"] == DBNull.Value ? 0 : Convert.ToInt32(rd["NB_ADHERENT"]);
                    c.Adresse = rd["ADRESSE"].ToString();
                    c.DateCreation = Convert.ToDateTime(rd["DATE_CREATION"]);
                    return c;
                }
            }
        }

        //_____________________________________________________________________//
        public List<AdherentInfo> RechercherAdherents(int codeCaisse)
        {
            const string sql =
                "SELECT MATRICULE, NOM, PRENOM, DATE_NAIS, CODE " +
                "FROM ADHERENT WHERE CODE = :pcode ORDER BY MATRICULE";

            List<AdherentInfo> liste = new List<AdherentInfo>();

            using (OracleConnection con = new OracleConnection(chaineConnexion))
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                cmd.BindByName = true;
                cmd.Parameters.Add("pcode", OracleDbType.Int32).Value = codeCaisse;
                con.Open();

                using (OracleDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        AdherentInfo a = new AdherentInfo();
                        a.Matricule = Convert.ToInt32(rd["MATRICULE"]);
                        a.Nom = rd["NOM"].ToString();
                        a.Prenom = rd["PRENOM"].ToString();
                        a.DateNais = Convert.ToDateTime(rd["DATE_NAIS"]);
                        a.Code = Convert.ToInt32(rd["CODE"]);
                        liste.Add(a);
                    }
                }
            }
            return liste;
        }

        //_____________________________________________________________________//
        public AdherentInfo RechercherAdherent(int matricule)
        {
            const string sql =
                "SELECT MATRICULE, NOM, PRENOM, DATE_NAIS, CODE " +
                "FROM ADHERENT WHERE MATRICULE = :pmat";

            using (OracleConnection con = new OracleConnection(chaineConnexion))
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                cmd.BindByName = true;
                cmd.Parameters.Add("pmat", OracleDbType.Int32).Value = matricule;
                con.Open();

                using (OracleDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;      // pas d'adhérent avec ce matricule

                    AdherentInfo a = new AdherentInfo();
                    a.Matricule = Convert.ToInt32(rd["MATRICULE"]);
                    a.Nom = rd["NOM"].ToString();
                    a.Prenom = rd["PRENOM"].ToString();
                    a.DateNais = Convert.ToDateTime(rd["DATE_NAIS"]);
                    a.Code = Convert.ToInt32(rd["CODE"]);
                    return a;
                }
            }
        }

        //_____________________________________________________________________//
        public int AjouterAdherent(AdherentInfo a)
        {
            const string sql =
                "INSERT INTO ADHERENT (MATRICULE, NOM, PRENOM, DATE_NAIS, CODE) " +
                "VALUES (:pmat, :pnom, :pprenom, :pdn, :pcode)";

            using (OracleConnection con = new OracleConnection(chaineConnexion))
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                cmd.BindByName = true;
                cmd.Parameters.Add("pmat", OracleDbType.Int32).Value = a.Matricule;
                cmd.Parameters.Add("pnom", OracleDbType.Varchar2).Value = a.Nom;
                cmd.Parameters.Add("pprenom", OracleDbType.Varchar2).Value = a.Prenom;
                cmd.Parameters.Add("pdn", OracleDbType.Date).Value = a.DateNais;
                cmd.Parameters.Add("pcode", OracleDbType.Int32).Value = a.Code;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        //_____________________________________________________________________//
        public int ModifierAdherent(AdherentInfo a)
        {
            const string sql =
                "UPDATE ADHERENT SET NOM = :pnom, PRENOM = :pprenom, " +
                "DATE_NAIS = :pdn, CODE = :pcode WHERE MATRICULE = :pmat";

            using (OracleConnection con = new OracleConnection(chaineConnexion))
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                cmd.BindByName = true;
                cmd.Parameters.Add("pnom", OracleDbType.Varchar2).Value = a.Nom;
                cmd.Parameters.Add("pprenom", OracleDbType.Varchar2).Value = a.Prenom;
                cmd.Parameters.Add("pdn", OracleDbType.Date).Value = a.DateNais;
                cmd.Parameters.Add("pcode", OracleDbType.Int32).Value = a.Code;
                cmd.Parameters.Add("pmat", OracleDbType.Int32).Value = a.Matricule;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        //_____________________________________________________________________//
        public int SupprimerAdherent(int matricule)
        {
            const string sql = "DELETE FROM ADHERENT WHERE MATRICULE = :pmat";

            using (OracleConnection con = new OracleConnection(chaineConnexion))
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                cmd.BindByName = true;
                cmd.Parameters.Add("pmat", OracleDbType.Int32).Value = matricule;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
