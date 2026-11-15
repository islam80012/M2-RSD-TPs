using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Windows.Forms;
using Interfaces;

namespace Client
{
    // Application Windows Forms : Présentation (les contrôles sont créés en code,
    // en TP on peut les poser avec le designer en gardant les mêmes noms)
    public class Presentation : Form
    {
        private ISociale sociale;                        // proxy de l'objet distant

        private ComboBox cbType;
        private Button btnRechercher, btnCharger, btnAjouter, btnModifier, btnSupprimer;
        private TextBox txtCode, txtDesignation, txtNb, txtAdresse, txtDate;
        private TextBox txtMatricule, txtNom, txtPrenom, txtDateNais;
        private DataGridView dgv;

        private AdherentInfo adherentCharge;             // adhérent chargé par « Rechercher »

        //_____________________________________________________________________//
        public Presentation()
        {
            InitialiserInterface();
            ConnexionServeur();
        }

        //_____________________________________________________________________//
        private void ConnexionServeur()
        {
            try
            {
                // TypeFilterLevel.Full : le serveur doit désérialiser nos AdherentInfo
                BinaryServerFormatterSinkProvider fournisseurServeur = new BinaryServerFormatterSinkProvider();
                fournisseurServeur.TypeFilterLevel = TypeFilterLevel.Full;
                BinaryClientFormatterSinkProvider fournisseurClient = new BinaryClientFormatterSinkProvider();

                Hashtable proprietes = new Hashtable();
                proprietes["port"] = 0;                  // port libre côté client

                ChannelServices.RegisterChannel(new TcpChannel(proprietes, fournisseurClient, fournisseurServeur), false);
                sociale = (ISociale)Activator.GetObject(typeof(ISociale),
                                                        "tcp://localhost:1069/Sociale");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion au serveur : " + ex.Message);
            }
        }

        //_____________________________________________________________________//
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            if (cbType.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir un type d'agence.");
                return;
            }

