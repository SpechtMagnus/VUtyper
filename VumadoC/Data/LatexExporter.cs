using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VumadoC.Data
{
	class LatexExporter
	{
		

		public static string exportToLatex(Questionaire questionaire, QuestionaireTemplate structure)
		{
			string result = "";

			foreach(var question in structure)
			{
				var latexQuestion = new LatexQuestion(question.Text);
				
			}

			return result;
		}

		class LatexQuestion
		{
			public string Text { get; set; }
			private List<LatexAnswer> answers;

			public LatexQuestion(string text)
			{
				this.Text = text;
				this.answers = new List<LatexAnswer>();
			}

			public void addAnswer(LatexAnswer answer)
			{
				this.answers.Add(answer);
			}

			public override string ToString()
			{
				return "\\begin{ enumerate}\n" + string.Join("\n", this.answers) + "\n\\end{enumarate}";
			}
		}

		class LatexAnswer
		{
			public string Text { get; set; }

			public override string ToString()
			{
				return "\\item " + new StringBuilder(this.Text).Replace("\\", "\\bs").Replace("\n", "\\\\\n").ToString();
			}
		}
	}
}
