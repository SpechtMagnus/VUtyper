using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VumadoC
{
	public class QuestionaireTemplate : IEnumerable<QuestionaireTemplate.QuestionTemplate>, IXmlSerializable
	{
		private List<QuestionTemplate> structure;

		public QuestionaireTemplate()
		{
			this.structure = new List<QuestionTemplate>();
		}

		public QuestionaireTemplate(List<QuestionTemplate> structure)
		{
			this.structure = structure;
		}

		public QuestionTemplate this[int i]
		{
			get { return this.structure[i]; }
		}

		public IEnumerator<QuestionTemplate> GetEnumerator()
		{
			return this.structure.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.structure.GetEnumerator();
		}

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
						case "Structure":
							reader.ReadStartElement();
							this.structure = (List<QuestionTemplate>)new XmlSerializer(typeof(List<QuestionTemplate>)).Deserialize(reader);
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
			foreach(var item in this.structure)
			{
				writer.WriteStartElement("Structure");
				new XmlSerializer(typeof(List<QuestionTemplate>)).Serialize(writer, this.structure);
				writer.WriteEndElement();
			}
		}
		#endregion

		public int Count { get { return this.structure.Count; } }

		public enum QuestionType
		{
			TextQuestion,
			ChoiceQuestion
		}

		public class QuestionTemplate
		{
			public string Text { get; set; }
			public QuestionType Type { get; set; }
			public int Info { get; set; }
			public bool AllowPrint { get; set; }
		}
	}
}
