using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace TP1_Partie2
{
    public partial class Calculatrice : Form
    {
        string Operande, Operateur;

        // Référence vers l'objet distant (serveur)
        private RemotingInterfaces.IRemoteOperation remoteOperation;

        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        //________________________________________________________________________//
        public Calculatrice()
        {
            InitializeComponent();
            ConnexionServeur();
        }
        //________________________________________________________________________//
        // Connexion à l'objet distant
        private void ConnexionServeur()
        {
            try
            {
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);
                remoteOperation = (RemotingInterfaces.IRemoteOperation)Activator.GetObject(
                    typeof(RemotingInterfaces.IRemoteOperation),
                    "tcp://localhost:1069/RemoteOperation");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion au serveur : " + ex.Message);
            }
        }
        //________________________________________________________________________//
        // Chiffres (0 à 9) et point "."  -> méthode du CLIENT
        private void Button_Click(object sender, EventArgs e)
        {
            string t = ((Button)sender).Text;

            if (t == "." && Resultat.Text.Contains(".")) return;   // un seul point

            if (Resultat.Text == "0" && t != ".") { Resultat.Text = t; }
            else { Resultat.Text = Resultat.Text + t; }
        }
        //________________________________________________________________________//
        // C -> méthode du CLIENT
        private void C_Click(object sender, EventArgs e)
        {
            Resultat.Text = "0";
        }
        //________________________________________________________________________//
        // CE -> méthode du CLIENT (à relier au bouton CE si tu l'as)
        private void CE_Click(object sender, EventArgs e)
        {
            Resultat.Text = "0";
            Operande = null;
            Operateur = null;
        }
        //________________________________________________________________________//
        // ← -> méthode du CLIENT (à relier au bouton ← si tu l'as)
        private void Retour_Click(object sender, EventArgs e)
        {
            if (Resultat.Text.Length > 1)
                Resultat.Text = Resultat.Text.Substring(0, Resultat.Text.Length - 1);
            else
                Resultat.Text = "0";
        }
        //________________________________________________________________________//
        // +/- -> méthode du CLIENT (à relier au bouton +/- si tu l'as)
        private void PlusMoins_Click(object sender, EventArgs e)
        {
            double v;
            if (double.TryParse(Resultat.Text, NumberStyles.Float, Inv, out v) && v != 0)
                Resultat.Text = (-v).ToString("G15", Inv);
        }
        //________________________________________________________________________//
        // Boutons + - * /  : on mémorise le 1er opérande et l'opérateur
        private void Operation_Click(object sender, EventArgs e)
        {
            Operande = Resultat.Text; Resultat.Text = "";
            Operateur = ((Button)sender).Text;
        }
        //________________________________________________________________________//
        // Bouton = : appel des méthodes distantes (exécutées par le SERVEUR)
        private void Egal_Click(object sender, EventArgs e)
        {
            if (Operande == null || Operateur == null || Resultat.Text == "") return;

            double a, b, r;
            if (!double.TryParse(Operande, NumberStyles.Float, Inv, out a) ||
                !double.TryParse(Resultat.Text, NumberStyles.Float, Inv, out b))
            {
                MessageBox.Show("Saisie invalide");
                return;
            }

            try
            {
                switch (Operateur)
                {
                    case "+":
                        r = remoteOperation.Addition(a, b);
                        break;
                    case "-":
                        r = remoteOperation.Soustraction(a, b);
                        break;
                    case "*":
                        r = remoteOperation.Multiplication(a, b);
                        break;
                    case "/":
                        if (b == 0) { Resultat.Text = "Division impossible"; Operande = null; Operateur = null; return; }
                        r = remoteOperation.Division(a, b);
                        break;
                    default:
                        MessageBox.Show("Opération invalide");
                        return;
                }
                Resultat.Text = r.ToString("G15", Inv);
                Operande = null;
                Operateur = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Serveur injoignable. Lancez d'abord le serveur.");
            }
        }
        //________________________________________________________________________//
        // Boutons √  %  1/x : méthodes distantes à un seul opérande
        // (à relier aux boutons √, % et 1/x dans l'onglet Événements > Click)
        private void Unaire_Click(object sender, EventArgs e)
        {
            double v, r;
            if (!double.TryParse(Resultat.Text, NumberStyles.Float, Inv, out v)) return;

            try
            {
                switch (((Button)sender).Text)
                {
                    case "√":
                        if (v < 0) { Resultat.Text = "Entrée invalide"; return; }
                        r = remoteOperation.Racine(v);
                        break;
                    case "%":
                        r = remoteOperation.Pourcentage(v);
                        break;
                    case "1/x":
                        if (v == 0) { Resultat.Text = "Division impossible"; return; }
                        r = remoteOperation.Fraction(v);
                        break;
                    default:
                        return;
                }
                Resultat.Text = r.ToString("G15", Inv);
            }
            catch (Exception)
            {
                MessageBox.Show("Serveur injoignable. Lancez d'abord le serveur.");
            }
        }

        //________________________________________________________________________//
        private void Calculatrice_Load(object sender, EventArgs e)
        {

        }
        //________________________________________________________________________//
    }
}