            try
            {
                // Appel distant 1 : la caisse
                CaisseSociale c = sociale.RechercherCaisse(cbType.SelectedItem.ToString());
                if (c == null)
                {
                    MessageBox.Show("Aucune caisse trouvée pour ce type.");
                    Vider();
                    return;
                }

                txtCode.Text = c.Code.ToString();
                txtDesignation.Text = c.Designation;
                txtNb.Text = c.NbAdherent.ToString();
                txtAdresse.Text = c.Adresse;
                txtDate.Text = c.DateCreation.ToShortDateString();

                // Appel distant 2 : les adhérents cotisants
                List<AdherentInfo> liste = sociale.ListerAdherents(c.Code);
                dgv.DataSource = liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message + "\nLe serveur est-il lancé ?");
            }
        }

        //_____________________________________________________________________//
        private void Vider()
        {
            txtCode.Clear(); txtDesignation.Clear(); txtNb.Clear();
            txtAdresse.Clear(); txtDate.Clear();
            ViderAdherent();
            dgv.DataSource = null;
        }

        private void ViderAdherent()
        {
            txtMatricule.Clear(); txtNom.Clear(); txtPrenom.Clear(); txtDateNais.Clear();
            adherentCharge = null;
        }

        //_____________________________________________________________________//
        // Idée du formulaire : on saisit le matricule, on clique sur « Rechercher »
        // (ou on clique sur une ligne du tableau pour le pré-remplir),
        // les informations de l'adhérent sont chargées, puis on modifie ou supprime.
        private void btnCharger_Click(object sender, EventArgs e)
        {
            int matricule;
            if (!int.TryParse(txtMatricule.Text.Trim(), out matricule))
            {
                MessageBox.Show("Saisissez un matricule valide.");
                return;
            }

            try
            {
                AdherentInfo a = sociale.RechercherAdherent(matricule);

                if (a == null)
                {
                    MessageBox.Show("Aucun adhérent avec le matricule " + matricule + ".");
                    adherentCharge = null;
                    txtNom.Clear(); txtPrenom.Clear(); txtDateNais.Clear();
                    return;
                }

                adherentCharge = a;
                txtNom.Text = a.Nom;
                txtPrenom.Text = a.Prenom;
                txtDateNais.Text = a.DateNais.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message + "\nLe serveur est-il lancé ?");
            }
        }

        //_____________________________________________________________________//
        // Cliquer sur une ligne du tableau remplit les champs adhérent
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            AdherentInfo a = dgv.Rows[e.RowIndex].DataBoundItem as AdherentInfo;
            if (a == null) return;

            adherentCharge = a;
            txtMatricule.Text = a.Matricule.ToString();
            txtNom.Text = a.Nom;
            txtPrenom.Text = a.Prenom;
            txtDateNais.Text = a.DateNais.ToString("dd/MM/yyyy");
        }

        //_____________________________________________________________________//
        // Lit et valide les champs adhérent ; renvoie null si saisie invalide
        private AdherentInfo LireAdherent()
        {
            int matricule;
            if (!int.TryParse(txtMatricule.Text.Trim(), out matricule))
            {
                MessageBox.Show("Matricule invalide.");
                return null;
            }

            if (txtNom.Text.Trim() == "" || txtPrenom.Text.Trim() == "")
            {
                MessageBox.Show("Le nom et le prénom sont obligatoires.");
                return null;
            }

            DateTime dateNais;
            if (!DateTime.TryParseExact(txtDateNais.Text.Trim(), "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dateNais))
            {
                MessageBox.Show("Date de naissance invalide (jj/mm/aaaa).");
                return null;
            }

            int code;
            if (!int.TryParse(txtCode.Text, out code))
            {
                MessageBox.Show("Recherchez d'abord une caisse.");
                return null;
            }

            AdherentInfo a = new AdherentInfo();
            a.Matricule = matricule;
            a.Nom = txtNom.Text.Trim();
            a.Prenom = txtPrenom.Text.Trim();
            a.DateNais = dateNais;
            // Un adhérent chargé garde sa caisse d'origine ; sinon on prend la caisse affichée
            a.Code = (adherentCharge != null && adherentCharge.Matricule == matricule)
                     ? adherentCharge.Code
                     : code;
            return a;
        }

        //_____________________________________________________________________//
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            AdherentInfo a = LireAdherent();
            if (a == null) return;

            try
            {
                int n = sociale.AjouterAdherent(a);
                MessageBox.Show(n > 0 ? "Adhérent ajouté." : "Aucun adhérent ajouté.");
                ViderAdherent();
                RafraichirListe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        //_____________________________________________________________________//
        private void btnModifier_Click(object sender, EventArgs e)
        {
            AdherentInfo a = LireAdherent();
            if (a == null) return;

            if (MessageBox.Show("Modifier l'adhérent " + a.Matricule + " ?", "Confirmation",
                                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                int n = sociale.ModifierAdherent(a);
                MessageBox.Show(n > 0 ? "Adhérent modifié." : "Aucun adhérent modifié.");
                RafraichirListe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        //_____________________________________________________________________//
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int matricule;
            if (!int.TryParse(txtMatricule.Text.Trim(), out matricule))
            {
                MessageBox.Show("Sélectionnez un adhérent à supprimer.");
                return;
            }

            if (MessageBox.Show("Supprimer l'adhérent " + matricule + " ?", "Confirmation",
                                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                int n = sociale.SupprimerAdherent(matricule);
                MessageBox.Show(n > 0 ? "Adhérent supprimé." : "Aucun adhérent supprimé.");
                ViderAdherent();
                RafraichirListe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        //_____________________________________________________________________//
        // Recharge le tableau des adhérents de la caisse affichée
        private void RafraichirListe()
        {
            int code;
            if (!int.TryParse(txtCode.Text, out code)) return;

            try
            {
                dgv.DataSource = sociale.ListerAdherents(code);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Presentation
            // 
            this.ClientSize = new System.Drawing.Size(530, 261);
            this.Name = "Presentation";
            this.ResumeLayout(false);

        }

        //_____________________________________________________________________//
        private void InitialiserInterface()
        {
            Text = "Presentation";
            ClientSize = new Size(720, 535);
            StartPosition = FormStartPosition.CenterScreen;

            Label titre = new Label();
            titre.Text = "Liste des adhérents de la sécurité sociale";
            titre.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            titre.AutoSize = true; titre.Location = new Point(180, 15);
            Controls.Add(titre);

            Controls.Add(Etiquette("Type agence :", 25, 60));
            cbType = new ComboBox();
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.Items.AddRange(new object[] { "CNAS", "CASNOS", "CNR" });
            cbType.Location = new Point(110, 57); cbType.Width = 120;
            Controls.Add(cbType);

            btnRechercher = new Button();
            btnRechercher.Text = "Rechercher";
            btnRechercher.Location = new Point(330, 55); btnRechercher.Width = 100;
            btnRechercher.Click += btnRechercher_Click;
            Controls.Add(btnRechercher);

            Label desc = Etiquette("Description de l'agence", 25, 100);
            desc.Font = new Font(desc.Font, FontStyle.Bold);
            Controls.Add(desc);

            Controls.Add(Etiquette("Code agence :", 25, 130));
            txtCode = Champ(110, 127, 70);
            Controls.Add(Etiquette("Designation :", 195, 130));
            txtDesignation = Champ(275, 127, 150);
            Controls.Add(Etiquette("Nombre cotisants :", 440, 130));
            txtNb = Champ(550, 127, 60);

            Controls.Add(Etiquette("Adresse :", 25, 165));
            txtAdresse = Champ(110, 162, 150);
            Controls.Add(Etiquette("Date de création :", 275, 165));
            txtDate = Champ(385, 162, 100);

            Label sectionAdherent = Etiquette("Adhérent (ajout / modification)", 25, 200);
            sectionAdherent.Font = new Font(sectionAdherent.Font, FontStyle.Bold);
            Controls.Add(sectionAdherent);

            Controls.Add(Etiquette("Matricule :", 25, 230));
            txtMatricule = Champ(95, 227, 60, false);
            btnCharger = Bouton("Rechercher", 165, 225);
            btnCharger.Click += btnCharger_Click;
            Controls.Add(Etiquette("Nom :", 275, 230));
            txtNom = Champ(315, 227, 105, false);
            Controls.Add(Etiquette("Prénom :", 430, 230));
            txtPrenom = Champ(490, 227, 105, false);

            Controls.Add(Etiquette("Date naissance :", 25, 265));
            txtDateNais = Champ(130, 262, 100, false);

            btnAjouter = Bouton("Ajouter", 260, 260);
            btnAjouter.Click += btnAjouter_Click;
            btnModifier = Bouton("Modifier", 370, 260);
            btnModifier.Click += btnModifier_Click;
            btnSupprimer = Bouton("Supprimer", 480, 260);
            btnSupprimer.Click += btnSupprimer_Click;

            dgv = new DataGridView();
            dgv.Location = new Point(25, 305); dgv.Size = new Size(670, 200);
            dgv.AutoGenerateColumns = false;
            dgv.ReadOnly = true; dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Columns.Add(Colonne("Matricule", "Matricule"));
            dgv.Columns.Add(Colonne("Nom", "Nom"));
            dgv.Columns.Add(Colonne("Prénom", "Prenom"));
            dgv.Columns.Add(Colonne("Date naissance", "DateNais"));
            dgv.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.CellClick += dgv_CellClick;
            Controls.Add(dgv);
        }

        private Button Bouton(string texte, int x, int y)
        {
            Button b = new Button();
            b.Text = texte;
            b.Location = new Point(x, y); b.Width = 100;
            Controls.Add(b);
            return b;
        }

        private Label Etiquette(string texte, int x, int y)
        {
            Label l = new Label(); l.Text = texte; l.AutoSize = true; l.Location = new Point(x, y);
            return l;
        }

        private TextBox Champ(int x, int y, int largeur, bool lectureSeule = true)
        {
            TextBox t = new TextBox(); t.Location = new Point(x, y); t.Width = largeur; t.ReadOnly = lectureSeule;
            Controls.Add(t);
            return t;
        }

        private DataGridViewTextBoxColumn Colonne(string entete, string propriete)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.HeaderText = entete; c.DataPropertyName = propriete;
            return c;
        }
    }
}
