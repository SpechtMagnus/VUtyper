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
			dataEnumerator = dataEnumerator.MoveIn();

			while (dataEnumerator.MoveNext())
			{
				currLine = forBegin;

				for(currLine = forBegin; parent.GetLine(currLine) != null; currLine++)
				{
					if (parent.GetLine(currLine).Contains("%# end for #%"))
						break;

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
