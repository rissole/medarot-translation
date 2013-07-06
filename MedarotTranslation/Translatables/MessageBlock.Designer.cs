namespace MedarotTranslation.Translatables
{
	partial class MessageBlock
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
			this.txtJap = new System.Windows.Forms.TextBox();
			this.txtEng = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtJap
			// 
			this.txtJap.BackColor = System.Drawing.SystemColors.Control;
			this.txtJap.Font = new System.Drawing.Font("MS PGothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtJap.Location = new System.Drawing.Point(0, 0);
			this.txtJap.Multiline = true;
			this.txtJap.Name = "txtJap";
			this.txtJap.ReadOnly = true;
			this.txtJap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtJap.Size = new System.Drawing.Size(261, 75);
			this.txtJap.TabIndex = 0;
			this.txtJap.TabStop = false;
			this.txtJap.DoubleClick += new System.EventHandler(this.txtJap_DoubleClick);
			// 
			// txtEng
			// 
			this.txtEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEng.Location = new System.Drawing.Point(267, 0);
			this.txtEng.Multiline = true;
			this.txtEng.Name = "txtEng";
			this.txtEng.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEng.Size = new System.Drawing.Size(261, 75);
			this.txtEng.TabIndex = 1;
			this.txtEng.TextChanged += new System.EventHandler(this.txtEng_TextChanged);
			// 
			// MessageBlock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtEng);
			this.Controls.Add(this.txtJap);
			this.Name = "MessageBlock";
			this.Size = new System.Drawing.Size(529, 75);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtJap;
		private System.Windows.Forms.TextBox txtEng;
	}
}
