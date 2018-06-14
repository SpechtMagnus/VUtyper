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

			AnswerBuilder.BuildForm(this.answersLayout, this.loadedQuestionaire, structure);
			this.UpdateData();
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			loadedQuestionaire.Next();
			UpdateData();
		}

		private void PrevButton_Click(object sender, EventArgs e)
		{
			loadedQuestionaire.Prev();
			UpdateData();
		}

		private void UpdateData()
		{
			this.indexlabel.Text = (this.loadedQuestionaire.CurrentIndex + 1) + "/" + this.loadedQuestionaire.NumberOfAnswers;

			this.answersLayout.Controls[this.answersLayout.Controls.Count - 2]?.Focus();
		}
	}
}
