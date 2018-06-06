using PracticeProject.Core.Model;
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace PracticeProject.Core.Data
{
    public class XmlStreamReader:IDisposable
    {
        private XmlReader xmlReader;
        public const string xsdFileName = "Data.xsd";

        public XmlStreamReader(Stream xmlStream)
        {
            var resourceName = string.Format("{0}.{1}", GetType().Namespace, xsdFileName);
            var xsdStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

            var xmlReaderSettings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
            };

            xmlReaderSettings.Schemas.Add(null, XmlReader.Create(xsdStream));
            xmlReaderSettings.ValidationEventHandler += ValidationEventHandler;

            xmlReader = XmlReader.Create(xmlStream, xmlReaderSettings);
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }

        }



        public bool Read()
        {
            while (xmlReader.Read())
            {
                if (xmlReader.Name == Car.XmlNameElement)
                {
                    return true;
                }
            }
            return false;
        }

        public string ReadXmlContentAsString()
        {
            return xmlReader.ReadOuterXml();
        }

        public void Finish()
        {
            xmlReader.Close();
        }

        public void Dispose()
        {
            xmlReader.Dispose();
        }

        public Car Deserialize(string xmlCar)
        {
            var xmlSerializer = new XmlSerializer(typeof(Car));
                using (TextReader reader = new StringReader(xmlCar))
                {
                    return (Car)xmlSerializer.Deserialize(reader);
                }
            }
    }
}
