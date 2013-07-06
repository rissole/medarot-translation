using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MedarotTranslation.Translatables;

namespace MedarotTranslation
{
	public partial class SPTEditWindow : Form
	{
		private string[] titles = { "Do the Honyaku", "しゅっぱつ、右腕パーツ", "ウィルスじゃない", "Virus Email.exe", "月に行ったことある",
								  "Plugged a volcano with his butt.", "おっと…", "Belzelga.exe", "Medawatch.exe",
								  "SHOOT action MISSILE", "かならず HIT", "けんきゅうじょ", "Translator アップリー", "はっきりかぶとになる",
								  "Try opening it in Notepad++", "As referenced in my Linguistics Thesis",
								  "virus_mail_sender.exe", "Paid for by your mother's grocery money.", "Function ceased, winner is you",
								  "Mr. Referee approved", "Multicolour (you read it in Scottish)", "Now with Translation Memory!",
								  "Last compiled 21-3-2033", "Dat interface", "arf arf" };

		private BinaryReader sptReader;
		private Translatable lastElement;
		private FileStream sptFile;
		//private List<SPTCommand> fileCommands;
		private SPTBlock root;
		private Stack<SPTBlock> blockHierarchy;
		private string[] sptDirectory;
		private int sptDirCurrentIdx;

		// !!USE THE PROPERTY NOT THIS!! //
		private bool _edited;
		private bool Edited
		{
			set
			{
				if (_edited == false && value == true)
				{
					this.Text += " (*)";
				}
				else if (_edited == true && value == false)
				{
					this.Text = this.Text.Substring(0, this.Text.Length - 4);
				}
				_edited = value;
			}
			get
			{
				return _edited;
			}
		}

		public SPTEditWindow()
		{
			InitializeComponent();
			sptReader = null;
			lastElement = null;
			sptFile = null;
			sptDirectory = null;
			sptDirCurrentIdx = 0;
			_edited = false;
		}

		public void status(string text)
		{
			lblStatus.Text = text;
		}

		private void SPTEditWindow_Load(object sender, EventArgs e)
		{
			this.Text = titles[(new Random()).Next(titles.Length)];
			status("");
			TranslationMemory.LoadFromFile();
			if (File.Exists("last_spt.txt"))
			{
				StreamReader r = new StreamReader(File.OpenRead("last_spt.txt"));
				string f = r.ReadToEnd();
				r.Close();
				if (File.Exists(f))
					openSPTFile(f);
			}
		}

		private void btnOpenSPT_Click(object sender, EventArgs e)
		{
			OpenFileDialog d = new OpenFileDialog();
			d.Filter = "SPT Files|*.spt";
			d.Title = "Select SPT";
			if (d.ShowDialog() == DialogResult.OK)
			{
				openSPTFile(d.FileName);
			}
		}

		private void openSPTFile(string filename)
		{
			txtSPTPath.Text = filename;
			if (sptFile != null)
				sptFile.Close();
			sptFile = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			sptDirectory = Directory.GetFiles(filename.Substring(0, filename.LastIndexOf('\\') + 1), "*.spt");
			Array.Sort(sptDirectory);
			sptDirCurrentIdx = Array.BinarySearch(sptDirectory, filename);
			sptReader = new BinaryReader(sptFile, Font10Converter.SHIFT_JIS);
			loadSPT();
		}

