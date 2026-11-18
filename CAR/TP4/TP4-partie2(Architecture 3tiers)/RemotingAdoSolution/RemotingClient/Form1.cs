using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemotingClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RemoteConnection.Connect();
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
            RemoteConnection.operation.Afficher();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int matricule = int.Parse(textBox1.Text);
            string nom = textBox2.Text;
            string prenom = textBox3.Text;

            int x = RemoteConnection.operation.Ajouter(
                matricule, nom, prenom);

            if (x == 1)
            {
                MessageBox.Show("Etudiant ajouté avec succès");

                dataGridView1.DataSource =
                    RemoteConnection.operation.Afficher();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout");
            }
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int matricule = int.Parse(textBox1.Text);

            int x = RemoteConnection.operation.Supprimer(matricule);

            if (x == 1)
            {
                MessageBox.Show("Etudiant supprimé avec succès");

                dataGridView1.DataSource =
                    RemoteConnection.operation.Afficher();
            }
            else
            {
                MessageBox.Show("Etudiant introuvable");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int matricule = int.Parse(textBox1.Text);
            string nom = textBox2.Text;
            string prenom = textBox3.Text;

            int x = RemoteConnection.operation.Modifier(
                matricule, nom, prenom);

            if (x == 1)
            {
                MessageBox.Show("Etudiant modifié avec succès");

                dataGridView1.DataSource =
                    RemoteConnection.operation.Afficher();
            }
            else
            {
                MessageBox.Show("Etudiant introuvable");
            }
        }
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            int matricule = int.Parse(textBox1.Text);

            DataTable dt =
                RemoteConnection.operation.Rechercher(matricule);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

                textBox2.Text = dt.Rows[0]["nom"].ToString();
                textBox3.Text = dt.Rows[0]["prenom"].ToString();
            }
            else
            {
                MessageBox.Show("Etudiant introuvable");

                dataGridView1.DataSource = null;
            }
        }

    }
}
