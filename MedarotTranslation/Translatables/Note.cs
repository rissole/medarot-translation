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
	public partial class Note : Translatable
	{
		public int ID
		{
			get;
			protected set;
		}

		public Note(string message, int id = -1) : base()
		{
			InitializeComponent();
			ID = id;
			JapText = message;
		}

		public override string JapText
		{
			get { return label1.Text; }
			set { label1.Text = value + ((ID != -1) ? " (Command " + ID + ")" : ""); }
		}

		public override string EngText
		{
			get { return label1.Text; }
			set { label1.Text = value + ((ID != -1) ? " (Command " + ID + ")" : ""); }
		}

		// base GetEnglishCommands
	}
}
