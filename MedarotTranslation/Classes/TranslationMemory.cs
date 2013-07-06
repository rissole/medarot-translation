using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MedarotTranslation
{
	class TranslationMemory
	{
		private static Dictionary<string, string> memory = new Dictionary<string, string>();

		public static void LoadFromFile()
		{
			if (memory.Count != 0)
				return;
			if (File.Exists("trans_memory.txt"))
			{
				BinaryReader r = new BinaryReader(File.OpenRead("trans_memory.txt"), Encoding.UTF8);
				memory = new Dictionary<string, string>();
				string soFar = "";
				int nulls = 0;
				while (r.BaseStream.Position < r.BaseStream.Length)
				{
					char c = r.ReadChar();
					if (c == 0)
					{
						nulls++;
						if (nulls == 2)
						{
							soFar = new string(Encoding.Unicode.GetChars(Encoding.Convert(Encoding.UTF8, Encoding.Unicode, Encoding.UTF8.GetBytes(soFar))));
							string[] entry = soFar.Split('\0');
							//NewConsole.WriteLine(entry[0] + ":" + entry[1]);
							memory.Add(entry[0], entry[1]);
							nulls = 0;
							soFar = "";
							continue;
						}
					}
					soFar += c;
				}
				r.Close();
			}
		}

		public static void WriteToFile()
		{
			BinaryWriter w;
			File.Copy("trans_memory.txt", "trans_memory.bak");
			try
			{
				w = new BinaryWriter(File.OpenWrite("trans_memory.txt"), Encoding.UTF8);
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("You already have the dictionary open.");
				return;
			}
			w.BaseStream.SetLength(0);
			w.BaseStream.Flush();
			foreach (KeyValuePair<string, string> e in memory)
			{
				w.Write(Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(e.Key)));
				w.Write((byte)0);
				w.Write(Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(e.Value)));
				w.Write((byte)0);
			}
			w.Flush();
			w.Close();
			File.Delete("trans_memory.bak");
		}

		public static void AddEntry(string jap, string eng)
		{
			if (jap.Contains('\0') || eng.Contains('\0'))
				throw new Exception("No nulls in here!");
			string temp;
			if (!memory.TryGetValue(jap, out temp))
				memory.Add(jap, eng);
			else if (eng != temp)
				memory[jap] = eng;
		}

		public static string GetEntry(string jap)
		{
			string ret;
			if (!memory.TryGetValue(jap, out ret))
				return "";
			else
				return ret;
		}

		public static Dictionary<string, string>.Enumerator GetEnumerator()
		{
			return memory.GetEnumerator();
		}

		public static void Clear()
		{
			memory.Clear();
		}
	}
}
