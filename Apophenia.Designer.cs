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
			this.grpDeck = new System.Windows.Forms.GroupBox();
			this.pbxDeck = new System.Windows.Forms.PictureBox();
			this.cmbDeckSelect = new System.Windows.Forms.ComboBox();
			this.btnDeal = new System.Windows.Forms.Button();
			this.grpInstructions = new System.Windows.Forms.GroupBox();
			this.grpInterpretation = new System.Windows.Forms.GroupBox();
			this.lblInterpretation = new System.Windows.Forms.Label();
			this.pbxZoom = new System.Windows.Forms.PictureBox();
			this.grpZoom = new System.Windows.Forms.GroupBox();
			this.grpDeck.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).BeginInit();
			this.grpInstructions.SuspendLayout();
			this.grpInterpretation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxZoom)).BeginInit();
			this.grpZoom.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblInstructions
			// 
			this.lblInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblInstructions.Location = new System.Drawing.Point(3, 16);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new System.Drawing.Size(421, 69);
			this.lblInstructions.TabIndex = 0;
			this.lblInstructions.Text = "Drag cards from the deck to create a spread.\r\nRight-click a card to rotate it 90 " +
    "degrees clockwise.\r\nDouble-click a card to reveal it.\r\nClick a card to embiggen " +
    "it.";
			// 
			// grpDeck
			// 
			this.grpDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpDeck.AutoSize = true;
			this.grpDeck.Controls.Add(this.pbxDeck);
			this.grpDeck.Controls.Add(this.cmbDeckSelect);
			this.grpDeck.Controls.Add(this.btnDeal);
			this.grpDeck.Location = new System.Drawing.Point(12, 350);
			this.grpDeck.Name = "grpDeck";
			this.grpDeck.Size = new System.Drawing.Size(106, 200);
			this.grpDeck.TabIndex = 0;
			this.grpDeck.TabStop = false;
			this.grpDeck.Text = "Deck";
			// 
			// pbxDeck
			// 
			this.pbxDeck.Dock = System.Windows.Forms.DockStyle.Top;
			this.pbxDeck.Location = new System.Drawing.Point(3, 16);
			this.pbxDeck.Name = "pbxDeck";
			this.pbxDeck.Size = new System.Drawing.Size(100, 137);
			this.pbxDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbxDeck.TabIndex = 1;
			this.pbxDeck.TabStop = false;
			this.pbxDeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxDeck_MouseDown);
			// 
			// cmbDeckSelect
			// 
			this.cmbDeckSelect.DisplayMember = "Name";
			this.cmbDeckSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cmbDeckSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDeckSelect.Location = new System.Drawing.Point(3, 153);
			this.cmbDeckSelect.Name = "cmbDeckSelect";
			this.cmbDeckSelect.Size = new System.Drawing.Size(100, 21);
			this.cmbDeckSelect.TabIndex = 2;
			this.cmbDeckSelect.ValueMember = "Name";
			this.cmbDeckSelect.SelectedIndexChanged += new System.EventHandler(this.cmbDeckSelect_SelectedIndexChanged);
			// 
			// btnDeal
			// 
			this.btnDeal.AutoSize = true;
			this.btnDeal.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnDeal.Location = new System.Drawing.Point(3, 174);
			this.btnDeal.Name = "btnDeal";
			this.btnDeal.Size = new System.Drawing.Size(100, 23);
			this.btnDeal.TabIndex = 3;
			this.btnDeal.Text = "Clear Cards";
			this.btnDeal.UseVisualStyleBackColor = true;
			this.btnDeal.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// grpInstructions
			// 
			this.grpInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpInstructions.AutoSize = true;
			this.grpInstructions.Controls.Add(this.lblInstructions);
			this.grpInstructions.Location = new System.Drawing.Point(124, 462);
			this.grpInstructions.Name = "grpInstructions";
			this.grpInstructions.Size = new System.Drawing.Size(427, 88);
			this.grpInstructions.TabIndex = 3;
			this.grpInstructions.TabStop = false;
			this.grpInstructions.Text = "Instructions";
			// 
			// grpInterpretation
			// 
			this.grpInterpretation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpInterpretation.AutoSize = true;
			this.grpInterpretation.Controls.Add(this.lblInterpretation);
			this.grpInterpretation.Location = new System.Drawing.Point(124, 350);
			this.grpInterpretation.Name = "grpInterpretation";
			this.grpInterpretation.Size = new System.Drawing.Size(427, 106);
			this.grpInterpretation.TabIndex = 4;
			this.grpInterpretation.TabStop = false;
			this.grpInterpretation.Text = "Interpretation";
			// 
			// lblInterpretation
			// 
			this.lblInterpretation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblInterpretation.Location = new System.Drawing.Point(3, 16);
			this.lblInterpretation.Name = "lblInterpretation";
			this.lblInterpretation.Size = new System.Drawing.Size(421, 87);
			this.lblInterpretation.TabIndex = 0;
			// 
			// pbxZoom
			// 
			this.pbxZoom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbxZoom.Location = new System.Drawing.Point(3, 16);
			this.pbxZoom.Name = "pbxZoom";
			this.pbxZoom.Size = new System.Drawing.Size(209, 308);
			this.pbxZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbxZoom.TabIndex = 5;
			this.pbxZoom.TabStop = false;
			// 
			// grpZoom
			// 
			this.grpZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.grpZoom.AutoSize = true;
			this.grpZoom.Controls.Add(this.pbxZoom);
			this.grpZoom.Location = new System.Drawing.Point(557, 223);
			this.grpZoom.Name = "grpZoom";
			this.grpZoom.Size = new System.Drawing.Size(215, 327);
			this.grpZoom.TabIndex = 6;
			this.grpZoom.TabStop = false;
			this.grpZoom.Text = "Zoom";
			// 
			// Apophenia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.grpZoom);
			this.Controls.Add(this.grpInterpretation);
			this.Controls.Add(this.grpInstructions);
			this.Controls.Add(this.grpDeck);
			this.Name = "Apophenia";
			this.Text = "Apophenia";
			this.grpDeck.ResumeLayout(false);
			this.grpDeck.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).EndInit();
			this.grpInstructions.ResumeLayout(false);
			this.grpInterpretation.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbxZoom)).EndInit();
			this.grpZoom.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblInstructions;
		private System.Windows.Forms.GroupBox grpDeck;
		private System.Windows.Forms.GroupBox grpInstructions;
		private System.Windows.Forms.GroupBox grpInterpretation;
		private System.Windows.Forms.Label lblInterpretation;
		private System.Windows.Forms.PictureBox pbxZoom;
		private System.Windows.Forms.PictureBox pbxDeck;
		private System.Windows.Forms.ComboBox cmbDeckSelect;
		private System.Windows.Forms.Button btnDeal;
		private System.Windows.Forms.GroupBox grpZoom;
	}
}
