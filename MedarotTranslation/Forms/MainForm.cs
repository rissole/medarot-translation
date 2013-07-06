using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedarotTranslation
{
	public partial class MainForm : Form
	{
		public static SPTEditWindow sptew = null;

		public MainForm()
		{
			InitializeComponent();
			//NewConsole.Init();
			Font10Converter.Init();
			TexBmpConv.Init();
		}

		private void btnHTCW_Click(object sender, EventArgs e)
		{
			(new HexTextConv()).Show();
		}

		private void btnSPTE_Click(object sender, EventArgs e)
		{
			if (object.ReferenceEquals(sptew, null) || sptew.IsDisposed)
				sptew = new SPTEditWindow();
			sptew.Show();
		}

		private void btnTBCW_Click(object sender, EventArgs e)
		{
			(new TexBmpConv()).Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NewConsole.Init();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!object.ReferenceEquals(sptew, null))
				sptew.Close();
			else
				return;

			if (!sptew.IsDisposed)
				e.Cancel = true;
		}

		private void btnJishE_Click(object sender, EventArgs e)
		{
			(new Forms.JishEdit.JishEdit()).Show();
		}
	}
}
