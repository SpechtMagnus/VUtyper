using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VumadoC
{
	public partial class AnswersForm : Form
	{
		private Questionaire loadedQuestionaire;

		public AnswersForm(Questionaire questionaire, QuestionaireTemplate structure)
		{
			InitializeComponent();
			this.loadedQuestionaire = questionaire;

			AnswerBuilder.buildForm(this.answersLayout, this.loadedQuestionaire, structure);
			this.updateData();
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			loadedQuestionaire.Next();
			updateData();
		}

		private void prevButton_Click(object sender, EventArgs e)
		{
			loadedQuestionaire.Prev();
			updateData();
		}

		private void updateData()
		{
			this.indexlabel.Text = (this.loadedQuestionaire.CurrentIndex + 1) + "/" + this.loadedQuestionaire.NumberOfAnswers;

			this.answersLayout.Controls[this.answersLayout.Controls.Count - 2]?.Focus();
		}
	}
}
