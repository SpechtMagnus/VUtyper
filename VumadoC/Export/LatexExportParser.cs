using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace LatexExporter
{
	public class LatexExportParser
	{
		private List<string> lines;
		private List<ILatexSectionParser> sectionParsers;

		public ILatexSectionParser[] SectionParsers { get { return this.sectionParsers.ToArray(); } }

		public LatexExportParser(string templateFile, List<ILatexSectionParser> sectionParsers = null)
		{
			this.lines = new List<string>();
			using (var template = new StreamReader(new FileStream(templateFile, FileMode.Open)))
			{
				while (!template.EndOfStream)
				{
					this.lines.Add(template.ReadLine());
				}
			}

			this.sectionParsers = sectionParsers ?? new List<ILatexSectionParser>();
		}

		/// <summary>
		/// Adds a new section parser to this exporter
		/// </summary>
		/// <param name="parser"></param>
		public void addSectionParser(ILatexSectionParser parser)
		{
			this.sectionParsers.Add(parser);
		}

		/// <summary>
		/// Parses the given data into the output file using a given template
		/// </summary>
		/// <param name="output">The output file</param>
		/// <param name="dataEnumerator">The exported data</param>
		public virtual void Parse(StreamWriter output, ITreeEnumerator<string> dataEnumerator)
		{
			for (int currLine = 0; currLine < this.lines.Count; currLine++)
			{
				foreach (var parser in sectionParsers)
				{
					if (!parser.CanParse(GetLine(currLine)))
						continue;
					parser.Parse(this, output, ref currLine, dataEnumerator);
					break;
				}
			}
		}

		public string GetLine(int lineNumber)
		{
			if (lineNumber < 0 || lineNumber >= this.lines.Count)
				return null;
			return this.lines[lineNumber];
		}

		public static string escapeLatex(string text)
		{
			// Replace reserved and special chars
			string[] specialChars = { "&", "%", "\\$", "#", "~", "\\^", "\\\\", "\"", "\'" };
			Regex rgx = new Regex(@"(" + String.Join("|", specialChars) + @")");
			text = rgx.Replace(text, "\\char`\\$1");

			//Bold font
			rgx = new Regex(@"\*\*((\w|\s)+)\*\*");
			text = rgx.Replace(text, "\\textbf{$1}");

			//Italic font
			rgx = new Regex(@"__((\w|\s)+)__");
			text = rgx.Replace(text, "\\textit{$1}");

			//Underline text
			rgx = new Regex(@"_((\w|\s)+)_");
			text = rgx.Replace(text, "\\underline{$1}");

			return text;
		}
	}
}
