namespace MedarotTranslation
{
	partial class MainForm
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
			this.btnSPTE = new System.Windows.Forms.Button();
			this.btnTBCW = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnJishE = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSPTE
			// 
			this.btnSPTE.Location = new System.Drawing.Point(93, 12);
			this.btnSPTE.Name = "btnSPTE";
			this.btnSPTE.Size = new System.Drawing.Size(75, 41);
			this.btnSPTE.TabIndex = 1;
			this.btnSPTE.Text = "SPTEdit";
			this.btnSPTE.UseVisualStyleBackColor = true;
			this.btnSPTE.Click += new System.EventHandler(this.btnSPTE_Click);
			// 
			// btnTBCW
			// 
			this.btnTBCW.Location = new System.Drawing.Point(174, 12);
			this.btnTBCW.Name = "btnTBCW";
			this.btnTBCW.Size = new System.Drawing.Size(75, 41);
			this.btnTBCW.TabIndex = 2;
			this.btnTBCW.Text = "TEX + Font Tools";
			this.btnTBCW.UseVisualStyleBackColor = true;
			this.btnTBCW.Click += new System.EventHandler(this.btnTBCW_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 59);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(237, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Show console";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnJishE
			// 
			this.btnJishE.Location = new System.Drawing.Point(12, 12);
			this.btnJishE.Name = "btnJishE";
			this.btnJishE.Size = new System.Drawing.Size(75, 41);
			this.btnJishE.TabIndex = 4;
			this.btnJishE.Text = "Dictionary Editor";
			this.btnJishE.UseVisualStyleBackColor = true;
			this.btnJishE.Click += new System.EventHandler(this.btnJishE_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(262, 90);
			this.Controls.Add(this.btnJishE);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnTBCW);
			this.Controls.Add(this.btnSPTE);
			this.Name = "MainForm";
			this.Text = "MedaTools Beta";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSPTE;
		private System.Windows.Forms.Button btnTBCW;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnJishE;
	}
}