using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LatexExporter
{
	/// <summary>
	/// Specifies a parser for a given template line. The parser instance has to be able to parse multiple data recursively
	/// </summary>
    public interface ILatexSectionParser
    {
		void Parse(LatexExportParser parent, StreamWriter output, ref int currLine, ITreeEnumerator<string> dataEnumerator);

		bool CanParse(string token);
	}
}
