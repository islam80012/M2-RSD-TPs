using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ado_Exemple5
{
    public partial class Form1 : Form
    {
        private static string SQL, oradb;
        private static OracleConnection con;
        private static OracleCommand cmd;
        //______________________________________________________________________________________________// 
        public Form1()
        {
            InitializeComponent();
        }
        //______________________________________________________________________________________________// 
        // Recharge la table Etudiant dans le DataGridView
        private void ChargerGrille()
        {
            string cmdQuery = "SELECT * FROM Etudiant ORDER BY matricule";
            OracleDataAdapter myAdapter = new OracleDataAdapter(cmdQuery, con);

            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "TableOracle");
            DataView dvSample = ds.Tables["TableOracle"].DefaultView;
            dataGridView1.DataSource = dvSample;
        }
        //______________________________________________________________________________________________// 
        private void Afficher_Click(object sender, EventArgs e)
        {
            ChargerGrille();
            textBox1.Focus();
        }
        //______________________________________________________________________________________________// 
        private void Fermer_Click(object sender, EventArgs e)
        {
            con.Close(); this.Close();
        }
        //______________________________________________________________________________________________// 
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox3.Focus();
            con = new OracleConnection();
            string oradb = "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
            // Example de connexion à la base de données Oracle dans une base de données distantes
            //string oradb = "Data Source=10.27.211.1; User Id=oracle; Password=manager;";
            con = new OracleConnection(oradb);
            con.Open();
        }
        //______________________________________________________________________________________________// 
        private void Ajouter_Click(object sender, EventArgs e)
        {
            // 1. Vérifier que les 3 champs sont remplis
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Veuillez remplir les 3 champs : matricule, nom et prénom.",
                                "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Le matricule doit être un entier
            int matricule;
            if (!int.TryParse(textBox3.Text.Trim(), out matricule))
            {
                MessageBox.Show("Le matricule doit être un nombre entier.",
                                "Matricule invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            try
            {
                if (con.State != ConnectionState.Open) con.Open();

                // 3. Requête paramétrée (évite les erreurs avec les apostrophes et l'injection SQL)
                SQL = "INSERT INTO Etudiant (matricule, nom, prenom) VALUES (:mat, :nom, :prenom)";
                cmd = new OracleCommand(SQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.BindByName = true;
                cmd.Parameters.Add("mat", OracleDbType.Int32).Value = matricule;
                cmd.Parameters.Add("nom", OracleDbType.Varchar2).Value = textBox4.Text.Trim();
                cmd.Parameters.Add("prenom", OracleDbType.Varchar2).Value = textBox5.Text.Trim();

                int x = cmd.ExecuteNonQuery();
                if (x == 1)
                {
                    MessageBox.Show("Étudiant ajouté avec succès...", "Succès",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
                    textBox3.Focus();
                    ChargerGrille();
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1) // ORA-00001 : contrainte d'unicité violée
                    MessageBox.Show("Ce matricule existe déjà.", "Doublon",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Erreur Oracle : " + ex.Message, "Erreur",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //______________________________________________________________________________________________// 
        private void Modifier_Click(object sender, EventArgs e)
        {
            con.Close(); con.Open();
            SQL = " UPDATE Etudiant  SET nom =('" + @textBox1.Text + "') , prenom = ('" +
                    textBox2.Text + "')  WHERE matricule = (" + int.Parse(comboBox1.Text) + ")  ";
            cmd = new OracleCommand(SQL, con);
            cmd.CommandType = CommandType.Text;

            int x = cmd.ExecuteNonQuery();
            if (x == 1) { MessageBox.Show("Enregistrement modifié avec succès...  "); }
            else { MessageBox.Show("Enegistrement introuvable..."); }
        }
        //______________________________________________________________________________________________// 
        private void comboBox1_Click(object sender, EventArgs e)
        {
            string cmdQuery = "SELECT matricule, nom, prenom FROM Etudiant";
            OracleDataAdapter myAdapter = new OracleDataAdapter(cmdQuery, con);

            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "Etudiant");

            comboBox1.DataSource = ds.Tables["Etudiant"].DefaultView;
            comboBox1.DisplayMember = "matricule";
        }
        //______________________________________________________________________________________________// 
        private void Rechercher_Click(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
            string cmdQuery = "SELECT matricule, nom, prenom FROM Etudiant WHERE matricule= (" +
                                     comboBox1.Text + ") ";
            OracleDataAdapter myAdapter = new OracleDataAdapter(cmdQuery, con);

            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "Etudiant");

            DataView dvSample = ds.Tables["Etudiant"].DefaultView;
            dataGridView1.DataSource = dvSample;

            textBox1.Text = ds.Tables["Etudiant"].Rows[0][1].ToString();
            textBox2.Text = ds.Tables["Etudiant"].Rows[0][2].ToString();
        }
        //______________________________________________________________________________________________// 
    }
}