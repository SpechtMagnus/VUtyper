package io;

import java.io.*;
import java.util.Iterator;

/**
 * Created by Magnus on 07.06.2017.
 */
public class SimpleDeserializer implements Iterator<String[]>{

	private static final String seperator = ";";

	private BufferedReader reader;
	private String nextLine;

	public SimpleDeserializer(File file) {
		try {
			reader = new BufferedReader(new FileReader(file));
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
	}

	@Override
	public boolean hasNext() {
		try {
			nextLine = reader.readLine();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return nextLine == null;
	}

	@Override
	public String[] next() {
		if(nextLine == null && !hasNext())
			return null;
		return nextLine.split(seperator);
	}
}
