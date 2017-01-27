package view;

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


    @Override
    public void initialize(URL location, ResourceBundle resources) {
        
    }
}