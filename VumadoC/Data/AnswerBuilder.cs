using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VumadoC
{
	/// <summary>
	/// Generates the UI for entering the answers to the questionairs
	/// </summary>
	public class AnswerBuilder
	{
		public static void buildForm(Control container, Questionaire questionaire, QuestionaireTemplate structure)
		{
			if (questionaire.AnswerCount != structure.Count)
				return;

			var i = 0;
			var result = new Stack<Control>();
			foreach (var question in structure)
			{
				result.Push(generateLabel(question.Text));

				switch (question.Type)
				{
					case QuestionaireTemplate.QuestionType.TextQuestion:
						result.Push(generateTextBox(questionaire, i));
						break;
					case QuestionaireTemplate.QuestionType.ChoiceQuestion:
						result.Push(generateNumBox(questionaire, i, 0, question.Info));
						break;
				}

				i++;
			}

			container.Controls.AddRange(result.ToArray());
		}

		private static Label generateLabel(string name)
		{
			var label = new Label();

			label.Dock = DockStyle.Top;
			label.Text = name;

			return label;
		}

		private static TextBox generateTextBox(Questionaire questionaire, int answerIndex)
		{
			var box = new TextBox();

			box.Dock = DockStyle.Top;
			box.Multiline = true;
			box.ScrollBars = ScrollBars.None;
			box.Height = 100;
			box.TabIndex = answerIndex;
			box.Text = questionaire.Current.getStringValue(answerIndex);

			box.TextChanged += (Object sender, EventArgs args) =>
			{
				questionaire.Current.setStringValue(answerIndex, box.Text);
			};

			EventHandler handler = (Object sender, EventArgs e) =>
			{
				box.Text = questionaire.Current.getStringValue(answerIndex);
			};
			questionaire.SelectedAnswerChanged += handler;
			box.Disposed += (Object sender, EventArgs e) =>
			{
				questionaire.SelectedAnswerChanged -= handler;
			};

			return box;
		}

		private static NumericUpDown generateNumBox(Questionaire questionaire, int answerIndex, int numMinValue = 0, int numMaxValue = int.MaxValue)
		{
			var box = new NumericUpDown();

			box.Dock = DockStyle.Top;
			box.Minimum = numMinValue;
			box.Maximum = numMaxValue;
			box.TabIndex = answerIndex;
			box.Value = questionaire.Current.getIntValue(answerIndex, 1);

			box.ValueChanged += (Object sender, EventArgs args) =>
			{
				questionaire.Current.setIntValue(answerIndex, (int)box.Value);
			};

			EventHandler handler = (Object sender, EventArgs e) =>
			{
				box.Value = questionaire.Current.getIntValue(answerIndex, 1);
			};
			questionaire.SelectedAnswerChanged += handler;
			box.Disposed += (Object sender, EventArgs e) =>
			{
				questionaire.SelectedAnswerChanged -= handler;
			};

			return box;
		}
	}
}
