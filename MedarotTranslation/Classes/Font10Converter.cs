using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedarotTranslation
{
	class Font10Converter
	{
		public static Encoding SHIFT_JIS; // encoding cached
		public const ushort TWO_BYTE_BOUNDARY = 0x80; // in shift-jis anything over 0x80 is a 2 byte char

		// Special characters that are replaced when writing to file
		// value replaces key
		private static Dictionary<char, char> WriteReplace;

		public Font10Converter()
		{
		}

		public static void Init()
		{
			try
			{
				SHIFT_JIS = Encoding.GetEncoding("shift-jis");
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("No SHIFT-JIS found, get your encodings under control", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}

			WriteReplace = new Dictionary<char, char>();
			WriteReplace.Add('§', '\0'); // For S0, S1, S2 etc.
		}

		/// <summary>
		/// Take a string in, get shift-jis character codes.
		/// </summary>
		/// <param name="inp"></param>
		/// <returns></returns>
		public static ushort[] GetCodes(string inp)
		{
			byte[] bytes = SHIFT_JIS.GetBytes(inp);
			List<ushort> ret = new List<ushort>(bytes.Length / 2);
			for (int i = 0; i < bytes.Length;)
			{
				if (bytes[i] > TWO_BYTE_BOUNDARY)
				{
					ret.Add((ushort)(bytes[i] << 8 | bytes[i+1]));
					i += 2;
				}
				else
				{
					ret.Add((ushort)bytes[i]);
					++i;
				}

			}
			return ret.ToArray();
		}

		/// <summary>
		/// Gets the shift-jis byte codes of the string provided.
		/// </summary>
		/// <param name="inp"></param>
		/// <returns></returns>
		public static byte[] GetBytes(string inp)
		{
			return SHIFT_JIS.GetBytes(inp);
		}

		public static bool IsJapanese(char inp)
		{
			return (inp > TWO_BYTE_BOUNDARY);
		}

		public static string ReplaceOut(string inp)
		{
			string ret = inp;
			foreach (char c in WriteReplace.Keys)
			{
				ret = ret.Replace(c, WriteReplace[c]);
			}
			return ret;
		}
	}
}
