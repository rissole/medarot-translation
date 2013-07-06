using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MedarotTranslation
{
	public class SPTCommand : SPTElement
	{
		private List<string> args;
		public SPTBlock Block
		{
			get;
			private set;
		}

		public SPTCommand(int lineNum, SPTBlock block) : base(lineNum)
		{
			args = new List<string>(10);
			Block = block;
		}

		public SPTCommand(SPTBlock b)
			: base(-1)
		{
			args = new List<string>(10);
			Block = b;
		}

		public void PushArg(string arg)
		{
			args.Add(arg);
		}

		public static SPTCommand FromStream(BinaryReader r, int id, SPTBlock b)
		{
			string arg = "";
			SPTCommand ret = null;
			while (r.BaseStream.Position + 1 < r.BaseStream.Length)
			{
				if (ret == null)
				{
					ret = new SPTCommand(id, b);
				}

				char c = r.ReadChar();
				if (c == 0)
				{
					ret.args.Add(arg);
					arg = "";
				}
				else if (c == 0x0D)
					break;
				else
				{
					arg += c;
				}
			}
			return ret;
		}

		public string GetArg(int arg)
		{
			return args[arg];
		}

		public int ArgCount { get { return args.Count; } }

		public byte[] ToByteArray()
		{
			List<byte> ret = new List<byte>();
			for (int j = 0; j < args.Count; ++j)
			{
				ret.AddRange(Font10Converter.GetBytes(args[j]));
				ret.Add(0);
			}
			ret.Add(0x0D);
			//NewConsole.WriteLine(ret);
			return ret.ToArray();
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
			/*SPTCommand other = obj as SPTCommand;
			if (other == null || ArgCount != other.ArgCount)
				return false;
			for (int i = 0; i < ArgCount; ++i)
			{
				if (args[i].Equals(other.args[i]) == false)
					return false;
			}
			return true;*/
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public int GetIndexInBlock()
		{
			return Block.Elements.IndexOf(this);
		}
	}
}
