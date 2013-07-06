namespace MedarotTranslation
{
	partial class FindInSPTWindow
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
			this.tbxText = new System.Windows.Forms.TextBox();
			this.btn_Find = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbxText
			// 
			this.tbxText.Location = new System.Drawing.Point(12, 12);
			this.tbxText.Name = "tbxText";
			this.tbxText.Size = new System.Drawing.Size(181, 20);
			this.tbxText.TabIndex = 0;
			this.tbxText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxText_KeyDown);
			// 
			// btn_Find
			// 
			this.btn_Find.Location = new System.Drawing.Point(118, 38);
			this.btn_Find.Name = "btn_Find";
			this.btn_Find.Size = new System.Drawing.Size(75, 23);
			this.btn_Find.TabIndex = 1;
			this.btn_Find.Text = "Find";
			this.btn_Find.UseVisualStyleBackColor = true;
			this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(37, 38);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// FindInSPTWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(206, 70);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btn_Find);
			this.Controls.Add(this.tbxText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FindInSPTWindow";
			this.Text = "Find...";
			this.Load += new System.EventHandler(this.FindInSPTWindow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbxText;
		private System.Windows.Forms.Button btn_Find;
		private System.Windows.Forms.Button button2;
	}
}