using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LatexExporter.SectionParser
{
	public class TextSectionParser : ILatexSectionParser
	{
		public bool CanParse(string token)
		{
			return !token.Contains("%#");
		}

		public void Parse(LatexExportParser parent, StreamWriter output, ref int currLine, ITreeEnumerator<string> dataEnumerator)
		{
			if (!CanParse(parent.GetLine(currLine)))
				return;

			output.WriteLine(parent.GetLine(currLine));
		}
	}
}
