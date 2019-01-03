namespace MacDoner
{
    partial class ficheLivre
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
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lblPrix = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtEditeur = new System.Windows.Forms.TextBox();
            this.lblEditeur = new System.Windows.Forms.Label();
            this.txtAnnee = new System.Windows.Forms.TextBox();
            this.lblAnnee = new System.Windows.Forms.Label();
            this.txtLangue = new System.Windows.Forms.TextBox();
            this.lblLangue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(248, 677);
            this.btnValider.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(112, 35);
            this.btnValider.TabIndex = 19;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(86, 677);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(112, 35);
            this.btnAnnuler.TabIndex = 18;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(212, 319);
            this.txtPrix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(148, 26);
            this.txtPrix.TabIndex = 17;
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(212, 228);
            this.txtTitre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(148, 26);
            this.txtTitre.TabIndex = 16;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(212, 144);
            this.txtISBN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(148, 26);
            this.txtISBN.TabIndex = 15;
            // 
            // txtNum
            // 
            this.txtNum.Enabled = false;
            this.txtNum.Location = new System.Drawing.Point(212, 65);
            this.txtNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(148, 26);
            this.txtNum.TabIndex = 14;
            // 
            // lblPrix
            // 
            this.lblPrix.AutoSize = true;
            this.lblPrix.Location = new System.Drawing.Point(83, 324);
            this.lblPrix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(34, 20);
            this.lblPrix.TabIndex = 13;
            this.lblPrix.Text = "Prix";
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(83, 233);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(40, 20);
            this.lblTitre.TabIndex = 12;
            this.lblTitre.Text = "Titre";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(83, 148);
            this.lblISBN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(47, 20);
            this.lblISBN.TabIndex = 11;
            this.lblISBN.Text = "ISBN";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(83, 70);
            this.lblNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(65, 20);
            this.lblNum.TabIndex = 10;
            this.lblNum.Text = "Numéro";
            // 
            // txtEditeur
            // 
            this.txtEditeur.Location = new System.Drawing.Point(212, 412);
            this.txtEditeur.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEditeur.Name = "txtEditeur";
            this.txtEditeur.Size = new System.Drawing.Size(148, 26);
            this.txtEditeur.TabIndex = 21;
            // 
            // lblEditeur
            // 
            this.lblEditeur.AutoSize = true;
            this.lblEditeur.Location = new System.Drawing.Point(83, 417);
            this.lblEditeur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEditeur.Name = "lblEditeur";
            this.lblEditeur.Size = new System.Drawing.Size(60, 20);
            this.lblEditeur.TabIndex = 20;
            this.lblEditeur.Text = "Editeur";
            // 
            // txtAnnee
            // 
            this.txtAnnee.Location = new System.Drawing.Point(212, 497);
            this.txtAnnee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAnnee.Name = "txtAnnee";
            this.txtAnnee.Size = new System.Drawing.Size(148, 26);
            this.txtAnnee.TabIndex = 23;
            // 
            // lblAnnee
            // 
            this.lblAnnee.AutoSize = true;
            this.lblAnnee.Location = new System.Drawing.Point(83, 502);
            this.lblAnnee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnnee.Name = "lblAnnee";
            this.lblAnnee.Size = new System.Drawing.Size(56, 20);
            this.lblAnnee.TabIndex = 22;
            this.lblAnnee.Text = "Année";
            // 
            // txtLangue
            // 
            this.txtLangue.Location = new System.Drawing.Point(212, 587);
            this.txtLangue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLangue.Name = "txtLangue";
            this.txtLangue.Size = new System.Drawing.Size(148, 26);
            this.txtLangue.TabIndex = 25;
            // 
            // lblLangue
            // 
            this.lblLangue.AutoSize = true;
            this.lblLangue.Location = new System.Drawing.Point(83, 592);
            this.lblLangue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLangue.Name = "lblLangue";
            this.lblLangue.Size = new System.Drawing.Size(63, 20);
            this.lblLangue.TabIndex = 24;
            this.lblLangue.Text = "Langue";
            // 
            // ficheLivre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 788);
            this.Controls.Add(this.txtLangue);
            this.Controls.Add(this.lblLangue);
            this.Controls.Add(this.txtAnnee);
            this.Controls.Add(this.lblAnnee);
            this.Controls.Add(this.txtEditeur);
            this.Controls.Add(this.lblEditeur);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblPrix);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblNum);
            this.Name = "ficheLivre";
            this.Text = "ficheLivre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtEditeur;
        private System.Windows.Forms.Label lblEditeur;
        private System.Windows.Forms.TextBox txtAnnee;
        private System.Windows.Forms.Label lblAnnee;
        private System.Windows.Forms.TextBox txtLangue;
        private System.Windows.Forms.Label lblLangue;
    }
}