namespace MedarotTranslation
{
	partial class SPTEditWindow
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
			this.components = new System.ComponentModel.Container();
			this.txtSPTPath = new System.Windows.Forms.TextBox();
			this.btnPrevSPT = new System.Windows.Forms.Button();
			this.btnNextSPT = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnOpenSPT = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnHelp = new System.Windows.Forms.Button();
			this.btn_find = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtSPTPath
			// 
			this.txtSPTPath.Location = new System.Drawing.Point(12, 14);
			this.txtSPTPath.Name = "txtSPTPath";
			this.txtSPTPath.ReadOnly = true;
			this.txtSPTPath.Size = new System.Drawing.Size(217, 20);
			this.txtSPTPath.TabIndex = 0;
			this.txtSPTPath.TabStop = false;
			// 
			// btnPrevSPT
			// 
			this.btnPrevSPT.Location = new System.Drawing.Point(298, 12);
			this.btnPrevSPT.Name = "btnPrevSPT";
			this.btnPrevSPT.Size = new System.Drawing.Size(25, 23);
			this.btnPrevSPT.TabIndex = 2;
			this.btnPrevSPT.Text = "<";
			this.toolTip1.SetToolTip(this.btnPrevSPT, "Load previous SPT");
			this.btnPrevSPT.UseVisualStyleBackColor = true;
			this.btnPrevSPT.Click += new System.EventHandler(this.btnPrevSPT_Click);
			// 
			// btnNextSPT
			// 
			this.btnNextSPT.Location = new System.Drawing.Point(329, 12);
			this.btnNextSPT.Name = "btnNextSPT";
			this.btnNextSPT.Size = new System.Drawing.Size(25, 23);
			this.btnNextSPT.TabIndex = 3;
			this.btnNextSPT.Text = ">";
			this.toolTip1.SetToolTip(this.btnNextSPT, "Load next SPT");
			this.btnNextSPT.UseVisualStyleBackColor = true;
			this.btnNextSPT.Click += new System.EventHandler(this.btnNextSPT_Click);
			// 
			// btnOpenSPT
			// 
			this.btnOpenSPT.Location = new System.Drawing.Point(235, 12);
			this.btnOpenSPT.Name = "btnOpenSPT";
			this.btnOpenSPT.Size = new System.Drawing.Size(57, 23);
			this.btnOpenSPT.TabIndex = 1;
			this.btnOpenSPT.Text = "Open";
			this.toolTip1.SetToolTip(this.btnOpenSPT, "Load an SPT file");
			this.btnOpenSPT.UseVisualStyleBackColor = true;
			this.btnOpenSPT.Click += new System.EventHandler(this.btnOpenSPT_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(493, 372);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Save";
			this.toolTip1.SetToolTip(this.btnSave, "Saves over current SPT with translated version.");
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Location = new System.Drawing.Point(13, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(555, 320);
			this.panel1.TabIndex = 4;
			this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 377);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "(Section sign § = Alt-0167)";
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatus.Location = new System.Drawing.Point(415, 17);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(153, 17);
			this.lblStatus.TabIndex = 7;
			this.lblStatus.Text = "status";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHelp.Location = new System.Drawing.Point(146, 372);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 8;
			this.btnHelp.Text = "More Help";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// btn_find
			// 
			this.btn_find.Location = new System.Drawing.Point(360, 12);
			this.btn_find.Name = "btn_find";
			this.btn_find.Size = new System.Drawing.Size(49, 23);
			this.btn_find.TabIndex = 9;
			this.btn_find.Text = "Find...";
			this.btn_find.UseVisualStyleBackColor = true;
			this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
			// 
			// SPTEditWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(583, 402);
			this.Controls.Add(this.btn_find);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnOpenSPT);
			this.Controls.Add(this.btnNextSPT);
			this.Controls.Add(this.btnPrevSPT);
			this.Controls.Add(this.txtSPTPath);
			this.KeyPreview = true;
			this.Name = "SPTEditWindow";
			this.Text = "Title";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SPTEditWindow_FormClosing);
			this.Load += new System.EventHandler(this.SPTEditWindow_Load);
			this.SizeChanged += new System.EventHandler(this.SPTEditWindow_SizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SPTEditWindow_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSPTPath;
		private System.Windows.Forms.Button btnPrevSPT;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnNextSPT;
		private System.Windows.Forms.Button btnOpenSPT;
		public System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.Button btn_find;


	}
}