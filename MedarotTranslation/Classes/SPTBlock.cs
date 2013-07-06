using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedarotTranslation
{
	public class SPTBlock : SPTElement
	{
		public List<SPTElement> Elements
		{
			get;
			protected set;
		}

		public SPTBlock(int lineNum) : base(lineNum)
		{
			Elements = new List<SPTElement>();
		}

		// Make a duplicate SPTBlock... just the blocks are duplicated
		public SPTBlock(SPTBlock orig) : base(orig.LineNumber)
		{
			Elements = new List<SPTElement>();
			for (int i = 0; i < orig.Elements.Count; ++i)
			{
				if (orig.Elements[i] is SPTBlock)
				{
					Elements.Add(new SPTBlock(((SPTBlock)orig.Elements[i])));
				}
				else
				{
					Elements.Add(orig.Elements[i]);
				}
			}
		}

		public int Size
		{
			get
			{
				int s = 0;
				for (int i = 0; i < Elements.Count; ++i)
				{
					++s;
					if (Elements[i] is SPTBlock)
						s += ((SPTBlock)Elements[i]).Size - 1;
				}
				return s;
			}
		}
	}
}
