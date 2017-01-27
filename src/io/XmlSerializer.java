package io;

import data.Questionaire;

import java.beans.XMLDecoder;
import java.beans.XMLEncoder;
import java.io.*;

/**
 * Created by Magnus on 27.01.2017.
 */
public class XmlSerializer {
    public static void writeQuestionaire(File file, Questionaire questionaire) {
        XMLEncoder encoder = null;

        try{
            encoder=new XMLEncoder(new BufferedOutputStream(new FileOutputStream(file)));
            encoder.writeObject(questionaire);
        }catch(FileNotFoundException fileNotFound){
            System.err.println("ERROR: While Creating or Opening the File dvd.xml");
        } finally {
            encoder.close();
        }
    }

    public static Questionaire readQuestionaire(File file) {
        XMLDecoder decoder;
        Questionaire out = null;

        try {
            decoder=new XMLDecoder(new BufferedInputStream(new FileInputStream(file)));
            out =(Questionaire) decoder.readObject();
        } catch (FileNotFoundException e) {
            System.err.println("ERROR: File dvd.xml not found");
        }

        return out;
    }
}
