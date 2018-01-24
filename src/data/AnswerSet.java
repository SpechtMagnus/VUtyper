package data;

/**
 * Created by Magnus on 27.01.2017.
 */
public class AnswerSet {

    public static final int NO_CHECKBOX_SELECTED = -1;

    private String[] textAnswers;
    private int[] checkAnswers;

    public AnswerSet() {

    }

    public AnswerSet(int textAnswerCount, int checkAnswerCount) {
        textAnswers = new String[textAnswerCount];
        checkAnswers = new int[checkAnswerCount];

        for(int i = 0; i < textAnswers.length; i++) {
            textAnswers[i] = "";
        }
        for(int i = 0; i < checkAnswers.length; i++) {
            checkAnswers[i] = NO_CHECKBOX_SELECTED;
        }
    }

    public String getTextAnswer(int index) {
        return textAnswers[index];
    }

    public int getIntAnswer(int index) {
        return checkAnswers[index];
    }

    public void setTextAnswer(int index, String answer) {
        if(index < 0 || index >= textAnswers.length) {
            return;
        }
        textAnswers[index] = answer;
    }

    public void setCheckAnswer(int index, int checkedIndex) throws IllegalArgumentException {
        if(index < 0 || index >= checkAnswers.length) {
            throw new IllegalArgumentException("The selected checkbox answer does not exist.");
        }
        checkAnswers[index] = checkedIndex;
    }

    public void setTextAnswers(String[] textAnswers) {
        this.textAnswers = textAnswers;
    }

    public void setCheckAnswers(int[] checkAnswers) {
        this.checkAnswers = checkAnswers;
    }

    public String[] getTextAnswers() {
        return this.textAnswers;
    }

    public int[] getCheckAnswers() {
        return this.checkAnswers;
    }

    public boolean isEmpty() {
        for(int i = 0; i < textAnswers.length; i++) {
            if(!textAnswers[i].equals("")) return false;
        }
        for(int i = 0; i < checkAnswers.length; i++) {
            if(checkAnswers[i] != NO_CHECKBOX_SELECTED) return false;
        }
        return true;
    }

    public String[] serializeAnswers() {
        String[] result = new String[textAnswers.length + checkAnswers.length];

        for(int i = 0; i < textAnswers.length; i++) {
            result[i] = textAnswers[i];
        }

        for(int j = 0; j < checkAnswers.length; j++) {
            result[textAnswers.length + j] = String.valueOf(checkAnswers[j]);
        }

        return result;
    }

    public void deserializeAnswers(String[] values) throws IllegalArgumentException {
        try {
            for(int i = 0; i < textAnswers.length; i++) {
                setTextAnswer(i, values[i]);
            }

            for(int j = 0; j < checkAnswers.length; j++) {
                setCheckAnswer(j, Integer.valueOf(values[textAnswers.length + j]));
            }
        } catch (IndexOutOfBoundsException ex) {
            throw new IllegalArgumentException("The number of deserialized values doesn't match the number of required answers for this type of questionaire.");
        } catch (NumberFormatException ex) {
            throw new IllegalArgumentException("The number of deserialized values doesn't match the number of required answers for this type of questionaire or some checkbox answers are formatted the wrong way.");
        }
    }
}
