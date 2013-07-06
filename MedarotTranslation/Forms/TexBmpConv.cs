using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MedarotTranslation
{
	public partial class TexBmpConv : Form
	{
		Color[] palette;
		public static sNFTR font = NFTR.Read("font10.nftr", 0, "");
		private static Dictionary<int, int> charTile;

		public TexBmpConv()
		{
			palette = new Color[256];
			for (int i = 0; i < 256; ++i)
			{
				palette[i] = Color.FromArgb(i, i, i);
			}
			InitializeComponent();
		}

		public static void Init()
		{
			Fill_CharTile();
		}

		private void buttonLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog d = new OpenFileDialog();
			d.Filter = "TEX Files|*.tex";
			d.Title = "Select TEX";
			if (d.ShowDialog() == DialogResult.OK)
			{
				loadTex(d.FileName);
			}
		}

		private void loadTex(string fname)
		{
			int width = 0;
			int height = 0;
			FileStream file = File.Open(fname, FileMode.Open);
			BinaryReader read = new BinaryReader(file);
			read.ReadBytes(4);
			NewConsole.WriteLine(read.ReadUInt32().ToString());
			for (int i = 0; i < 12; ++i)
			{
				UInt16 s = read.ReadUInt16();
				if (i == 1)
					width = s;
				else if (i == 2)
					height = s;
				NewConsole.WriteLine(s.ToString());
			}
			for (int i = 0; i < 256; ++i)
			{
				read.ReadByte(); read.ReadByte(); read.ReadByte(); 
				//palette[i] = Color.FromArgb(read.ReadByte(), read.ReadByte(), read.ReadByte());
				//read.ReadByte();
			}
			Bitmap bmp = new Bitmap(width, height);
			int x = 0, y = 0;
			while (read.BaseStream.Position < read.BaseStream.Length)
			{
				byte r = read.ReadByte();
				bmp.SetPixel(x, y, palette[r]);

				x+=1;
				if (x % (width) == 0)
				{
					x = 0;
					y+=1;
				}
			}
			pictureBox1.Image = bmp;
			file.Close();
			read.Close();
		}

		private void btnTester_Click(object sender, EventArgs e)
		{
			loadTex("C:\\Users\\Rissole\\Downloads\\roms\\Medarot DS\\t\\dslazy\\NDS_UNPACK\\data\\title\\tex\\title_kb00_00.tex");
		}

		private static void Fill_CharTile()
		{
			charTile = new Dictionary<int, int>();
			for (int p = 0; p < font.pamc.Count; p++)
			{
				if (font.pamc[p].info is sNFTR.PAMC.Type0)
				{
					sNFTR.PAMC.Type0 type0 = (sNFTR.PAMC.Type0)font.pamc[p].info;
					int interval = font.pamc[p].last_char - font.pamc[p].first_char;

					for (int j = 0; j <= interval; j++)
						try { charTile.Add(font.pamc[p].first_char + j, type0.fist_char_code + j); }
						catch { }
				}
				else if (font.pamc[p].info is sNFTR.PAMC.Type1)
				{
					sNFTR.PAMC.Type1 type1 = (sNFTR.PAMC.Type1)font.pamc[p].info;

					for (int j = 0; j < type1.char_code.Length; j++)
						try { charTile.Add(font.pamc[p].first_char + j, type1.char_code[j]); }
						catch { }
				}
				else if (font.pamc[p].info is sNFTR.PAMC.Type2)
				{
					sNFTR.PAMC.Type2 type2 = (sNFTR.PAMC.Type2)font.pamc[p].info;

					for (int j = 0; j < type2.num_chars; j++)
						try { charTile.Add(type2.charInfo[j].chars_code, type2.charInfo[j].chars); }
						catch { }
				}
			}
		}


		private void btnSave_Click(object sender, EventArgs e) //'get font'
		{
			Color[] pal = new Color[2];
			pal[0] = Color.Transparent;
			pal[1] = Color.Black;
			if (txtGetFont.Text.Length > 0)
			{
				try
				{
					int code = Convert.ToInt32(txtGetFont.Text.Replace("(", "").Replace(")", "").Replace("0x", ""), 16);
					int id = charTile[code];
					pictureBox1.Image = NFTR.Get_Char(font, id, pal, 3);
				}
				catch
				{
					NewConsole.WriteLine("Bad character code");
				}
			}
		}

		private void txtGetFont_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				btnSave_Click(null, null);
		}

		public static int IndexFromCode(int code)
		{
			return (from k in charTile where (int.Equals(k.Value, code)) select k.Key).FirstOrDefault();
		}
	}
}
