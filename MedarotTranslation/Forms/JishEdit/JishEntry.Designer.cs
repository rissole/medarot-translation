namespace MedarotTranslation.Forms.JishEdit
{
	partial class JishEntry
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
			this.tbxLeft = new System.Windows.Forms.TextBox();
			this.tbxRight = new System.Windows.Forms.TextBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbxLeft
			// 
			this.tbxLeft.Location = new System.Drawing.Point(0, 0);
			this.tbxLeft.Multiline = true;
			this.tbxLeft.Name = "tbxLeft";
			this.tbxLeft.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbxLeft.Size = new System.Drawing.Size(199, 39);
			this.tbxLeft.TabIndex = 0;
			// 
			// tbxRight
			// 
			this.tbxRight.Location = new System.Drawing.Point(205, 0);
			this.tbxRight.Multiline = true;
			this.tbxRight.Name = "tbxRight";
			this.tbxRight.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbxRight.Size = new System.Drawing.Size(199, 39);
			this.tbxRight.TabIndex = 1;
			// 
			// btnDelete
			// 
			this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.ForeColor = System.Drawing.Color.Red;
			this.btnDelete.Location = new System.Drawing.Point(406, 11);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(21, 18);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "X";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// JishEntry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.tbxRight);
			this.Controls.Add(this.tbxLeft);
			this.Name = "JishEntry";
			this.Size = new System.Drawing.Size(427, 39);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbxLeft;
		private System.Windows.Forms.TextBox tbxRight;
		private System.Windows.Forms.Button btnDelete;
	}
}
