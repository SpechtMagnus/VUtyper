namespace VumadoC
{
	partial class AnswersForm
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
			this.prevButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.indexlabel = new System.Windows.Forms.Label();
			this.answersLayout = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// prevButton
			// 
			this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.prevButton.Location = new System.Drawing.Point(12, 232);
			this.prevButton.Name = "prevButton";
			this.prevButton.Size = new System.Drawing.Size(90, 30);
			this.prevButton.TabIndex = 2;
			this.prevButton.Text = "Previous";
			this.prevButton.UseVisualStyleBackColor = true;
			this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(325, 232);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(90, 30);
			this.nextButton.TabIndex = 1;
			this.nextButton.Text = "Next";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// indexlabel
			// 
			this.indexlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.indexlabel.Location = new System.Drawing.Point(108, 232);
			this.indexlabel.Name = "indexlabel";
			this.indexlabel.Size = new System.Drawing.Size(211, 30);
			this.indexlabel.TabIndex = 3;
			this.indexlabel.Text = "1/1";
			this.indexlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// answersLayout
			// 
			this.answersLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.answersLayout.AutoScroll = true;
			this.answersLayout.Location = new System.Drawing.Point(0, 0);
			this.answersLayout.Name = "answersLayout";
			this.answersLayout.Padding = new System.Windows.Forms.Padding(12);
			this.answersLayout.Size = new System.Drawing.Size(425, 227);
			this.answersLayout.TabIndex = 4;
			this.answersLayout.MouseEnter += new System.EventHandler(this.answersLayout_MouseEnter);
			// 
			// AnswersForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(427, 274);
			this.Controls.Add(this.answersLayout);
			this.Controls.Add(this.indexlabel);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.prevButton);
			this.MinimumSize = new System.Drawing.Size(260, 150);
			this.Name = "AnswersForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AnswersForm";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button prevButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Label indexlabel;
		private System.Windows.Forms.Panel answersLayout;
	}
}