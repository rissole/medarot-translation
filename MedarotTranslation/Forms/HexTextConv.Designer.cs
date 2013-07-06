namespace MedarotTranslation
{
	partial class HexTextConv
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtText = new System.Windows.Forms.TextBox();
			this.txtHex = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnT2H = new System.Windows.Forms.Button();
			this.btnH2T = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Text";
			// 
			// txtText
			// 
			this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtText.Location = new System.Drawing.Point(16, 30);
			this.txtText.Multiline = true;
			this.txtText.Name = "txtText";
			this.txtText.Size = new System.Drawing.Size(414, 118);
			this.txtText.TabIndex = 1;
			// 
			// txtHex
			// 
			this.txtHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHex.Location = new System.Drawing.Point(12, 185);
			this.txtHex.Multiline = true;
			this.txtHex.Name = "txtHex";
			this.txtHex.Size = new System.Drawing.Size(414, 105);
			this.txtHex.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 166);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Hex";
			// 
			// btnT2H
			// 
			this.btnT2H.Location = new System.Drawing.Point(351, 299);
			this.btnT2H.Name = "btnT2H";
			this.btnT2H.Size = new System.Drawing.Size(75, 23);
			this.btnT2H.TabIndex = 4;
			this.btnT2H.Text = "Text to Hex";
			this.btnT2H.UseVisualStyleBackColor = true;
			this.btnT2H.Click += new System.EventHandler(this.btnT2H_Click);
			// 
			// btnH2T
			// 
			this.btnH2T.Location = new System.Drawing.Point(270, 299);
			this.btnH2T.Name = "btnH2T";
			this.btnH2T.Size = new System.Drawing.Size(75, 23);
			this.btnH2T.TabIndex = 5;
			this.btnH2T.Text = "Hex To Text";
			this.btnH2T.UseVisualStyleBackColor = true;
			this.btnH2T.Click += new System.EventHandler(this.btnH2T_Click);
			// 
			// HexTextConv
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(442, 331);
			this.Controls.Add(this.btnH2T);
			this.Controls.Add(this.btnT2H);
			this.Controls.Add(this.txtHex);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtText);
			this.Controls.Add(this.label1);
			this.Name = "HexTextConv";
			this.Text = "Medarot Translation";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtText;
		private System.Windows.Forms.TextBox txtHex;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnT2H;
		private System.Windows.Forms.Button btnH2T;
	}
}

