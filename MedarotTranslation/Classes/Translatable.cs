using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedarotTranslation
{
	// size: 529 wide
	public class Translatable : UserControl
	{
		// japanese commands
		public List<SPTCommand> commands;

		protected Translatable()
		{
			commands = new List<SPTCommand>(3);
		}

		public virtual string JapText
		{
			get {return "";}
			set { return; }
		}

		public virtual string EngText
		{
			get { return ""; }
			set { return; }
		}

		// just return jap commands by default
		public virtual List<SPTCommand> GetEnglishCommands() { return commands; }

		public delegate void OnEdit(object sender, EventArgs e);
		public event OnEdit EditEvent;
		protected virtual void OnEditEvent(EventArgs e)
		{
			EditEvent(this, e);
		}

		public virtual List<KeyValuePair<string, string>> GetMemoryEntries() { return null; }
		public virtual void UpdateFromMemory() { }
	}
}
