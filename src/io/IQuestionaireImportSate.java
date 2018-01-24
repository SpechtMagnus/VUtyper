package io;

import sun.plugin.dom.exception.InvalidStateException;

import javax.xml.stream.events.XMLEvent;

/**
 * Created by Magnus on 06.04.2017.
 */
public interface IQuestionaireImportSate {
	/**
	 * Reads an event containing a beginning element
	 *
	 * @param event The processed xml event
	 * @return Wether or not the current event was successfully processed
	 * @throws InvalidStateException
	 */
	boolean readBeginEvent(XMLEvent event) throws InvalidStateException;

	/**
	 * Reads an event containing a closing element
	 *
	 * @param event The processed xml event
	 * @return Wether or not the current event was successfully processed
	 * @throws InvalidStateException
	 */
	boolean readEndEvent(XMLEvent event) throws InvalidStateException;

	/**
	 * Reads an event containing a char sequence
	 *
	 * @param event The processed xml event
	 * @return Wether or not the current event was processed
	 * @throws InvalidStateException
	 */
	boolean readCharactersEvent(XMLEvent event) throws InvalidStateException;
}
