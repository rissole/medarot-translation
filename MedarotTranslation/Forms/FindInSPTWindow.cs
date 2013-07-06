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
	public partial class FindInSPTWindow : Form
	{
		private SPTEditWindow parent;
		private int nextSearchIndex;

		private FindInSPTWindow(SPTEditWindow _parent)
		{
			InitializeComponent();
			parent = _parent;
			nextSearchIndex = 0;
		}

		public static void Open(SPTEditWindow _parent)
		{
			FindInSPTWindow w = new FindInSPTWindow(_parent);
			w.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_Find_Click(object sender, EventArgs e)
		{
			int oldSearchIndex = nextSearchIndex;
			if (oldSearchIndex - 1 >= 0)
			{
				Translatable t = (Translatable)parent.panel1.Controls[oldSearchIndex - 1];
				t.BackColor = SystemColors.Control;
			}
			for (int i = nextSearchIndex; i < parent.panel1.Controls.Count; ++i)
			{
				Translatable t = (Translatable)parent.panel1.Controls[i];
				if (t.JapText.ToLower().Contains(tbxText.Text.ToLower()) || t.EngText.ToLower().Contains(tbxText.Text.ToLower()))
				{
					t.BackColor = SystemColors.Highlight;
					parent.panel1.ScrollControlIntoView(t);
					nextSearchIndex = ++i;
					break;
				}
			}
			if (oldSearchIndex == nextSearchIndex)
			{
				MessageBox.Show("Reached end of SPT", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
				nextSearchIndex = 0;
			}
		}

		private void tbxText_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btn_Find_Click(null, null);
			else if (e.KeyCode == Keys.Escape)
				Close();
		}

		private void FindInSPTWindow_Load(object sender, EventArgs e)
		{
			tbxText.Focus();
		}
	}
}
