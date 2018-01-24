namespace VumadoC
{
	partial class QuestionaireForm
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
			this.lectureLabel = new System.Windows.Forms.Label();
			this.lectureText = new System.Windows.Forms.TextBox();
			this.profLabel = new System.Windows.Forms.Label();
			this.profText = new System.Windows.Forms.TextBox();
			this.editButton = new System.Windows.Forms.Button();
			this.menu = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
			this.menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lectureLabel
			// 
			this.lectureLabel.AutoSize = true;
			this.lectureLabel.Location = new System.Drawing.Point(12, 25);
			this.lectureLabel.Name = "lectureLabel";
			this.lectureLabel.Size = new System.Drawing.Size(54, 13);
			this.lectureLabel.TabIndex = 100;
			this.lectureLabel.Text = "Vorlesung";
			// 
			// lectureText
			// 
			this.lectureText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lectureText.Location = new System.Drawing.Point(12, 41);
			this.lectureText.Name = "lectureText";
			this.lectureText.Size = new System.Drawing.Size(260, 20);
			this.lectureText.TabIndex = 1;
			this.lectureText.TextChanged += new System.EventHandler(this.lectureText_TextChanged);
			// 
			// profLabel
			// 
			this.profLabel.AutoSize = true;
			this.profLabel.Location = new System.Drawing.Point(12, 64);
			this.profLabel.Name = "profLabel";
			this.profLabel.Size = new System.Drawing.Size(51, 13);
			this.profLabel.TabIndex = 101;
			this.profLabel.Text = "Professor";
			// 
			// profText
			// 
			this.profText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.profText.Location = new System.Drawing.Point(12, 80);
			this.profText.Name = "profText";
			this.profText.Size = new System.Drawing.Size(260, 20);
			this.profText.TabIndex = 2;
			this.profText.TextChanged += new System.EventHandler(this.profText_TextChanged);
			// 
			// editButton
			// 
			this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.editButton.Location = new System.Drawing.Point(12, 115);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(260, 24);
			this.editButton.TabIndex = 5;
			this.editButton.Text = "Auswertung eintragen";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(284, 24);
			this.menu.TabIndex = 0;
			this.menu.Text = "menuStrip1";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.menuSave,
            this.menuSaveAs,
            this.menuExport,
            this.separator1,
            this.menuQuit});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(46, 20);
			this.menuFile.Text = "Datei";
			// 
			// menuNew
			// 
			this.menuNew.Name = "menuNew";
			this.menuNew.Size = new System.Drawing.Size(157, 22);
			this.menuNew.Text = "Neu";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuOpen
			// 
			this.menuOpen.Name = "menuOpen";
			this.menuOpen.Size = new System.Drawing.Size(157, 22);
			this.menuOpen.Text = "Öffnen";
			this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
			// 
			// menuSave
			// 
			this.menuSave.Name = "menuSave";
			this.menuSave.Size = new System.Drawing.Size(157, 22);
			this.menuSave.Text = "Speichern";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuSaveAs
			// 
			this.menuSaveAs.Name = "menuSaveAs";
			this.menuSaveAs.Size = new System.Drawing.Size(157, 22);
			this.menuSaveAs.Text = "Speichern unter";
			this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
			// 
			// menuExport
			// 
			this.menuExport.Name = "menuExport";
			this.menuExport.Size = new System.Drawing.Size(157, 22);
			this.menuExport.Text = "Exportieren";
			this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(154, 6);
			// 
			// menuQuit
			// 
			this.menuQuit.Name = "menuQuit";
			this.menuQuit.Size = new System.Drawing.Size(157, 22);
			this.menuQuit.Text = "Beenden";
			this.menuQuit.Click += new System.EventHandler(this.menuQuit_Click);
			// 
			// QuestionaireForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 151);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.profText);
			this.Controls.Add(this.profLabel);
			this.Controls.Add(this.lectureText);
			this.Controls.Add(this.lectureLabel);
			this.Controls.Add(this.menu);
			this.MainMenuStrip = this.menu;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 190);
			this.Name = "QuestionaireForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VumadoC";
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lectureLabel;
		private System.Windows.Forms.TextBox lectureText;
		private System.Windows.Forms.Label profLabel;
		private System.Windows.Forms.TextBox profText;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuNew;
		private System.Windows.Forms.ToolStripMenuItem menuOpen;
		private System.Windows.Forms.ToolStripMenuItem menuSave;
		private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
		private System.Windows.Forms.ToolStripMenuItem menuExport;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripMenuItem menuQuit;
	}
}

