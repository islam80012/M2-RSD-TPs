using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Partie2
{
    public partial class Calculatrice : Form
    {
        string Operande, Operateur;

        //________________________________________________________________________//
        public Calculatrice()
        {
            InitializeComponent();
        }
        //________________________________________________________________________//
        private void Button_Click(object sender, EventArgs e)
        {
             if (Resultat.Text == "0") { Resultat.Text = ((Button)sender).Text; }
             else { Resultat.Text = Resultat.Text + ((Button)sender).Text; }
        }
        //________________________________________________________________________//
        private void C_Click(object sender, EventArgs e)
        {
            Resultat.Text = "0";
        }
        //________________________________________________________________________//
        private void Operation_Click(object sender, EventArgs e)
        {
            Operande = Resultat.Text; Resultat.Text = "";
            Operateur = ((Button)sender).Text;
        }
        //________________________________________________________________________//
        private void Egal_Click(object sender, EventArgs e)
        {
            switch (Operateur)
            {
                
            
            }
        }

        private void Calculatrice_Load(object sender, EventArgs e)
        {

        }
        //________________________________________________________________________//

    }
}
