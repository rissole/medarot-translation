using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedarotTranslation.Translatables
{
	public class GenericTArgOpts
	{
		public int idx;
		public bool memoryStore;

		public GenericTArgOpts(int i, bool memstore)
		{
			idx = i;
			memoryStore = memstore;
		}

		public static explicit operator GenericTArgOpts(int i)
		{
			return new GenericTArgOpts(i, false);
		}

		public override bool Equals(object obj)
		{
			GenericTArgOpts other = obj as GenericTArgOpts;
			if (other != null)
			{
				return (idx == other.idx);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	public partial class GenericTranslatable : Translatable
	{
		private List<TextBox> japs;
		private List<TextBox> engs;
		private List<GenericTArgOpts> commandArgs;

		public GenericTranslatable(SPTCommand c) : base()
		{
			InitializeComponent();
			commands.Add(c);
			japs = new List<TextBox>();
			engs = new List<TextBox>();
			commandArgs = new List<GenericTArgOpts>();
		}

		public void AddArg(GenericTArgOpts arg)
		{
			if (commandArgs.Count > 0 && arg.idx < commandArgs[commandArgs.Count - 1].idx)
				throw new Exception("Can't add args out of order.");
			commandArgs.Add(arg);
			string japtext = commands[0].GetArg(arg.idx);
			AddRow((int)Math.Ceiling((double)japtext.Length / 24), japtext);
		}

		private void AddRow(int textrows, string japtext)
		{
			TextBox txtEng = new TextBox();
			TextBox txtJap = new TextBox();

			// 
			// txtEng
			// 
			txtEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			txtEng.Location = new System.Drawing.Point(267, (engs.Count > 0 ? engs[engs.Count-1].Location.Y + engs[engs.Count-1].Size.Height + 2 : 2));
			txtEng.Multiline = true;
			txtEng.Name = "txtEng" + engs.Count;
			txtEng.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtEng.Size = new System.Drawing.Size(261, 31 * textrows);
			txtEng.TextChanged += new EventHandler(txtEng_TextChanged);
			txtEng.TabIndex = engs.Count;
			// 
			// txtJap
			// 
			txtJap.Font = new System.Drawing.Font("MS PGothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			txtJap.Location = new System.Drawing.Point(0, (japs.Count > 0 ? japs[japs.Count - 1].Location.Y + japs[japs.Count - 1].Size.Height + 2 : 2));
			txtJap.Multiline = true;
			txtJap.Name = "txtJap" + japs.Count;
			txtJap.ReadOnly = true;
			txtJap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtJap.Size = new System.Drawing.Size(261, 31 * textrows);
			txtJap.TabIndex = 0;
			txtJap.TabStop = false;
			txtJap.Text = japtext;

			this.Controls.Add(txtEng);
			this.Controls.Add(txtJap);
			engs.Add(txtEng);
			japs.Add(txtJap);
			this.Size = new Size(528, txtJap.Location.Y + txtJap.Size.Height + 1);
		}

		public override string JapText
		{
			get
			{
				string ret = "";
				for (int i = 0; i < japs.Count; ++i)
				{
					ret += japs[i] + "\n";
				}
				return ret;
			}
		}

		public override string EngText
		{
			get
			{
				string ret = "";
				for (int i = 0; i < engs.Count; ++i)
				{
					ret += engs[i] + "\n";
				}
				return ret;
			}
		}

		protected void txtEng_TextChanged(object sender, EventArgs e)
		{
			OnEditEvent(e);
		}

		public override List<SPTCommand> GetEnglishCommands()
		{
			List<SPTCommand> ret = new List<SPTCommand>(1);
			SPTCommand c = new SPTCommand(commands[0].Block);
			for (int i = 0; i < commands[0].ArgCount; ++i)
			{
				int idx = commandArgs.IndexOf((GenericTArgOpts)i);
				if (idx >= 0 && engs[idx].Text.Length > 0)
					c.PushArg(Font10Converter.ReplaceOut(engs[idx].Text));
				else
					c.PushArg(commands[0].GetArg(i));
			}
			ret.Add(c);
			return ret;
		}

		public override List<KeyValuePair<string, string>> GetMemoryEntries()
		{
			List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
			foreach (GenericTArgOpts arg in commandArgs)
			{
				if (arg.memoryStore)
				{
					int idx = commandArgs.IndexOf(arg);
					if (engs[idx].Text.Length > 0)
						ret.Add(new KeyValuePair<string, string>(japs[idx].Text, engs[idx].Text));
				}
			}
			return ret;
		}

		public override void UpdateFromMemory()
		{
			foreach (GenericTArgOpts arg in commandArgs)
			{
				if (arg.memoryStore)
				{
					int idx = commandArgs.IndexOf(arg);
					engs[idx].Text = TranslationMemory.GetEntry(japs[idx].Text);
				}
			}
		}
	}
}
