using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedarotTranslation
{
	public abstract class SPTElement
	{
		public int LineNumber
		{
			get;
			set;
		}
		public SPTElement(int lineNum)
		{
			LineNumber = lineNum;
		}
	}
}
