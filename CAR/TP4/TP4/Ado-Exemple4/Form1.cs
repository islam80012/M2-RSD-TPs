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


namespace Ado_Exemple4
{
    public partial class Form1 : Form
    {
        private static string SQL, oradb;

        private static OracleConnection con;
        private static OracleCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }
        //_____________________________________________________________________________________________// 
        private void Afficher_Click(object sender, EventArgs e)
        {
            string cmdQuery = "SELECT * FROM Etudiant";
            OracleDataAdapter myAdapter = new OracleDataAdapter(cmdQuery, con);

            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "TableOracle");
            DataView dvSample = ds.Tables["TableOracle"].DefaultView;
            dataGridView1.DataSource = dvSample;
            textBox1.Focus();
        }
        //_____________________________________________________________________________________________// 
        private void Supprimer_Click(object sender, EventArgs e)
        {
            SQL = "DELETE FROM Etudiant WHERE matricule = (" + textBox1.Text + ") ";
            cmd = new OracleCommand(SQL, con);
            cmd.CommandType = CommandType.Text;
            textBox1.Clear(); textBox1.Focus();
            int x = cmd.ExecuteNonQuery();
            if (x == 1) { MessageBox.Show("Enregistrement supprimé avec succès...  "); }
            else { MessageBox.Show("Enegistrement introuvable..."); }
        }
        //_____________________________________________________________________________________________// 
        private void Fermer_Click(object sender, EventArgs e)
        {
            con.Close(); this.Close();
        }
        //_____________________________________________________________________________________________// 
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox1.Focus();
            con = new OracleConnection();
            string oradb = "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
            con = new OracleConnection(oradb);
            con.Open();
        }

        //_____________________________________________________________________________________________// 

    }
}
