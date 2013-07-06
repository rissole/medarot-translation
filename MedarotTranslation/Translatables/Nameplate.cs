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
	public partial class Nameplate : Translatable
	{
		public Nameplate() : base()
		{
			InitializeComponent();
		}

		public override string JapText
		{
			get { return txtJap.Text; }
			set { txtJap.Text = value; }
		}

		public override string EngText
		{
			get { return txtEng.Text; }
			set { txtEng.Text = value; }
		}

		public override List<SPTCommand> GetEnglishCommands()
		{
			List<SPTCommand> ret = new List<SPTCommand>(commands.Capacity);
			string[] lines = EngText.Replace("\r\n", "\n").Split('\n');
			for (int i = 0; i < lines.Length; ++i)
			{
				if (lines[i].Length == 0)
					continue;
				SPTCommand n = new SPTCommand(commands[0].Block);
				n.PushArg(commands[0].GetArg(0)); n.PushArg(commands[0].GetArg(1));
				n.PushArg(Font10Converter.ReplaceOut(lines[i]));
				ret.Add(n);
			}
			return ret;
		}

		protected void txtEng_TextChanged(object sender, EventArgs e)
		{
			OnEditEvent(e);
		}

		public override List<KeyValuePair<string, string>> GetMemoryEntries()
		{
			List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
			if (EngText.Length > 0)
				ret.Add(new KeyValuePair<string,string>(JapText, EngText));
			return ret;
		}

		public override void UpdateFromMemory()
		{
			txtEng.Text = TranslationMemory.GetEntry(JapText);
		}
	}
}
