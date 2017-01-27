package view;

import data.AnswerSet;
import data.Questionaire;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;

import java.net.URL;
import java.util.ResourceBundle;

public class ControllerInputView implements Initializable {
    @FXML
    private Label questionLabelA;
    @FXML
    private Label questionLabelB;
    @FXML
    private Label questionLabelC;
    @FXML
    private Label questionLabelD;
    @FXML
    private Label questionLabelE;
    @FXML
    private Label questionLabelF;

    @FXML
    private TextArea questionAnswerA;
    @FXML
    private TextArea questionAnswerB;
    @FXML
    private TextArea questionAnswerC;
    @FXML
    private TextArea questionAnswerD;
    @FXML
    private TextArea questionAnswerE;
    @FXML
    private TextArea questionAnswerF;

    @FXML
    private Button prevButton;
    @FXML
    private Button nextButton;
    @FXML
    private Label countLabel;


    private Questionaire loadedQuestionaire;
    private int currentAnswerSet;


    public ControllerInputView(Questionaire questionaire) {
        this.loadedQuestionaire = questionaire;
        this.currentAnswerSet = questionaire.getAnswers().size() - 1;
    }

    public void displayAnswerSet() {
        AnswerSet answers = loadedQuestionaire.getAnswerSet(currentAnswerSet);

        questionAnswerA.setText(answers.getTextAnswer(0));
        questionAnswerB.setText(answers.getTextAnswer(1));
        questionAnswerC.setText(answers.getTextAnswer(2));
        questionAnswerD.setText(answers.getTextAnswer(3));
        questionAnswerE.setText(answers.getTextAnswer(4));
        questionAnswerF.setText(answers.getTextAnswer(5));

        countLabel.setText(currentAnswerSet + 1 + "/" + loadedQuestionaire.getAnswers().size());
    }

    public void updateAnswerSet() {
        AnswerSet answers = loadedQuestionaire.getAnswerSet(currentAnswerSet);

        answers.setTextAnswer(0, questionAnswerA.getText());
        answers.setTextAnswer(1, questionAnswerB.getText());
        answers.setTextAnswer(2, questionAnswerC.getText());
        answers.setTextAnswer(3, questionAnswerD.getText());
        answers.setTextAnswer(4, questionAnswerE.getText());
        answers.setTextAnswer(5, questionAnswerF.getText());
    }

    public void addAnswerSet() {
        loadedQuestionaire.addAnswerSet(new AnswerSet(6, 2));
    }


    @Override
    public void initialize(URL location, ResourceBundle resources) {
        if (currentAnswerSet == -1) {
            //New questionaire
            addAnswerSet();
            currentAnswerSet++;
            displayAnswerSet();
        } else {
            //Loaded questionaire
            displayAnswerSet();
        }

        nextButton.setOnAction(event -> {
            updateAnswerSet();
            if (loadedQuestionaire.getAnswers().get(currentAnswerSet).isEmpty()) {
                return;
            }
            if (currentAnswerSet >= loadedQuestionaire.getAnswers().size() - 1) {
                addAnswerSet();
            }
            currentAnswerSet++;
            displayAnswerSet();
        });

        prevButton.setOnAction(event -> {
            if (currentAnswerSet <= 0) {
                return;
            }
            updateAnswerSet();
            currentAnswerSet--;
            displayAnswerSet();
        });
    }

    public void onClose() {
        updateAnswerSet();
    }
}