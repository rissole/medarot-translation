namespace MedarotTranslation.Translatables
{
	partial class Nameplate
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtEng = new System.Windows.Forms.TextBox();
			this.txtJap = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtEng
			// 
			this.txtEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEng.Location = new System.Drawing.Point(267, 8);
			this.txtEng.Multiline = true;
			this.txtEng.Name = "txtEng";
			this.txtEng.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEng.Size = new System.Drawing.Size(261, 31);
			this.txtEng.TabIndex = 0;
			this.txtEng.TextChanged += new System.EventHandler(this.txtEng_TextChanged);
			// 
			// txtJap
			// 
			this.txtJap.Font = new System.Drawing.Font("MS PGothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtJap.Location = new System.Drawing.Point(0, 8);
			this.txtJap.Multiline = true;
			this.txtJap.Name = "txtJap";
			this.txtJap.ReadOnly = true;
			this.txtJap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtJap.Size = new System.Drawing.Size(261, 31);
			this.txtJap.TabIndex = 2;
			this.txtJap.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label1.Location = new System.Drawing.Point(-1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 7);
			this.label1.TabIndex = 4;
			this.label1.Text = "NAMEPLATE SET";
			// 
			// Nameplate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtEng);
			this.Controls.Add(this.txtJap);
			this.Name = "Nameplate";
			this.Size = new System.Drawing.Size(529, 40);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtEng;
		private System.Windows.Forms.TextBox txtJap;
		private System.Windows.Forms.Label label1;
	}
}
