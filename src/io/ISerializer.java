package io;

/**
 * Created by Magnus on 07.06.2017.
 */
public interface ISerializer {

	enum MetaType {
		Lecture(0),
		Professor(1);

		private int index;
		private static int maxIndex = Integer.MIN_VALUE;

		MetaType(int index) {
			this.index = index;
		}

		static {
			for(MetaType t : MetaType.values()) {
				maxIndex = Integer.max(t.getIndex(), maxIndex);
			}
		}

		public int getIndex() {
			return this.index;
		}

		public static int getMaxIndex() {
			return maxIndex;
		}
	}

	void setMetaField(MetaType type, String value);
	String getMetaField(MetaType type);

	void addAnswerSet(String[] answerSet);
	String[] nextAnswerSet
}
