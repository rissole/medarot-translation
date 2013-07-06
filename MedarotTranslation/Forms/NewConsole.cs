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
	public partial class NewConsole : Form
	{
		private static NewConsole _this = new NewConsole();

		public static void Init()
		{
			_this.Show();
			_this.Location = new Point(550, 90);
		}

		public NewConsole()
		{
			InitializeComponent();
		}

		private void _writeline(string s)
		{
			_this.tbx.Text += s + "\r\n";
		}

		private void _writeline(char c)
		{
			_this.tbx.Text += c + "\r\n";
		}

		public static void WriteLine(string s)
		{
			_this._writeline(s);
		}

		public static void WriteLine(char c)
		{
			_this._writeline(c);
		}

		//////////////////////////////////////////

		private void _write(string s)
		{
			_this.tbx.Text += s;
		}

		private void _write(char c)
		{
			_this.tbx.Text += c;
		}

		public static void Write(string s)
		{
			_this._write(s);
		}

		public static void Write(char c)
		{
			_this._write(c);
		}

		private void btnClr_Click(object sender, EventArgs e)
		{
			tbx.Text = "";
		}
	}
}
