namespace MedarotTranslation
{
	partial class TexBmpConv
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnFont = new System.Windows.Forms.Button();
			this.txtGetFont = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(94, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(404, 285);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(13, 13);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 23);
			this.btnLoad.TabIndex = 1;
			this.btnLoad.Text = "Load TEX";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// btnFont
			// 
			this.btnFont.Location = new System.Drawing.Point(13, 231);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(75, 36);
			this.btnFont.TabIndex = 2;
			this.btnFont.Text = "Get font char";
			this.btnFont.UseVisualStyleBackColor = true;
			this.btnFont.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtGetFont
			// 
			this.txtGetFont.Location = new System.Drawing.Point(13, 273);
			this.txtGetFont.Name = "txtGetFont";
			this.txtGetFont.Size = new System.Drawing.Size(74, 20);
			this.txtGetFont.TabIndex = 4;
			this.txtGetFont.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGetFont_KeyPress);
			// 
			// TexBmpConv
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 309);
			this.Controls.Add(this.txtGetFont);
			this.Controls.Add(this.btnFont);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.pictureBox1);
			this.Name = "TexBmpConv";
			this.Text = "TexBmpConv";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnFont;
		private System.Windows.Forms.TextBox txtGetFont;
	}
}