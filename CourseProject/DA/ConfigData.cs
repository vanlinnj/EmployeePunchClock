using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace program9
{
    class ConfigData
    {
        private static string path = "ConfigInfo.xml";
        public static Config read()
        {
            //create the XmlReaderSettings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            //create the XmlReader object
            XmlReader xmlIn = XmlReader.Create(path, settings);

            Config currentData = new Config();

            //read past all nodes to the first node
            if (xmlIn.ReadToDescendant("Company"))
            {
                   xmlIn.ReadStartElement("Company");
                   currentData.Name = xmlIn.ReadElementContentAsString();
                   currentData.Address = xmlIn.ReadElementContentAsString();
                   currentData.City = xmlIn.ReadElementContentAsString();
                   currentData.State = xmlIn.ReadElementContentAsString();
                   currentData.Zip = xmlIn.ReadElementContentAsString();
                   currentData.Phone = xmlIn.ReadElementContentAsString();
            }
            return currentData;
                
            
        }

        public static void write(Config saveData)
        {

            //create the XMLWriterSettings object
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            //create XmlWriter object
            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            //write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Configuration");

            //write each entry object to the xml file
            xmlOut.WriteStartElement("Company");
            xmlOut.WriteElementString("Name", saveData.Name);
            xmlOut.WriteElementString("Address", saveData.Address);
            xmlOut.WriteElementString("City", saveData.City);
            xmlOut.WriteElementString("State", saveData.State);
            xmlOut.WriteElementString("Zip", saveData.Zip);
            xmlOut.WriteElementString("Phone", saveData.Phone);
            xmlOut.WriteEndElement();

            //write end tag for object
            xmlOut.WriteEndElement();

            //close the XmlWriter object
            xmlOut.Close();

        }
    }
}