		private void loadSPT()
		{
			if (sptReader == null)
				return;
			panel1.Controls.Clear();
			lastElement = null;
			Edited = false;

			// data structure set up
			int id = 0;
			root = new SPTBlock(0);
			blockHierarchy = new Stack<SPTBlock>();
			blockHierarchy.Push(root);
			SPTCommand c;

			// case-specific flags
			bool needNewBlock = true;
			bool checkNameWinClose = false;

			while ((c = SPTCommand.FromStream(sptReader, id++, blockHierarchy.Peek())) != null)
			{
				// pre loop logic
				if (c.GetArg(0)[0] == '{')
				{
					SPTBlock b = new SPTBlock(id);
					b.Elements.Add(c);
					blockHierarchy.Peek().Elements.Add(b);
					blockHierarchy.Push(b);
					continue;
				}
				else if (c.GetArg(0)[0] == '}')
				{
					blockHierarchy.Pop().Elements.Add(c);
					continue;
				}
				blockHierarchy.Peek().Elements.Add(c);
				if (!(c.GetArg(0).Equals("message") || c.GetArg(0).Equals("message0")))
				{
					needNewBlock = true;
				}
				////

				if (c.GetArg(0).Equals("message") || c.GetArg(0).Equals("message0")) // start of message set
				{
					if (needNewBlock)
					{
						if (c.GetArg(1) != "mbox0")
							addTranslatable(new Note("Found non-mbox0 message box, tell me about this", id));
						addTranslatable(new MessageBlock());
						needNewBlock = false;
					}
					for (int i = 2; i < c.ArgCount; ++i)
					{
						string msg = c.GetArg(i);
						if (i + 1 < c.ArgCount)
						{
							msg += "§";
						}
						lastElement.JapText += msg;
					}
					lastElement.JapText += "¶\r\n";
					lastElement.commands.Add(c);
				}
				else if (c.GetArg(0).Equals("nameset0")) // setting talker name
				{
					if (c.GetArg(1).Equals("N0"))
					{
						addTranslatable(new Nameplate());
						lastElement.JapText = c.GetArg(2);
						lastElement.commands.Add(c);
					}
				}
				else if (c.GetArg(0).Equals("nameset")) // check for azuma talking
				{
					if (c.GetArg(1).Equals("N0") && c.GetArg(2).StartsWith("00_"))
					{
						if (lastElement != null && lastElement.JapText.Equals("NO NAME:")) //it removes nameplate for azuma, have to ignore for this
							panel1.Controls.Remove(lastElement);
						lastElement = ((panel1.Controls.Count - 1 >= 0) ? (Translatable)panel1.Controls[panel1.Controls.Count - 1] : null);
						addTranslatable(new Note("AZUMA:"));
					}
				}
				else if (c.GetArg(0).Equals("actortext0") && c.GetArg(1).Equals("name_win")) // check if name window being hidden
				{
					checkNameWinClose = true;
					continue;
				}
				else if (c.GetArg(0).Equals("actordisp0") && c.GetArg(1).Equals("name_win") && c.GetArg(2).Equals("false") && checkNameWinClose)
				{
					addTranslatable(new Note("NO NAME:"));
				}
				else if (c.GetArg(0).Equals("scriptcall0") && c.GetArg(1).Equals("select"))
				{
					int nopts = Convert.ToInt32(c.GetArg(2));
					addTranslatable(new Note("SELECTION ("+ nopts +"):"));
					GenericTranslatable t = new GenericTranslatable(c);
					for (int i = 0; i < nopts + 1; ++i)
						t.AddArg(new GenericTArgOpts(3 + i, (i > 0)));
					addTranslatable(t);
				}
				else if (c.GetArg(0).Equals("scriptcall"))
				{
					addTranslatable(new Note("Note: This script calls \"" + c.GetArg(1) + ".spt\"."));
				}
				else if (c.GetArg(0).StartsWith("ifselect") || (c.ArgCount > 1 && c.GetArg(1).StartsWith("ifselect")))
				{
					addTranslatable(new Note("IF-SELECT:"));
					GenericTranslatable t = new GenericTranslatable(c);
					t.AddArg(new GenericTArgOpts(c.GetArg(0).StartsWith("ifselect") ? 1 : 2, true));
					addTranslatable(t);
				}
				else
				{
					// some non-known command. try finding japanese text.
					// arg 0 is always english command - it won't have japanese text.
					bool done = false;
					if (c.ArgCount > 1)
					{
						for (int i = 1; i < c.ArgCount && !done; ++i)
						{
							string arg = c.GetArg(i);
							// check if one of the first 3 characters is japanese
							for (int j = 0; j < Math.Min(3, arg.Length); ++j)
							{
								if (Font10Converter.IsJapanese(arg[j]))
								{
									addTranslatable(new Note("Unidentified Japanese text detected, tell me about this. Full command shown.", id));
									GenericTranslatable t = new GenericTranslatable(c);
									for (int k = 0; k < c.ArgCount; ++k)
										t.AddArg((GenericTArgOpts)k);
									addTranslatable(t);
									done = true;
									break;
								}
							}
						}
					}
				}

				////
				checkNameWinClose = false;
				// post loop logic
			}
			panel1.Focus(); // so the scroll bar works more intuitively
			UpdateFromMemory();
			status("Loaded \"" + txtSPTPath.Text.Substring(txtSPTPath.Text.LastIndexOf('\\')+1) + "\"");
		}

