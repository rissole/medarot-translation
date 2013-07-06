using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedarotTranslation.Forms.JishEdit
{
	public partial class JishEntry : UserControl
	{
		private JishEdit parent;

		public JishEntry(JishEdit par, string left, string right)
		{
			InitializeComponent();
			parent = par;
			tbxLeft.Text = left;
			tbxRight.Text = right;
		}

		public string GetLeft() { return tbxLeft.Text; }
		public string GetRight() { return tbxRight.Text; }

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete this entry?", "Remove entry confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				parent.RemoveEntry(this);
				Dispose();
			}
		}
	}
}
