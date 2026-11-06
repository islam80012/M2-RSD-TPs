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
namespace Ado_Exemple2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //______________________________________________________________________________________________// 
        private void Afficher_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            string oradb = "Data Source=localhost:1521/XEPDB1; User Id=oracle; Password=manager;";
            con = new OracleConnection(oradb);
            con.Open();

            string cmdQuery = "SELECT * FROM Etudiant";
            OracleDataAdapter myAdapter = new OracleDataAdapter(cmdQuery, con);

            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "TableOracle");

            DataView dvSample = ds.Tables["TableOracle"].DefaultView;
            dataGridView1.DataSource = dvSample;

            con.Close();
        }
        //______________________________________________________________________________________________// 

    }
}