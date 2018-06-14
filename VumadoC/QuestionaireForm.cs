using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace VumadoC
{
	public partial class QuestionaireForm : Form
	{
		private Questionaire loadedQuestionaire;
		private QuestionaireTemplate questionaireStructure;

		public QuestionaireForm()
		{
			InitializeComponent();

			/*Teste Fragebogen Schema
			this.questionaireStructure = new QuestionaireTemplate(new List<QuestionaireTemplate.QuestionTemplate>
			{
				new QuestionaireTemplate.QuestionTemplate()
				{
					Text = "Die Veröffentlichung der Ergebnisse der Vorlseungsumfrage ist für mich:",
					Type = QuestionaireTemplate.QuestionType.ChoiceQuestion,
					Info = 6
				},
				new QuestionaireTemplate.QuestionTemplate()
				{
					Text = "Wenn der Dozent diesen handschriftlichen Bogen zu sehen bekäme, fände ich das:",
					Type = QuestionaireTemplate.QuestionType.ChoiceQuestion,
					Info = 6
				},
				new QuestionaireTemplate.QuestionTemplate()
				{
					Text = "Bemerkungen zum Schein (falls vorhanden):",
					Type = QuestionaireTemplate.QuestionType.TextQuestion
				},
				new QuestionaireTemplate.QuestionTemplate()
				{
					Text = "Folgende Dinge haben die Tutoren gut/schlecht gemacht:",
					Type = QuestionaireTemplate.QuestionType.TextQuestion
				},
				new QuestionaireTemplate.QuestionTemplate()
				{
					Text = "Weitere Bemerungen zu den Übungen",
					Type = QuestionaireTemplate.QuestionType.TextQuestion
				},
				new QuestionaireTemplate.QuestionTemplate()
				{
					Text = "Weitere Bemerkungen zu den Materialien (Skript, folien, Literatur, etc.):",
					Type = QuestionaireTemplate.QuestionType.TextQuestion
				},
				new QuestionaireTemplate.QuestionTemplate()
				{
					Text = "Ich habe konkrete Wünsche zur Veranstaltung:",
					Type = QuestionaireTemplate.QuestionType.TextQuestion
				},
				new QuestionaireTemplate.QuestionTemplate()
				{
					Text = "Folgende Vorkenntnisse haben mir gefehlt:",
					Type = QuestionaireTemplate.QuestionType.TextQuestion
				}
			});
			var writer = new StreamWriter("defaultQuestionaire.xml");
			new XmlSerializer(typeof(QuestionaireTemplate)).Serialize(writer, this.questionaireStructure);
			writer.Close();*/

			try
			{
				var reader = new StreamReader("defaultQuestionaire.xml");
				this.questionaireStructure = (QuestionaireTemplate)new XmlSerializer(typeof(QuestionaireTemplate)).Deserialize(reader);
				reader.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Die Datei \"defaultQuestionaire.xml\" konnte nicht geladen werden. Stellen Sie sicher, dass die Datei im selben Ordner wie das Programm liegt.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}

			this.loadedQuestionaire = new Questionaire(this.questionaireStructure.Count);
		}

		private void lectureText_TextChanged(object sender, EventArgs e)
		{
			this.loadedQuestionaire.Lecture = lectureText.Text;
		}

		private void profText_TextChanged(object sender, EventArgs e)
		{
			this.loadedQuestionaire.Professor = profText.Text;
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			new AnswersForm(this.loadedQuestionaire, this.questionaireStructure).ShowDialog();
		}

		private void menuNew_Click(object sender, EventArgs e)
		{
			this.loadedQuestionaire = new Questionaire(this.questionaireStructure.Count);
			this.lectureText.Text = this.loadedQuestionaire.Lecture;
			this.profText.Text = this.loadedQuestionaire.Professor;
		}

		private void menuOpen_Click(object sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
			openFileDialog.InitialDirectory = Properties.Settings.Default.WorkingDirectory;
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				Properties.Settings.Default.WorkingDirectory = Path.GetDirectoryName(openFileDialog.FileName);
				loadQuestionaire(openFileDialog.FileName);
			}
		}

		private void menuSave_Click(object sender, EventArgs e)
		{
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
			saveFileDialog.InitialDirectory = Properties.Settings.Default.WorkingDirectory;
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				Properties.Settings.Default.WorkingDirectory = Path.GetDirectoryName(saveFileDialog.FileName);
				saveQuestionaire(saveFileDialog.FileName);
				//UnsavedChanges = false;
			}
		}

		private void menuSaveAs_Click(object sender, EventArgs e)
		{
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
			saveFileDialog.FileName = this.loadedQuestionaire.Lecture + "-" + this.loadedQuestionaire.Professor + ".xml";
			saveFileDialog.InitialDirectory = Properties.Settings.Default.WorkingDirectory;
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				Properties.Settings.Default.WorkingDirectory = Path.GetDirectoryName(saveFileDialog.FileName);
				saveQuestionaire(saveFileDialog.FileName);
			}
		}

		private void menuExport_Click(object sender, EventArgs e)
		{
			var exporter = new LatexExporter.LatexExportParser("exportTemplate.tex");
			exporter.addSectionParser(new LatexExporter.SectionParser.TextSectionParser());
			exporter.addSectionParser(new LatexExporter.SectionParser.TextfieldSectionParser());
			exporter.addSectionParser(new LatexExporter.SectionParser.ForSectionParser());

			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "LaTeX Files (*.tex)|*.tex|All Files (*.*)|*.*";
			saveFileDialog.FileName = this.loadedQuestionaire.Lecture + "-" + this.loadedQuestionaire.Professor + ".tex";
			saveFileDialog.InitialDirectory = Properties.Settings.Default.WorkingDirectory;
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				Properties.Settings.Default.WorkingDirectory = Path.GetDirectoryName(saveFileDialog.FileName);
				using (var output = new StreamWriter(saveFileDialog.FileName))
				{
					exporter.Parse(output, new Export.QuestionaireTreeIterator(this.loadedQuestionaire, this.questionaireStructure));
				}
			}
			
		}

		private void menuQuit_Click(object sender, EventArgs e)
		{

		}


		public void saveQuestionaire(string fileName)
		{
			XmlSerializer x = new XmlSerializer(typeof(Questionaire));
			StreamWriter writer = new StreamWriter(fileName);
			x.Serialize(writer, this.loadedQuestionaire);
			writer.Close();
		}

		public void loadQuestionaire(string fileName)
		{
			XmlSerializer x = new XmlSerializer(typeof(Questionaire));
			StreamReader reader = new StreamReader(fileName);
			this.loadedQuestionaire = (Questionaire)x.Deserialize(reader);
			reader.Close();

			this.lectureText.Text = this.loadedQuestionaire.Lecture;
			this.profText.Text = this.loadedQuestionaire.Professor;
		}
	}
}
