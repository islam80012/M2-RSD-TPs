using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculatrice
{
    public partial class Calculatrice : Form
    {
        string Operande, Operateur;

        public Calculatrice()
        {
            InitializeComponent();

            // Liaison manuelle de l'événement Click pour le bouton "=" (Res)
            this.Res.Click += new System.EventHandler(this.Egale_Click);

            // Propriétés du TextBox multi-ligne
            this.textBox1.Location = new System.Drawing.Point(57, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 50);
            this.textBox1.TabIndex = 24;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Récupère la ligne active (la 2ème ligne si un opérateur a été choisi, sinon la 1ère)
            string[] lines = textBox1.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            string currentLine = lines.Length > 1 ? lines[1] : lines[0];

            if (currentLine == "0")
                currentLine = btn.Text;
            else
                currentLine += btn.Text;

            if (lines.Length > 1)
                textBox1.Text = lines[0] + Environment.NewLine + currentLine;
            else
                textBox1.Text = currentLine;
        }

        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Operande = textBox1.Text;
            Operateur = ((Button)sender).Text;

            // Affiche l'opérande et l'opérateur sur la première ligne, et prépare "0" sur la 2ème ligne
            textBox1.Text = Operande + " " + Operateur + Environment.NewLine + "0";
        }

        private void Egale_Click(object sender, EventArgs e)
        {
            // Récupérer uniquement la deuxième ligne (le nombre actuel saisi) pour éviter le format incorrect
            string[] lines = textBox1.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            string currentLine = lines.Length > 1 ? lines[1] : lines[0];

            switch (Operateur)
            {
                case "+":
                    {
                        textBox1.Text = (double.Parse(Operande) +
                            double.Parse(currentLine)).ToString();
                        break;
                    }
                case "-":
                    {
                        textBox1.Text = (double.Parse(Operande) -
                            double.Parse(currentLine)).ToString();
                        break;
                    }
                case "*":
                    {
                        textBox1.Text = (double.Parse(Operande) *
                            double.Parse(currentLine)).ToString();
                        break;
                    }
                case "/":
                    {
                        if (double.Parse(currentLine) != 0)
                        {
                            textBox1.Text = (double.Parse(Operande)
                            / double.Parse(currentLine)).ToString();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Division impossible !");
                            break;
                        }
                    }
                case "+ -":
                    {
                        textBox1.Text = (-1 * double.Parse(Operande)).ToString();
                        break;
                    }
                case "sqrt":
                    {
                        if (double.Parse(Operande) >= 0)
                        {
                            textBox1.Text = Math.Sqrt(double.Parse(Operande)).ToString();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Impossible de calculer la racine d'un nombre négatif !");
                            break;
                        }
                    }
                case "%":
                    {
                        textBox1.Text = (0.01 * double.Parse(Operande)).ToString();
                        break;
                    }
                case "1/x":
                case "divSurx":
                    {
                        if (double.Parse(Operande) != 0)
                        {
                            textBox1.Text = (1 / double.Parse(Operande)).ToString();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Impossible de fractionner sur zéro !");
                            break;
                        }
                    }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Gestion optionnelle du bouton retour arrière (<---)
        }
    }
}