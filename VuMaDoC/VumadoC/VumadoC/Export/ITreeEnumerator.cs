using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LatexExporter
{
    public interface ITreeEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Returns a new TreeEnumerator that enumerates over all children of the current DataIterator
        /// </summary>
        /// <returns>A new TreeEnumerator, null if current node has no children</returns>
        ITreeEnumerator<T> MoveIn();

		/// <summary>
		/// Creates a copy of this TreeEnumerator
		/// </summary>
		/// <returns></returns>
		ITreeEnumerator<T> Clone();
    }

	/// <summary>
	/// Offers a Nullobject for ITreeEnumerator
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class EmptyTreeIterator<T> : ITreeEnumerator<T>
	{
		public T Current => default(T);

		object IEnumerator.Current => default(T);

		public ITreeEnumerator<T> Clone() => this;

		public void Dispose() { }

		public ITreeEnumerator<T> MoveIn() => this;

		public bool MoveNext() => false;

		public void Reset() { }
	}
}