		private void btnPrevSPT_Click(object sender, EventArgs e)
		{
			if (sptDirectory == null)
				return;

			switch (doSaveConfirmation())
			{
				case DialogResult.Cancel:
					return;
				case DialogResult.No:
					break;
				case DialogResult.Yes:
					saveFile();
					break;
			}

			if (sptDirCurrentIdx - 1 == -1)
			{
				MessageBox.Show("No more SPT files available");
				return;
			}
			openSPTFile(sptDirectory[--sptDirCurrentIdx]);
		}

		private void btnNextSPT_Click(object sender, EventArgs e)
		{
			if (sptDirectory == null)
				return;

			switch (doSaveConfirmation())
			{
				case DialogResult.Cancel:
					return;
				case DialogResult.No:
					break;
				case DialogResult.Yes:
					saveFile();
					break;
			}

			if (sptDirCurrentIdx + 1 == sptDirectory.Length)
			{
				MessageBox.Show("No more SPT files available");
				return;
			}
			openSPTFile(sptDirectory[++sptDirCurrentIdx]);
		}

		private void addTranslatable(Translatable t)
		{
			int y = ((lastElement != null) ? (lastElement.Location.Y + lastElement.Size.Height) : 0);
			t.Location = new Point(2, y + 2);
			panel1.Controls.Add(t);
			lastElement = t;
			t.EditEvent += new Translatable.OnEdit(t_EditEvent);
		}

		void t_EditEvent(object sender, EventArgs e)
		{
			Edited = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (sptFile == null)
				return;
			FileStream f = sptFile;
			BinaryWriter w = new BinaryWriter(f, Font10Converter.SHIFT_JIS);
			//List<SPTCommand> tempCommands = new List<SPTCommand>(fileCommands);
			UpdateMemory();
			for (int cind = panel1.Controls.Count - 1; cind >= 0; cind--)
			{
				Translatable t = panel1.Controls[cind] as Translatable;
				if (t == null || t.commands.Count == 0)
					continue;

				SPTCommand first = t.commands[0];
				List<SPTCommand> eng = t.GetEnglishCommands();
				if (eng.Count != 0)
				{
					int idx = first.GetIndexInBlock();
					first.Block.Elements.RemoveRange(idx, t.commands.Count);
					first.Block.Elements.InsertRange(idx, eng);
					t.commands = eng;
				}
			}
			UpdateLineNumbers(root);
			w.BaseStream.SetLength(0);
			w.BaseStream.Flush();
			writeSPTFile(w, root);
			w.Flush();
			Edited = false;
			status("Save completed.");
		}

		private static int UpdateLineNumbers(SPTBlock block, int start = 0)
		{
			int i = 0;
			if (start == 0)
			{
				block.Elements[0] = new SPTCommand(0, block);
				((SPTCommand)block.Elements[0]).PushArg((block.Size - 1).ToString());
				++i;
			}
			for (; i < block.Elements.Count; ++i)
			{
				block.Elements[i].LineNumber = ++start;
				if (block.Elements[i] is SPTBlock)
				{
					start = UpdateLineNumbers((SPTBlock)block.Elements[i], --start);
				}
			}
			return start;
		}

