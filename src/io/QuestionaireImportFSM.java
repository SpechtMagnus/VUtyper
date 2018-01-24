package io;

import data.Questionaire;
import sun.plugin.dom.exception.InvalidStateException;

import javax.xml.stream.events.XMLEvent;

/**
 * Created by Magnus on 06.04.2017.
 */
public class QuestionaireImportFSM {

	private IQuestionaireImportSate currentSate;
	private boolean stateChanged;
	private Questionaire questionaire;



	private boolean hasStateChanged() {
		if(stateChanged) {
			stateChanged = false;
			return true;
		}
		return false;
	}



	public void setCurrentSate(IQuestionaireImportSate state) {
		if(state == null)
			return;

		if(currentSate != null && !state.equals(currentSate)) {
			currentSate = state;
			stateChanged = true;
		}
	}

	public IQuestionaireImportSate getCurrentSate() {
		return currentSate;
	}



	public void setQuestionaire(Questionaire questionaire) {
		this.questionaire = questionaire;
	}

	public Questionaire getQuestionaire() {
		return questionaire;
	}



	public void readBeginEvent(XMLEvent event) throws InvalidStateException {
		//Reapeat until successfull or state didn't change
		while(!currentSate.readBeginEvent(event) && hasStateChanged());
	}

	public void readEndEvent(XMLEvent event) throws InvalidStateException {
		//Reapeat until successfull or state didn't change
		while(!currentSate.readEndEvent(event) && hasStateChanged());
	}

	public void readCharactersEvent(XMLEvent event) throws InvalidStateException {
		//Reapeat until successfull or state didn't change
		while(!currentSate.readCharactersEvent(event) && hasStateChanged());
	}
}
