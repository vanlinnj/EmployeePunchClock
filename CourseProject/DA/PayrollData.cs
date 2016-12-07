using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CourseProject
{
    public static class PayrollData
    {
        

        public static void write(List<Punch> punchData, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("   ");

            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            xmlOut.WriteStartDocument();

            xmlOut.WriteStartElement("PunchesReport");

            foreach (Punch punch in punchData)
            {
                xmlOut.WriteStartElement("Punch");
                xmlOut.WriteElementString("PunchID", Convert.ToString(punch.PunchID));
                xmlOut.WriteElementString("EmployeeID", Convert.ToString(punch.EmployeeID));
                xmlOut.WriteElementString("PunchType", Convert.ToString(punch.PunchType));
                xmlOut.WriteElementString("DateTime", Convert.ToString(punch.DateTime));
                xmlOut.WriteEndElement();
            }
            xmlOut.WriteEndElement();
            xmlOut.WriteEndDocument();

            xmlOut.Close();

        }
    }
}
