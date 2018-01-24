using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VumadoC
{
	public class Questionaire : IXmlSerializable
	{
		private string lecture;
		private string prof;
        // Answers to each question
		private List<AnswerSet> answers;
		private int answerCount;
		private int selectedAnswerIndex;

		public event EventHandler SelectedAnswerChanged;


		public Questionaire()
		{
			this.lecture = "";
			this.prof = "";

			//Initialize answers and add empty AnswerSet
			this.answers = new List<AnswerSet>();
			this.answerCount = 0;
			this.answers.Add(new AnswerSet(this.answerCount));
			this.selectedAnswerIndex = 0;
		}

		public Questionaire(int answerCount, string lecture = "", string prof = "")
		{
			this.lecture = lecture;
			this.prof = prof;

			//Initialize answers and add empty AnswerSet
			this.answers = new List<AnswerSet>();
			this.answerCount = answerCount;
			this.answers.Add(new AnswerSet(this.answerCount));
			this.selectedAnswerIndex = 0;
		}

		public String Lecture
		{
			get { return this.lecture; }
			set { this.lecture = value == null ? "" : value; }
		}

		public String Professor
		{
			get { return this.prof; }
			set { this.prof = value == null ? "" : value; }
		}

		public int AnswerCount
		{
			get { return this.answerCount; }
			private set
			{
				if (this.answerCount == 0)
				{
					this.answerCount = value;
					this.answers.Clear();
					this.answers.Add(new AnswerSet(this.answerCount));
					this.selectedAnswerIndex = 0;
				}
			}
		}

		public int CurrentIndex
		{
			get { return this.selectedAnswerIndex; }
		}

		public int NumberOfAnswers
		{
			get { return this.answers.Count; }
		}


		#region Access answers
		public AnswerSet Next()
		{
			//selectedIndex is not allowed an invalid value
			if (this.selectedAnswerIndex == this.answers.Count - 1)
			{
				if (Current.isEmpty())
				{
					return Current;
				}
				else
				{
					this.answers.Add(new AnswerSet(this.answerCount));
					//Proceed normally
				}
			}

			this.selectedAnswerIndex++;
			SelectedAnswerChanged?.Invoke(this, EventArgs.Empty);
			return this.answers[this.selectedAnswerIndex];
		}

		public AnswerSet Prev()
		{
			//selectedIndex is not allowed an invalid value
			if (this.selectedAnswerIndex == 0)
			{
				return null;
			}

			this.selectedAnswerIndex--;
			SelectedAnswerChanged?.Invoke(this, EventArgs.Empty);
			return this.answers[this.selectedAnswerIndex];
		}

		public AnswerSet Current
		{
			//selectedIndex is not allowed an invalid value
			get { return this.answers[this.selectedAnswerIndex]; }
		}

		public void RemoveCurrent()
		{
			this.answers.RemoveAt(this.selectedAnswerIndex);
			if (this.answers.Count == 0)
			{
				this.answers.Add(new AnswerSet(this.answerCount));
			}
			if (this.selectedAnswerIndex >= this.answers.Count)
			{
				this.selectedAnswerIndex = this.answers.Count - 1;
			}
		}

		public AnswerSet Get(int index)
		{
			if (index < 0 || index >= this.answers.Count)
				return null;
			return this.answers[index];
		}
		#endregion

		#region Serialization
		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			while (reader.Read())
			{
				if (reader.IsStartElement())
				{
					switch (reader.Name)
					{
						case "lecture":
							reader.ReadStartElement();
							this.lecture = reader.ReadContentAsString();
							break;
						case "prof":
							reader.ReadStartElement();
							this.prof = reader.ReadContentAsString();
							break;
						case "answerCount":
							reader.ReadStartElement();
							this.AnswerCount = reader.ReadContentAsInt();
							this.selectedAnswerIndex = 0;
							this.answers.Clear();
							break;
						case "answerset":
							var answer = new AnswerSet(this.answerCount);
							answer.ReadXml(reader.ReadSubtree());
							this.answers.Add(answer);
							break;
						default:
							//Do something if no case for the start element
							break;
					}
				}
			}
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteElementString("lecture", this.lecture);
			writer.WriteElementString("prof", this.prof);

			writer.WriteElementString("answerCount", this.answerCount.ToString());
			writer.WriteStartElement("answers");
			foreach (var element in this.answers)
			{
				writer.WriteStartElement("answerset");
				element.WriteXml(writer);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}
		#endregion
	}
}