		public static void writeSPTFile(BinaryWriter w, SPTBlock block)
		{
			for (int i = 0; i < block.Elements.Count; ++i)
			{
				if (block.Elements[i] is SPTBlock)
				{
					writeSPTFile(w, (SPTBlock)block.Elements[i]);
				}
				else if (block.Elements[i] is SPTCommand)
				{
					SPTCommand c = ((SPTCommand)block.Elements[i]);
					if (c.GetArg(0)[0] == '{')
					{
						w.Write(Font10Converter.SHIFT_JIS.GetBytes("{" + (block.LineNumber + block.Size - 2) + "\0\r"));
					}
					else if (c.GetArg(0)[0] == '}')
					{
						w.Write(Font10Converter.SHIFT_JIS.GetBytes("}" + (block.LineNumber - 1) + "\0\r"));
					}
					else
					{
						byte[] ba = c.ToByteArray();
						//byte[] wr = Encoding.Convert(Encoding.Unicode, Encoding.GetEncoding(1252), Encoding.Unicode.GetBytes(ws));
						w.Write(ba);
					}
				}
			}
		}

		private void SPTEditWindow_SizeChanged(object sender, EventArgs e)
		{
			panel1.Height = this.Height - 120;
		}

		private void SPTEditWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (sptFile == null)
				return;
			switch (doSaveConfirmation())
			{
				case DialogResult.Cancel:
					e.Cancel = true;
					return;
				case DialogResult.No:
					break;
				case DialogResult.Yes:
					saveFile();
					break;
			}
			sptFile.Close();
			TranslationMemory.WriteToFile();
			writeLastSPT(txtSPTPath.Text);
		}

		private static void writeLastSPT(string p)
		{
			StreamWriter w = new StreamWriter(File.Open("last_spt.txt", FileMode.OpenOrCreate, FileAccess.Write));
			w.BaseStream.SetLength(0);
			w.Flush();
			w.Write(p);
			w.Close();
		}

		public DialogResult doSaveConfirmation()
		{
			if (Edited == false)
				return DialogResult.No;
			return (MessageBox.Show("Would you like to save before continuing?", "Save confirmation", MessageBoxButtons.YesNoCancel));
		}

		public void saveFile()
		{
			btnSave_Click(null, null);
		}

		private void panel1_Scroll(object sender, ScrollEventArgs e)
		{
			panel1.Focus();
		}

		private void UpdateMemory()
		{
			for (int cind = panel1.Controls.Count - 1; cind >= 0; cind--)
			{
				Translatable t = panel1.Controls[cind] as Translatable;
				if (t == null)
					continue;
				List<KeyValuePair<string, string>> entries = t.GetMemoryEntries();
				if (entries == null)
					continue;
				foreach (KeyValuePair<string, string> e in entries)
					TranslationMemory.AddEntry(e.Key, e.Value);
			}
			UpdateFromMemory();
		}

		private void UpdateFromMemory()
		{
			for (int cind = panel1.Controls.Count - 1; cind >= 0; cind--)
			{
				Translatable t = panel1.Controls[cind] as Translatable;
				if (t == null)
					continue;
				t.UpdateFromMemory();
			}
		}

		private void SPTEditWindow_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
				saveFile();
			if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
				openFindWindow();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Variables:\r\nS0 - Player's Name (Azuma)\r\nS1 - Dog's name (Maron lol)\r\n" +
				"S2 - Starter Medabot name (Metabee/Rokusho)\r\nUse § to signify that you want to use a variable in your translation, eg \"Hello, §S2§!\"\r\n\r\n" +
				"If you find an unknown character, ie. \"(0x91CC)\" appears on the Japanese side, open the TEX + Font tools and enter (0x91CC) in the text box there, and hit 'Get font char' to see it.\r\n\r\n" + 
				"Feel free to use tab to scroll through the boxes, and Ctrl-S to save.\r\n\r\n" +
				"When notes appear to tell me something, please tell me :)\r\n" +
				"Please be aware that it might be dangerous to translate the things that are noted as such. Ask me first.", 
			"Halp", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btn_find_Click(object sender, EventArgs e)
		{
			openFindWindow();
		}

		public void openFindWindow()
		{
			FindInSPTWindow.Open(this);
		}
	}
}
