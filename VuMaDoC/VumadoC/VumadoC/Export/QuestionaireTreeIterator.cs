using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LatexExporter;
using LatexExporter;


namespace VumadoC.Export
{
	class QuestionaireTreeIterator : LatexExporter.ITreeEnumerator<string>
	{
		private Questionaire data;
		private QuestionaireTemplate structure;
		private int depth, qIndex, aIndex;

		public QuestionaireTreeIterator(Questionaire data, QuestionaireTemplate structure)
		{
			this.data = data;
			this.structure = structure;
			this.depth = 0;
			this.qIndex = -1;
			this.aIndex = -1;
		}

		private QuestionaireTreeIterator(Questionaire data, QuestionaireTemplate structure, int depth, int qIndex, int aIndex)
		{
			this.data = data;
			this.structure = structure;
			this.depth = depth;
			this.qIndex = qIndex;
			this.aIndex = aIndex;
		}

		public string Current
		{
			get {
				if (depth == 0 && qIndex == 0)
				{
					return data.Lecture;
				}
				else if (depth == 0 && qIndex == 1)
				{
					return data.Professor;
				}
				else if (depth == 1)
				{
					return structure[qIndex].Text;
				}
				else if (depth == 2)
				{
					return data.Get(aIndex).getStringValue(qIndex);
				}
				else
					return "";
			}
		}

		object IEnumerator.Current => Current;

		public ITreeEnumerator<string> Clone()
		{
			return new QuestionaireTreeIterator(data, structure, depth, qIndex, aIndex);
		}

		public void Dispose()
		{
			
		}

		public ITreeEnumerator<string> MoveIn()
		{
			if (depth == 0)
				return new QuestionaireTreeIterator(data, structure, depth + 1, -1, -1);
			else if (depth == 1)
				return new QuestionaireTreeIterator(data, structure, depth + 1, qIndex, -1);
			else
				throw new IndexOutOfRangeException();
		}

		public bool MoveNext()
		{
			if (depth == 0 && qIndex < 1)
				qIndex++;
			else if (depth == 1)
			{
				qIndex++;
				if (qIndex >= structure.Count)
					return false;
			}
			else if (depth == 2)
			{
				aIndex++;
				if (data.Get(aIndex) == null)
					return false;
			}
			else
				return false;
			return true;
		}

		public void Reset()
		{
			qIndex = -1;
			aIndex = -1;
		}
	}
}
