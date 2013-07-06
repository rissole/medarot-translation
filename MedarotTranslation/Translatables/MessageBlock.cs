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
	public partial class MessageBlock : Translatable
	{
		private bool jishable;
		public MessageBlock() : base()
		{
			jishable = false;
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

		public static int LastIndexBefore(string s, char c, int maxIdx)
		{
			if (maxIdx > s.Length)
				maxIdx = s.Length;
			for (int i = maxIdx; i >= 0;--i)
			{
				if (s[i] == c)
					return i;
			}
			return -1;
		}

		public override List<SPTCommand> GetEnglishCommands()
		{
			List<SPTCommand> ret = new List<SPTCommand>(commands.Capacity);

			// by default every new line in english text box is new line in game
			List<string> lines = new List<string>(EngText.Replace("\r\n", "\n").Split('\n'));

			for (int i = 0; i < lines.Count; ++i)
			{
				SPTCommand n;
				if (lines[i].Length == 0)
					continue;

				string full = lines[i].Replace("§S0§", "ＡＡＡＡＡＡＡＡ").Replace("§S1§", "XMXMX").Replace("§S2§", "ＢＢＢＢＢＢＢＢ");
				int idx = NFTR.GetIndexWhereWidthExceeds(TexBmpConv.font, full, 230, true);
				if (idx < full.Length)
				{
					int lastSpace = LastIndexBefore(full, ' ', idx);
					string newL1 = full.Substring(0, lastSpace).Replace("ＡＡＡＡＡＡＡＡ", "§S0§").Replace("XMXMX", "§S1§").Replace("ＢＢＢＢＢＢＢＢ", "§S2§");
					string newL2 = "";
					if (lastSpace + 1 < full.Length)
						newL2 = full.Substring(lastSpace + 1).Replace("ＡＡＡＡＡＡＡＡ", "§S0§").Replace("XMXMX", "§S1§").Replace("ＢＢＢＢＢＢＢＢ", "§S2§");
					lines[i] = newL1;
					if (newL2.Length > 0)
					{
						int colidx = newL1.LastIndexOf("<c:");
						if (colidx > 0 && newL1.LastIndexOf("<c>") < colidx)
						{
							newL2 = newL2.Insert(0, newL1.Substring(colidx, 10)); 
						}
						lines.Insert(i + 1, newL2);
					}
				}
				else if (lines[i].Equals("KEY_WAIT"))
				{
					n = new SPTCommand(commands[0].Block);
					n.PushArg("gosub"); n.PushArg("KEY_WAIT");
					ret.Add(n);
					continue;
				}

				n = new SPTCommand(commands[0].Block);
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
			if (jishable)
			{
				List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
				if (EngText.Length > 0)
					ret.Add(new KeyValuePair<string, string>(JapText, EngText));
				return ret;
			}
			else
				return base.GetMemoryEntries();
		}

		public override void UpdateFromMemory()
		{
			string s = TranslationMemory.GetEntry(JapText);
			if (s.Length > 0)
				txtEng.Text = TranslationMemory.GetEntry(JapText);
		}

		private void txtJap_DoubleClick(object sender, EventArgs e)
		{
			jishable = true;
			txtJap.BackColor = SystemColors.GradientInactiveCaption;
		}
	}
}
