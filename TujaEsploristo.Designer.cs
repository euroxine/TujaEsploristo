namespace TujaEsploristo
{
	partial class TujaEsploristo
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonEspdic = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.unToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.répertoireDesDonnésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.répertoireDesSauvegardesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.etimologio = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.Vortaroj = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.Difinoj = new System.Windows.Forms.Button();
			this.textBox_EnirejoVojo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_ElirejoVojo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.progressBar_Unikodigu = new System.Windows.Forms.ProgressBar();
			this.progressBar_Vortaroj = new System.Windows.Forms.ProgressBar();
			this.label8 = new System.Windows.Forms.Label();
			this.button_slosigu = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.Deŝlosiligu = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonEspdic
			// 
			this.buttonEspdic.BackColor = System.Drawing.Color.PaleGreen;
			this.buttonEspdic.Location = new System.Drawing.Point(231, 105);
			this.buttonEspdic.Name = "buttonEspdic";
			this.buttonEspdic.Size = new System.Drawing.Size(75, 23);
			this.buttonEspdic.TabIndex = 0;
			this.buttonEspdic.Text = "Espdic";
			this.buttonEspdic.UseVisualStyleBackColor = false;
			this.buttonEspdic.Click += new System.EventHandler(this.Espdic_Click);
			this.buttonEspdic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Espdic_MouseDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 110);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "1. Generu la vortaron de espdic";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(541, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// unToolStripMenuItem
			// 
			this.unToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.répertoireDesDonnésToolStripMenuItem,
            this.répertoireDesSauvegardesToolStripMenuItem});
			this.unToolStripMenuItem.Name = "unToolStripMenuItem";
			this.unToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.unToolStripMenuItem.Text = "Agordi";
			this.unToolStripMenuItem.Click += new System.EventHandler(this.unToolStripMenuItem_Click);
			// 
			// répertoireDesDonnésToolStripMenuItem
			// 
			this.répertoireDesDonnésToolStripMenuItem.Name = "répertoireDesDonnésToolStripMenuItem";
			this.répertoireDesDonnésToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.répertoireDesDonnésToolStripMenuItem.Text = "Enirejo ";
			// 
			// répertoireDesSauvegardesToolStripMenuItem
			// 
			this.répertoireDesSauvegardesToolStripMenuItem.Name = "répertoireDesSauvegardesToolStripMenuItem";
			this.répertoireDesSauvegardesToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.répertoireDesSauvegardesToolStripMenuItem.Text = "Elirejo";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.PaleGreen;
			this.button2.Location = new System.Drawing.Point(231, 161);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Unikodiĝi";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Unikodiĝi_Click);
			this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ansi2UTF8_MouseDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 166);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(155, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "3. Konvertu ĉiuj xml en unikodo";
			// 
			// etimologio
			// 
			this.etimologio.BackColor = System.Drawing.Color.PaleGreen;
			this.etimologio.Location = new System.Drawing.Point(231, 132);
			this.etimologio.Name = "etimologio";
			this.etimologio.Size = new System.Drawing.Size(75, 23);
			this.etimologio.TabIndex = 5;
			this.etimologio.Text = "Etimologio";
			this.etimologio.UseVisualStyleBackColor = false;
			this.etimologio.Click += new System.EventHandler(this.etimologio_Click);
			this.etimologio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.etimologio_MouseDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 137);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(174, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "2. Generu la vortaron de etimologioj";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 196);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(179, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "4. Generu la vortarojn por ĉiuj lingvoj";
			// 
			// Vortaroj
			// 
			this.Vortaroj.BackColor = System.Drawing.Color.PaleGreen;
			this.Vortaroj.Location = new System.Drawing.Point(231, 191);
			this.Vortaroj.Name = "Vortaroj";
			this.Vortaroj.Size = new System.Drawing.Size(75, 23);
			this.Vortaroj.TabIndex = 8;
			this.Vortaroj.Text = "Vortaroj";
			this.Vortaroj.UseVisualStyleBackColor = false;
			this.Vortaroj.Click += new System.EventHandler(this.Vortaroj_Click);
			this.Vortaroj.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Vortaroj_MouseDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 227);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(185, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "5. Generu la difinojn kaj la ekzemplojn";
			// 
			// Difinoj
			// 
			this.Difinoj.BackColor = System.Drawing.Color.PaleGreen;
			this.Difinoj.Location = new System.Drawing.Point(231, 222);
			this.Difinoj.Name = "Difinoj";
			this.Difinoj.Size = new System.Drawing.Size(75, 23);
			this.Difinoj.TabIndex = 10;
			this.Difinoj.Text = "Difinoj";
			this.Difinoj.UseVisualStyleBackColor = false;
			this.Difinoj.Click += new System.EventHandler(this.Difinoj_Click);
			this.Difinoj.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Difinoj_MouseDown);
			// 
			// textBox_EnirejoVojo
			// 
			this.textBox_EnirejoVojo.Location = new System.Drawing.Point(97, 27);
			this.textBox_EnirejoVojo.Name = "textBox_EnirejoVojo";
			this.textBox_EnirejoVojo.Size = new System.Drawing.Size(432, 20);
			this.textBox_EnirejoVojo.TabIndex = 11;
			this.textBox_EnirejoVojo.TextChanged += new System.EventHandler(this.textBox_EnirejoVojo_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Enirejo vojo";
			// 
			// textBox_ElirejoVojo
			// 
			this.textBox_ElirejoVojo.Location = new System.Drawing.Point(97, 54);
			this.textBox_ElirejoVojo.Name = "textBox_ElirejoVojo";
			this.textBox_ElirejoVojo.Size = new System.Drawing.Size(432, 20);
			this.textBox_ElirejoVojo.TabIndex = 13;
			this.textBox_ElirejoVojo.TextChanged += new System.EventHandler(this.textBox_ElirejoVojo_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 61);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 13);
			this.label7.TabIndex = 14;
			this.label7.Text = "Elirejo vojo";
			// 
			// progressBar_Unikodigu
			// 
			this.progressBar_Unikodigu.BackColor = System.Drawing.Color.LightGreen;
			this.progressBar_Unikodigu.Location = new System.Drawing.Point(311, 161);
			this.progressBar_Unikodigu.Name = "progressBar_Unikodigu";
			this.progressBar_Unikodigu.Size = new System.Drawing.Size(217, 23);
			this.progressBar_Unikodigu.TabIndex = 15;
			// 
			// progressBar_Vortaroj
			// 
			this.progressBar_Vortaroj.Location = new System.Drawing.Point(312, 191);
			this.progressBar_Vortaroj.Name = "progressBar_Vortaroj";
			this.progressBar_Vortaroj.Size = new System.Drawing.Size(216, 23);
			this.progressBar_Vortaroj.TabIndex = 16;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(15, 296);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(161, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "6. Ŝlosiligu la espdic en la franca";
			// 
			// button_slosigu
			// 
			this.button_slosigu.BackColor = System.Drawing.Color.PaleGreen;
			this.button_slosigu.Location = new System.Drawing.Point(231, 291);
			this.button_slosigu.Name = "button_slosigu";
			this.button_slosigu.Size = new System.Drawing.Size(75, 23);
			this.button_slosigu.TabIndex = 18;
			this.button_slosigu.Text = "Ŝlosiligu";
			this.button_slosigu.UseVisualStyleBackColor = false;
			this.button_slosigu.Click += new System.EventHandler(this.button_ŝlosiligu_Click);
			this.button_slosigu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Slosigu_MouseDown);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(15, 326);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(147, 13);
			this.label9.TabIndex = 19;
			this.label9.Text = "7. Deŝlosiligu la franca espdic";
			// 
			// Deŝlosiligu
			// 
			this.Deŝlosiligu.BackColor = System.Drawing.Color.PaleGreen;
			this.Deŝlosiligu.Location = new System.Drawing.Point(231, 321);
			this.Deŝlosiligu.Name = "Deŝlosiligu";
			this.Deŝlosiligu.Size = new System.Drawing.Size(75, 23);
			this.Deŝlosiligu.TabIndex = 20;
			this.Deŝlosiligu.Text = "Deŝlosiligu";
			this.Deŝlosiligu.UseVisualStyleBackColor = false;
			this.Deŝlosiligu.Click += new System.EventHandler(this.Deŝlosiligu_Click);
			this.Deŝlosiligu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Deŝlosiligu_MouseDown);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.PaleTurquoise;
			this.label10.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(15, 264);
			this.label10.Margin = new System.Windows.Forms.Padding(3);
			this.label10.Name = "label10";
			this.label10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.label10.Size = new System.Drawing.Size(470, 18);
			this.label10.TabIndex = 21;
			this.label10.Text = "tuja-dosiero/slosiloj/eo_fr.txt + eo_fr_slosilo_eo.txt => tuja-dosiero/eo_fr_adic" +
    "igi.js";
			// 
			// TujaEsploristo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MediumAquamarine;
			this.ClientSize = new System.Drawing.Size(541, 366);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.Deŝlosiligu);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.button_slosigu);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.progressBar_Vortaroj);
			this.Controls.Add(this.progressBar_Unikodigu);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox_ElirejoVojo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox_EnirejoVojo);
			this.Controls.Add(this.Difinoj);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.Vortaroj);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.etimologio);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonEspdic);
			this.Controls.Add(this.menuStrip1);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TujaEsploristo";
			this.Text = "Tuja Esploristo (Json-konvertilo)";
			this.Load += new System.EventHandler(this.TujaEsploristo_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonEspdic;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem unToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem répertoireDesDonnésToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem répertoireDesSauvegardesToolStripMenuItem;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button etimologio;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button Vortaroj;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button Difinoj;
		private System.Windows.Forms.TextBox textBox_EnirejoVojo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_ElirejoVojo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ProgressBar progressBar_Unikodigu;
		private System.Windows.Forms.ProgressBar progressBar_Vortaroj;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button_slosigu;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button Deŝlosiligu;
		private System.Windows.Forms.Label label10;
	}
}

