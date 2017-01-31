package view;

import data.Questionaire;
import io.XmlSerializer;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

/**
 * Created by Magnus on 27.01.2017.
 */
public class ControllerMainView implements Initializable {

    @FXML
    private TextField lectureName;
    @FXML
    private TextField profName;

    @FXML
    private Button editButton;
    @FXML
    private Button saveButton;
    @FXML
    private Button loadButton;

    private Questionaire loadedQuestionaire;
    private boolean isSaved;

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        loadedQuestionaire = new Questionaire();
        isSaved = true;

        editButton.setOnAction(event -> {
            try {
                FXMLLoader loader = new FXMLLoader(getClass().getResource("inputView.fxml"));
                ControllerInputView inputController = new ControllerInputView(loadedQuestionaire);
                loader.setController(inputController);
                Parent root = loader.load();

                Stage inputView = new Stage();
                inputView.setTitle("Vumado");
                inputView.setOnCloseRequest(closeEvent -> {
                    inputController.onClose();
                });
                inputView.setScene(new Scene(root, 800, 600));

                inputView.show();
            }catch (IOException ex) {
                ex.printStackTrace();
            }
        });

        saveButton.setOnAction(event -> {
            //Save properties
            loadedQuestionaire.setLectureName(lectureName.getText());
            loadedQuestionaire.setProfName(profName.getText());

            //Select file
            FileChooser fileChooser = new FileChooser();
            fileChooser.setTitle("Save File");
            fileChooser.getExtensionFilters().add(
                    new FileChooser.ExtensionFilter("XML File", "*.xml")
            );
            File file = fileChooser.showSaveDialog(null);

            if(file != null) {
                XmlSerializer.writeQuestionaire(file, loadedQuestionaire);
            }
        });

        loadButton.setOnAction(event -> {

            //Select file
            FileChooser fileChooser = new FileChooser();
            fileChooser.setTitle("Open File");
            fileChooser.getExtensionFilters().add(
                    new FileChooser.ExtensionFilter("XML File", "*.xml")
            );
            File file = fileChooser.showOpenDialog(null);

            if(file != null) {
                XmlSerializer.read(file);
                /*this.loadedQuestionaire = XmlSerializer.readQuestionaire(file);
                lectureName.setText(loadedQuestionaire.getLectureName());
                profName.setText(loadedQuestionaire.getProfName());*/
            }
        });
    }
}
