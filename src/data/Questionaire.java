package data;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Magnus on 27.01.2017.
 */
public class Questionaire {
    private String lectureName;
    private String profName;

    private List<AnswerSet> answers;

    public Questionaire() {
        this.lectureName = "";
        this.profName = "";

        this.answers = new ArrayList<>();
    }

    public Questionaire(String lectureName, String profName) {
        this.lectureName = lectureName;
        this.profName = profName;

        this.answers = new ArrayList<>();
    }

    public String getLectureName() {
        return this.lectureName;
    }

    public String getProfName() {
        return this.profName;
    }

    public void setLectureName(String lectureName) {
        this.lectureName = lectureName;
    }

    public void setProfName(String profName) {
        this.profName = profName;
    }

    public AnswerSet getAnswerSet(int index) {
        return answers.get(index);
    }

    public void setAnswerSet(int index, AnswerSet answerSet) {
        this.answers.set(index, answerSet);
    }

    public void addAnswerSet(AnswerSet answerSet) {
        this.answers.add(answerSet);
    }

    public List<AnswerSet> getAnswers() {
        return answers;
    }

    public void setAnswers(List<AnswerSet> answers) {
        this.answers = answers;
    }
}
