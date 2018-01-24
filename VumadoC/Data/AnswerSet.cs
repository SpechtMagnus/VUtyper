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
	public class AnswerSet : IXmlSerializable
	{
		private string[] answers;


		public AnswerSet()
		{
			answers = new string[] { };
		}

		public AnswerSet(int answerCount)
		{
			answers = new string[answerCount];
		}

		#region Access values
		public string getStringValue(int index)
		{
			if (index < 0 || index >= answers.Length)
				throw new IndexOutOfRangeException();
			return answers[index];
		}

		public void setStringValue(int index, string value)
		{
			if (index < 0 || index >= answers.Length)
				throw new IndexOutOfRangeException();
			answers[index] = value;
		}

		public int getIntValue(int index, int defaultValue = 0)
		{
			if (index < 0 || index >= answers.Length)
				throw new IndexOutOfRangeException();
			if (answers[index] == null || answers[index] == "")
				return defaultValue;
			return int.Parse(answers[index]);
		}

		public void setIntValue(int index, int value)
		{
			if (index < 0 || index >= answers.Length)
				throw new IndexOutOfRangeException();
			answers[index] = value.ToString();
		}
		#endregion

		public bool isEmpty()
		{
			return (answers.All(e => e == null || e == ""));
		}

		#region Serialization
		public XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}

		public void ReadXml(XmlReader reader)
		{
			//this.answers = (string[])new XmlSerializer(typeof(string[])).Deserialize(reader);
			int i = 0;
			while (reader.Read())
			{
				if (reader.IsStartElement() && !reader.IsEmptyElement)
				{
					switch (reader.Name)
					{
						case "answer":
							reader.ReadStartElement();
							this.answers[i++] = reader.ReadContentAsString();
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
			//new XmlSerializer(typeof(string[])).Serialize(writer, this.answers);
			foreach(var answer in answers)
			{
				writer.WriteElementString("answer", answer);
			}
		}
		#endregion
	}
}
