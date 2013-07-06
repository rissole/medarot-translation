using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedarotTranslation.Forms.JishEdit
{
	public partial class JishEdit : Form
	{
		private JishEntry lastEntry;

		public JishEdit()
		{
			InitializeComponent();
			lastEntry = null;
		}

		private void JishEdit_Load(object sender, EventArgs _e)
		{
			TranslationMemory.LoadFromFile();
			Dictionary<string, string>.Enumerator e = TranslationMemory.GetEnumerator();
			while (e.MoveNext())
			{
				AddEntry(e.Current.Key, e.Current.Value);
			}
		}

		public JishEntry AddEntry(string left, string right)
		{
			JishEntry ent = new JishEntry(this, left, right);
			if (lastEntry == null)
			{
				ent.Location = new Point(0, 0);
			}
			else
			{
				ent.Location = new Point(0, lastEntry.Location.Y + ent.Size.Height + 2);
			}
			lastEntry = ent;
			panel1.Controls.Add(ent);
			return ent;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			TranslationMemory.Clear();
			foreach (JishEntry je in panel1.Controls)
			{
				if (je.GetLeft() != "" && je.GetRight() != "")
					TranslationMemory.AddEntry(je.GetLeft(), je.GetRight());
			}
			TranslationMemory.WriteToFile();
		}

		public void RemoveEntry(JishEntry e)
		{
			panel1.Controls.Remove(e);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			panel1.ScrollControlIntoView(AddEntry("", ""));
		}

		private void JishEdit_SizeChanged(object sender, EventArgs e)
		{
			panel1.Height = this.Height - 83;
		}
	}
}
