using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LatexExporter.SectionParser
{
	class ForSectionParser : ILatexSectionParser
	{
		public bool CanParse(string token)
		{
			return token.Contains("%# for children #%");
		}

		public void Parse(LatexExportParser parent, StreamWriter output, ref int currLine, ITreeEnumerator<string> dataEnumerator)
		{
			int forBegin = currLine + 1;
			dataEnumerator.MoveIn();

			while (dataEnumerator.MoveNext())
			{
				currLine = forBegin;

				while (parent.GetLine(currLine) != null && !parent.GetLine(currLine).Contains("%# end for #%"))
				{
					foreach (var parser in parent.SectionParsers)
					{
						if (!parser.CanParse(parent.GetLine(currLine)))
							continue;

						parser.Parse(parent, output, ref currLine, dataEnumerator);
						break;
					}
				}
			}
		}
	}
}
