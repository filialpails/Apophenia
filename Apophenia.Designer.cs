namespace Apophenia
{
	partial class Apophenia
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
			this.lblInstructions = new System.Windows.Forms.Label();
			this.pbxDeck = new System.Windows.Forms.PictureBox();
			this.grpBox = new System.Windows.Forms.GroupBox();
			this.btnDeal = new System.Windows.Forms.Button();
			this.cmbDeckSelect = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).BeginInit();
			this.grpBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.lblInstructions.AutoSize = true;
			this.lblInstructions.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Text = "Drag cards from the deck to create a spread.\nRight-click a card to rotate it 90 degrees clockwise.\nDouble-click a card to reveal it.\nUse the mouse wheel to zoom.";
			// 
			// pictureBox1
			// 
			this.pbxDeck.AutoSize = true;
			this.pbxDeck.Name = "pbxDeck";
			this.pbxDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbxDeck.Dock = System.Windows.Forms.DockStyle.Right;
			this.pbxDeck.Size = new System.Drawing.Size(100, 150);
			this.pbxDeck.MouseDown += this.pbxDeck_MouseDown;
			// 
			// button1
			// 
			this.btnDeal.Name = "btnDeal";
			this.btnDeal.Text = "Clear dealt cards";
			this.btnDeal.UseVisualStyleBackColor = true;
			this.btnDeal.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnDeal.AutoSize = true;
			this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
			//
			// cmbDeckSelect
			//
			this.cmbDeckSelect.AutoSize = true;
			this.cmbDeckSelect.Name = "cmbDeckSelect";
			this.cmbDeckSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cmbDeckSelect.SelectedIndexChanged += this.cmbDeckSelect_SelectedIndexChanged;
			// 
			// groupBox1
			// 
			this.grpBox.Controls.Add(this.lblInstructions);
			this.grpBox.Controls.Add(this.pbxDeck);
			this.grpBox.Controls.Add(this.cmbDeckSelect);
			this.grpBox.Controls.Add(this.btnDeal);
			this.grpBox.Name = "grpBox";
			this.grpBox.Text = "Aprophenia: the perception of or belief in connectedness among unrelated phenomena.";
			//this.grpBox.AutoSize = true;
			this.grpBox.Height = 200;
			this.grpBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// Apophenia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(612, 612);
			this.Controls.Add(this.grpBox);
			this.Name = "Apophenia";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Apophenia";
			((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).EndInit();
			this.grpBox.ResumeLayout(false);
			this.grpBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label lblInstructions;
		private System.Windows.Forms.PictureBox pbxDeck;
		private System.Windows.Forms.GroupBox grpBox;
		private System.Windows.Forms.Button btnDeal;
		private System.Windows.Forms.ComboBox cmbDeckSelect;
	}
}
