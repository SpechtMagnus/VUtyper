package io;

import data.Questionaire;
import org.w3c.dom.Document;
import org.w3c.dom.Node;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.stream.*;
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

    public static void read(File file) {
        try {
            DocumentBuilderFactory xmlFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder xmlBuilder = xmlFactory.newDocumentBuilder();
            Document xmlDoc = xmlBuilder.parse(file);
            Node currentNode;

            //Normalize something...?
            xmlDoc.getDocumentElement().normalize();
            System.out.println(xmlDoc.getDocumentElement().getNodeName());

            //Create questionaire
            currentNode = xmlDoc.getDocumentElement().getFirstChild().getNextSibling();
            String lecture = currentNode.getNodeName() + "." + currentNode.getTextContent();
            currentNode = currentNode.getNextSibling().getNextSibling();
            String prof = currentNode.getNodeName() + "." + currentNode.getTextContent();

            System.out.println(lecture + " - " + prof);
        } catch(Exception ex) {
            ex.printStackTrace();
        }
    }

    public static void write(File file) {
        try {
            XMLOutputFactory xmlInFac = XMLOutputFactory.newInstance();
            //XMLStreamWriter xmlWriter = xmlInFac.createXMLEventWriter(file);
        } catch(Exception ex) {
            ex.printStackTrace();
        }
    }
}
