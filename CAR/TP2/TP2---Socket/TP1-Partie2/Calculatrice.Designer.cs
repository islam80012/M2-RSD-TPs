namespace TP1_Partie2
{
    partial class Calculatrice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Un = new System.Windows.Forms.Button();
            this.Deux = new System.Windows.Forms.Button();
            this.Trois = new System.Windows.Forms.Button();
            this.Zero = new System.Windows.Forms.Button();
            this.Egal = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.Point = new System.Windows.Forms.Button();
            this.Moins = new System.Windows.Forms.Button();
            this.Resultat = new System.Windows.Forms.TextBox();
            this.Six = new System.Windows.Forms.Button();
            this.Cinq = new System.Windows.Forms.Button();
            this.Quatre = new System.Windows.Forms.Button();
            this.Neuf = new System.Windows.Forms.Button();
            this.Huit = new System.Windows.Forms.Button();
            this.Sept = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.Button();
            this.CE = new System.Windows.Forms.Button();
            this.Retour = new System.Windows.Forms.Button();
            this.Slach = new System.Windows.Forms.Button();
            this.Fois = new System.Windows.Forms.Button();
            this.PlusMoins = new System.Windows.Forms.Button();
            this.Fraction = new System.Windows.Forms.Button();
            this.Pourcent = new System.Windows.Forms.Button();
            this.Racine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Un
            // 
            this.Un.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Un.Location = new System.Drawing.Point(12, 188);
            this.Un.Name = "Un";
            this.Un.Size = new System.Drawing.Size(46, 31);
            this.Un.TabIndex = 0;
            this.Un.Text = "1";
            this.Un.UseVisualStyleBackColor = true;
            this.Un.Click += new System.EventHandler(this.Button_Click);
            // 
            // Deux
            // 
            this.Deux.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deux.Location = new System.Drawing.Point(62, 188);
            this.Deux.Name = "Deux";
            this.Deux.Size = new System.Drawing.Size(44, 31);
            this.Deux.TabIndex = 1;
            this.Deux.Text = "2";
            this.Deux.UseVisualStyleBackColor = true;
            this.Deux.Click += new System.EventHandler(this.Button_Click);
            // 
            // Trois
            // 
            this.Trois.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trois.Location = new System.Drawing.Point(112, 188);
            this.Trois.Name = "Trois";
            this.Trois.Size = new System.Drawing.Size(44, 31);
            this.Trois.TabIndex = 2;
            this.Trois.Text = "3";
            this.Trois.UseVisualStyleBackColor = true;
            this.Trois.Click += new System.EventHandler(this.Button_Click);
            // 
            // Zero
            // 
            this.Zero.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zero.Location = new System.Drawing.Point(12, 225);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(94, 31);
            this.Zero.TabIndex = 3;
            this.Zero.Text = "0";
            this.Zero.UseVisualStyleBackColor = true;
            this.Zero.Click += new System.EventHandler(this.Button_Click);
            // 
            // Egal
            // 
            this.Egal.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Egal.Location = new System.Drawing.Point(212, 188);
            this.Egal.Name = "Egal";
            this.Egal.Size = new System.Drawing.Size(44, 68);
            this.Egal.TabIndex = 4;
            this.Egal.Text = "=";
            this.Egal.UseVisualStyleBackColor = true;
            this.Egal.Click += new System.EventHandler(this.Egal_Click);
            // 
            // Plus
            // 
            this.Plus.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Plus.Location = new System.Drawing.Point(162, 225);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(44, 31);
            this.Plus.TabIndex = 5;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.Operation_Click);
            // 
            // Point
            // 
            this.Point.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Point.Location = new System.Drawing.Point(112, 225);
            this.Point.Name = "Point";
            this.Point.Size = new System.Drawing.Size(44, 31);
            this.Point.TabIndex = 6;
            this.Point.Text = ".";
            this.Point.UseVisualStyleBackColor = true;
            // 
            // Moins
            // 
            this.Moins.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Moins.Location = new System.Drawing.Point(162, 188);
            this.Moins.Name = "Moins";
            this.Moins.Size = new System.Drawing.Size(44, 31);
            this.Moins.TabIndex = 7;
            this.Moins.Text = "-";
            this.Moins.UseVisualStyleBackColor = true;
            this.Moins.Click += new System.EventHandler(this.Operation_Click);
            // 
            // Resultat
            // 
            this.Resultat.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resultat.Location = new System.Drawing.Point(641, 12);
            this.Resultat.Name = "Resultat";
            this.Resultat.Size = new System.Drawing.Size(244, 29);
            this.Resultat.TabIndex = 8;
            this.Resultat.Text = "0";
            this.Resultat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Six
            // 
            this.Six.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Six.Location = new System.Drawing.Point(112, 151);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(44, 31);
            this.Six.TabIndex = 11;
            this.Six.Text = "6";
            this.Six.UseVisualStyleBackColor = true;
            this.Six.Click += new System.EventHandler(this.Button_Click);
            // 
            // Cinq
            // 
            this.Cinq.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cinq.Location = new System.Drawing.Point(62, 151);
            this.Cinq.Name = "Cinq";
            this.Cinq.Size = new System.Drawing.Size(44, 31);
            this.Cinq.TabIndex = 10;
            this.Cinq.Text = "5";
            this.Cinq.UseVisualStyleBackColor = true;
            this.Cinq.Click += new System.EventHandler(this.Button_Click);
            // 
            // Quatre
            // 
            this.Quatre.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quatre.Location = new System.Drawing.Point(12, 151);
            this.Quatre.Name = "Quatre";
            this.Quatre.Size = new System.Drawing.Size(46, 31);
            this.Quatre.TabIndex = 9;
            this.Quatre.Text = "4";
            this.Quatre.UseVisualStyleBackColor = true;
            this.Quatre.Click += new System.EventHandler(this.Button_Click);
            // 
            // Neuf
            // 
            this.Neuf.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Neuf.Location = new System.Drawing.Point(112, 114);
            this.Neuf.Name = "Neuf";
            this.Neuf.Size = new System.Drawing.Size(44, 31);
            this.Neuf.TabIndex = 14;
            this.Neuf.Text = "9";
            this.Neuf.UseVisualStyleBackColor = true;
            this.Neuf.Click += new System.EventHandler(this.Button_Click);
            // 
            // Huit
            // 
            this.Huit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Huit.Location = new System.Drawing.Point(62, 114);
            this.Huit.Name = "Huit";
            this.Huit.Size = new System.Drawing.Size(44, 31);
            this.Huit.TabIndex = 13;
            this.Huit.Text = "8";
            this.Huit.UseVisualStyleBackColor = true;
            this.Huit.Click += new System.EventHandler(this.Button_Click);
            // 
            // Sept
            // 
            this.Sept.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sept.Location = new System.Drawing.Point(12, 114);
            this.Sept.Name = "Sept";
            this.Sept.Size = new System.Drawing.Size(46, 31);
            this.Sept.TabIndex = 12;
            this.Sept.Text = "7";
            this.Sept.UseVisualStyleBackColor = true;
            this.Sept.Click += new System.EventHandler(this.Button_Click);
            // 
            // C
            // 
            this.C.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C.Location = new System.Drawing.Point(112, 77);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(44, 31);
            this.C.TabIndex = 17;
            this.C.Text = "C";
            this.C.UseVisualStyleBackColor = true;
            this.C.Click += new System.EventHandler(this.C_Click);
            // 
            // CE
            // 
            this.CE.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE.Location = new System.Drawing.Point(62, 77);
            this.CE.Name = "CE";
            this.CE.Size = new System.Drawing.Size(44, 31);
            this.CE.TabIndex = 16;
            this.CE.Text = "CE";
            this.CE.UseVisualStyleBackColor = true;
            // 
            // Retour
            // 
            this.Retour.Font = new System.Drawing.Font("Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Retour.Location = new System.Drawing.Point(12, 77);
            this.Retour.Name = "Retour";
            this.Retour.Size = new System.Drawing.Size(46, 31);
            this.Retour.TabIndex = 15;
            this.Retour.Text = "";
            this.Retour.UseVisualStyleBackColor = true;
            // 
            // Slach
            // 
            this.Slach.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Slach.Location = new System.Drawing.Point(162, 114);
            this.Slach.Name = "Slach";
            this.Slach.Size = new System.Drawing.Size(44, 31);
            this.Slach.TabIndex = 19;
            this.Slach.Text = "/";
            this.Slach.UseVisualStyleBackColor = true;
            this.Slach.Click += new System.EventHandler(this.Operation_Click);
            // 
            // Fois
            // 
            this.Fois.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fois.Location = new System.Drawing.Point(162, 151);
            this.Fois.Name = "Fois";
            this.Fois.Size = new System.Drawing.Size(44, 31);
            this.Fois.TabIndex = 18;
            this.Fois.Text = "*";
            this.Fois.UseVisualStyleBackColor = true;
            this.Fois.Click += new System.EventHandler(this.Operation_Click);
            // 
            // PlusMoins
            // 
            this.PlusMoins.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlusMoins.Location = new System.Drawing.Point(162, 77);
            this.PlusMoins.Name = "PlusMoins";
            this.PlusMoins.Size = new System.Drawing.Size(44, 31);
            this.PlusMoins.TabIndex = 20;
            this.PlusMoins.Text = "±";
            this.PlusMoins.UseVisualStyleBackColor = true;
            this.PlusMoins.Click += new System.EventHandler(this.Operation_Click);
            // 
            // Fraction
            // 
            this.Fraction.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fraction.Location = new System.Drawing.Point(214, 151);
            this.Fraction.Name = "Fraction";
            this.Fraction.Size = new System.Drawing.Size(44, 31);
            this.Fraction.TabIndex = 21;
            this.Fraction.Text = "1/x";
            this.Fraction.UseVisualStyleBackColor = true;
            this.Fraction.Click += new System.EventHandler(this.Operation_Click);
            // 
            // Pourcent
            // 
            this.Pourcent.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pourcent.Location = new System.Drawing.Point(214, 114);
            this.Pourcent.Name = "Pourcent";
            this.Pourcent.Size = new System.Drawing.Size(44, 31);
            this.Pourcent.TabIndex = 22;
            this.Pourcent.Text = "%";
            this.Pourcent.UseVisualStyleBackColor = true;
            this.Pourcent.Click += new System.EventHandler(this.Operation_Click);
            // 
            // Racine
            // 
            this.Racine.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Racine.Location = new System.Drawing.Point(214, 77);
            this.Racine.Name = "Racine";
            this.Racine.Size = new System.Drawing.Size(44, 31);
            this.Racine.TabIndex = 23;
            this.Racine.Text = "√";
            this.Racine.UseVisualStyleBackColor = true;
            this.Racine.Click += new System.EventHandler(this.Operation_Click);
            // 
            // Calculatrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 262);
            this.Controls.Add(this.Racine);
            this.Controls.Add(this.Pourcent);
            this.Controls.Add(this.Fraction);
            this.Controls.Add(this.PlusMoins);
            this.Controls.Add(this.Slach);
            this.Controls.Add(this.Fois);
            this.Controls.Add(this.C);
            this.Controls.Add(this.CE);
            this.Controls.Add(this.Retour);
            this.Controls.Add(this.Neuf);
            this.Controls.Add(this.Huit);
            this.Controls.Add(this.Sept);
            this.Controls.Add(this.Six);
            this.Controls.Add(this.Cinq);
            this.Controls.Add(this.Quatre);
            this.Controls.Add(this.Resultat);
            this.Controls.Add(this.Moins);
            this.Controls.Add(this.Point);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.Egal);
            this.Controls.Add(this.Zero);
            this.Controls.Add(this.Trois);
            this.Controls.Add(this.Deux);
            this.Controls.Add(this.Un);
            this.Name = "Calculatrice";
            this.Text = "Calculatrice";
            this.Load += new System.EventHandler(this.Calculatrice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Un;
        private System.Windows.Forms.Button Deux;
        private System.Windows.Forms.Button Trois;
        private System.Windows.Forms.Button Zero;
        private System.Windows.Forms.Button Egal;
        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button Point;
        private System.Windows.Forms.Button Moins;
        private System.Windows.Forms.TextBox Resultat;
        private System.Windows.Forms.Button Six;
        private System.Windows.Forms.Button Cinq;
        private System.Windows.Forms.Button Quatre;
        private System.Windows.Forms.Button Neuf;
        private System.Windows.Forms.Button Huit;
        private System.Windows.Forms.Button Sept;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button CE;
        private System.Windows.Forms.Button Retour;
        private System.Windows.Forms.Button Slach;
        private System.Windows.Forms.Button Fois;
        private System.Windows.Forms.Button PlusMoins;
        private System.Windows.Forms.Button Fraction;
        private System.Windows.Forms.Button Pourcent;
        private System.Windows.Forms.Button Racine;
    }
}