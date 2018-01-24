using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LatexExporter.SectionParser
{
	public class TextfieldSectionParser : ILatexSectionParser
	{
		public bool CanParse(string token)
		{
			return token.Contains("%# InputCurrentData #%") ||
				token.Contains("%# InputNextData #%") ||
				token.Contains("%# SkipData #%");
		}

		public void Parse(LatexExportParser parent, StreamWriter output, ref int currLine, ITreeEnumerator<string> dataEnumerator)
		{
			string token = parent.GetLine(currLine);

			if(token.Contains("%# InputCurrentData #%"))
			{
				output.WriteLine(dataEnumerator.Current);
			}
			else if(token.Contains("%# InputNextData #%"))
			{
				if (!dataEnumerator.MoveNext())
					throw new IndexOutOfRangeException("No printable data found");

				output.WriteLine(dataEnumerator.Current);
			}
			else if(token.Contains("%# SkipData #%"))
			{
				if (!dataEnumerator.MoveNext())
					throw new IndexOutOfRangeException("No printable data found");
			}
		}
	}
}
