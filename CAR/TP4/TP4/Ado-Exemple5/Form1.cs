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
        private void Afficher_Click(object sender, EventArgs e)
        {
            string cmdQuery = "SELECT * FROM Etudiant ORDER BY matricule";
            OracleDataAdapter myAdapter = new OracleDataAdapter(cmdQuery, con);

            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "TableOracle");
            DataView dvSample = ds.Tables["TableOracle"].DefaultView;
            dataGridView1.DataSource = dvSample;
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
            textBox1.Clear(); textBox1.Focus();
            con = new OracleConnection();
            string oradb = "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
            con = new OracleConnection(oradb);
            con.Open();
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