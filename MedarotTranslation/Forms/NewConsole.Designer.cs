namespace MedarotTranslation
{
	partial class NewConsole
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
			this.tbx = new System.Windows.Forms.TextBox();
			this.btnClr = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbx
			// 
			this.tbx.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbx.Location = new System.Drawing.Point(13, 13);
			this.tbx.Multiline = true;
			this.tbx.Name = "tbx";
			this.tbx.ReadOnly = true;
			this.tbx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbx.Size = new System.Drawing.Size(747, 254);
			this.tbx.TabIndex = 0;
			// 
			// btnClr
			// 
			this.btnClr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClr.Location = new System.Drawing.Point(766, 13);
			this.btnClr.Name = "btnClr";
			this.btnClr.Size = new System.Drawing.Size(20, 23);
			this.btnClr.TabIndex = 1;
			this.btnClr.Text = "c";
			this.btnClr.UseVisualStyleBackColor = true;
			this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
			// 
			// NewConsole
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 279);
			this.Controls.Add(this.btnClr);
			this.Controls.Add(this.tbx);
			this.Name = "NewConsole";
			this.Text = "NewConsole";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbx;
		private System.Windows.Forms.Button btnClr;
	}
}