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
			return token.Contains("%# print data #%") ||
				token.Contains("%# print next data #%") ||
				token.Contains("%# skip data #%");
		}

		public void Parse(LatexExportParser parent, StreamWriter output, ref int currLine, ITreeEnumerator<string> dataEnumerator)
		{
			string token = parent.GetLine(currLine);

			if(token.Contains("%# print data #%"))
			{
				output.WriteLine(LatexExportParser.escapeLatex(dataEnumerator.Current));
			}
			else if(token.Contains("%# print next data #%"))
			{
				if (!dataEnumerator.MoveNext())
					throw new IndexOutOfRangeException("No printable data found");

				output.WriteLine(LatexExportParser.escapeLatex(dataEnumerator.Current));
			}
			else if(token.Contains("%# skip data #%"))
			{
				if (!dataEnumerator.MoveNext())
					throw new IndexOutOfRangeException("No printable data found");
			}
		}
	}
}
