using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VumadoC
{
	public class AnswerBuilder
	{
		public static void BuildForm(Control container, Questionaire questionaire, QuestionaireTemplate structure)
		{
			Control answerControl;

			if (questionaire.AnswerCount != structure.Count)
				return;

			var i = structure.Count;
			foreach (var question in structure)
			{
				i--;

				switch (question.Type)
				{
					case QuestionaireTemplate.QuestionType.TextQuestion:
						answerControl = GenerateTextBox(questionaire, i);
						container.Controls.Add(answerControl);
						container.Controls.SetChildIndex(answerControl, 0);
						break;
					case QuestionaireTemplate.QuestionType.ChoiceQuestion:
						answerControl = GenerateNumBox(questionaire, i, 0, question.Info);
						container.Controls.Add(answerControl);
						container.Controls.SetChildIndex(answerControl, 0);
						break;
				}

				answerControl = GenerateLabel(question.Text);
				container.Controls.Add(answerControl);
				container.Controls.SetChildIndex(answerControl, 1);
			}
		}

		private static Label GenerateLabel(string name)
		{
			var label = new Label
			{
				Dock = DockStyle.Top,
				Text = name
			};

			return label;
		}

		private static TextBox GenerateTextBox(Questionaire questionaire, int answerIndex)
		{
			var box = new TextBox
			{
				Dock = DockStyle.Top,
				Multiline = true,
				Height = 100,
				TabIndex = answerIndex,
				Text = questionaire.Current.getStringValue(answerIndex),
				ScrollBars = ScrollBars.None
			};

			box.TextChanged += (Object sender, EventArgs args) =>
			{
				questionaire.Current.setStringValue(answerIndex, box.Text);
			};

			EventHandler answerChangedHandler = (Object sender, EventArgs e) =>
			{
				box.Text = questionaire.Current.getStringValue(answerIndex);
			};
			questionaire.SelectedAnswerChanged += answerChangedHandler;
			box.Disposed += (Object sender, EventArgs e) =>
			{
				questionaire.SelectedAnswerChanged -= answerChangedHandler;
			};
			box.MouseWheel += (object sender, MouseEventArgs e) =>
			{

			};

			return box;
		}

		private static NumericUpDown GenerateNumBox(Questionaire questionaire, int answerIndex, int numMinValue = 0, int numMaxValue = int.MaxValue)
		{
			var box = new NumericUpDown
			{
				Dock = DockStyle.Top,
				Minimum = numMinValue,
				Maximum = numMaxValue,
				TabIndex = answerIndex,
				Value = questionaire.Current.getIntValue(answerIndex, 1)
			};

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
