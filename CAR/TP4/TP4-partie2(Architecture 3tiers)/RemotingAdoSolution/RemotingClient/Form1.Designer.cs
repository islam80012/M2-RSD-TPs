
namespace RemotingClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1)).BeginInit();

            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.MinimumSize = new System.Drawing.Size(950, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Text = "Gestion des étudiants";

            // TITLE
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(35, 47, 62);
            this.lblTitle.Location = new System.Drawing.Point(45, 20);
            this.lblTitle.Text = "Gestion des étudiants";

            // SUBTITLE
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font(
                "Segoe UI", 10F);
            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(110, 120, 135);
            this.lblSubtitle.Location = new System.Drawing.Point(49, 62);
            this.lblSubtitle.Text =
                "Ajouter, modifier, rechercher et gérer les étudiants";

            // LABEL 1 - MATRICULE
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor =
                System.Drawing.Color.FromArgb(55, 65, 81);
            this.label1.Location = new System.Drawing.Point(50, 105);
            this.label1.Text = "Matricule";

            // TEXTBOX 1
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox1.Location = new System.Drawing.Point(155, 100);
            this.textBox1.Size = new System.Drawing.Size(220, 32);
            this.textBox1.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.TabIndex = 0;

            // LABEL 2 - NOM
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor =
                System.Drawing.Color.FromArgb(55, 65, 81);
            this.label2.Location = new System.Drawing.Point(410, 105);
            this.label2.Text = "Nom";

            // TEXTBOX 2
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox2.Location = new System.Drawing.Point(490, 100);
            this.textBox2.Size = new System.Drawing.Size(220, 32);
            this.textBox2.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.TabIndex = 1;

            // LABEL 3 - PRENOM
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor =
                System.Drawing.Color.FromArgb(55, 65, 81);
            this.label3.Location = new System.Drawing.Point(50, 160);
            this.label3.Text = "Prénom";

            // TEXTBOX 3
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox3.Location = new System.Drawing.Point(155, 155);
            this.textBox3.Size = new System.Drawing.Size(220, 32);
            this.textBox3.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.TabIndex = 2;

            // COMMON BUTTON STYLE
            System.Drawing.Font buttonFont =
                new System.Drawing.Font("Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            // BUTTON 1 - AJOUTER
            this.button1.Location = new System.Drawing.Point(50, 215);
            this.button1.Size = new System.Drawing.Size(160, 42);
            this.button1.Text = "Ajouter";
            this.button1.Name = "button1";
            this.button1.Font = buttonFont;
            this.button1.BackColor =
                System.Drawing.Color.FromArgb(37, 99, 160);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Click +=
                new System.EventHandler(this.btnAjouter_Click);

            // BUTTON 2 - AFFICHER
            this.button2.Location = new System.Drawing.Point(235, 215);
            this.button2.Size = new System.Drawing.Size(160, 42);
            this.button2.Text = "Afficher";
            this.button2.Name = "button2";
            this.button2.Font = buttonFont;
            this.button2.BackColor =
                System.Drawing.Color.FromArgb(71, 85, 105);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Click +=
                new System.EventHandler(this.btnAfficher_Click);

            // BUTTON 3 - RECHERCHER
            this.button5.Location = new System.Drawing.Point(420, 215);
            this.button5.Size = new System.Drawing.Size(160, 42);
            this.button5.Text = "Rechercher";
            this.button5.Name = "button5";
            this.button5.Font = buttonFont;
            this.button5.BackColor =
                System.Drawing.Color.FromArgb(71, 85, 105);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Click +=
                new System.EventHandler(this.btnRechercher_Click);

            // BUTTON 4 - MODIFIER
            this.button3.Location = new System.Drawing.Point(605, 215);
            this.button3.Size = new System.Drawing.Size(160, 42);
            this.button3.Text = "Modifier";
            this.button3.Name = "button3";
            this.button3.Font = buttonFont;
            this.button3.BackColor =
                System.Drawing.Color.FromArgb(71, 85, 105);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Click +=
                new System.EventHandler(this.btnModifier_Click);

            // BUTTON 5 - SUPPRIMER
            this.button4.Location = new System.Drawing.Point(790, 215);
            this.button4.Size = new System.Drawing.Size(160, 42);
            this.button4.Text = "Supprimer";
            this.button4.Name = "button4";
            this.button4.Font = buttonFont;
            this.button4.BackColor =
                System.Drawing.Color.FromArgb(180, 65, 65);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Click +=
                new System.EventHandler(this.btnSupprimer_Click);

            // DATAGRIDVIEW
            this.dataGridView1.Location =
                new System.Drawing.Point(50, 280);

            this.dataGridView1.Size =
                new System.Drawing.Size(900, 320);

            this.dataGridView1.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.dataGridView1.BackgroundColor =
                System.Drawing.Color.White;

            this.dataGridView1.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dataGridView1.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.dataGridView1.RowTemplate.Height = 35;

            this.dataGridView1.ColumnHeadersHeight = 40;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(45, 55, 72);

            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.dataGridView1.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(219, 234, 254);

            this.dataGridView1.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(30, 41, 59);

            this.dataGridView1.DefaultCellStyle.Padding =
                new System.Windows.Forms.Padding(5);

            this.dataGridView1.EnableHeadersVisualStyles = false;

            this.dataGridView1.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridView1.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridView1.MultiSelect = false;

            this.dataGridView1.AllowUserToAddRows = false;

            this.dataGridView1.ReadOnly = true;

            // ADD CONTROLS
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);

            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);

            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);

            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);

            this.Controls.Add(this.dataGridView1);

            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
    }
}
