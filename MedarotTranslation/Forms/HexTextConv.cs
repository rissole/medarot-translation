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
	public partial class HexTextConv : Form
	{
		public HexTextConv()
		{
			InitializeComponent();
		}

		private void btnH2T_Click(object sender, EventArgs e)
		{
			//bool isAnsi = !Char.IsNumber(txtHex.Text.TrimStart(' ', '\t')[0]);
			//Console.WriteLine("auto detected " + ((isAnsi) ? "ansi mode" : "numbers mode"));
			//txtText.Text = Font10Converter.GetCharString(txtHex.Text, isAnsi ? Encoding.GetEncoding(1252) : null);
		}

		private void btnT2H_Click(object sender, EventArgs e)
		{
			//txtHex.Text = Font10Converter.GetHexString(txtText.Text);
		}
	}
}
