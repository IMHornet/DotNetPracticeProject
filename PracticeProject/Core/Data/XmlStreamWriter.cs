using PracticeProject.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PracticeProject.Core.Data
{
    public class XmlStreamWriter : IDisposable
    {
        private string xmlNameSpace;
        protected XmlWriter xmlWriter;

       public void Begin(Stream xmlStream,string rootElementName,string xmlNameSpace,Dictionary<string,string> attributes)
       {
            this.xmlNameSpace = xmlNameSpace;
            var writerSettings = new XmlWriterSettings { Indent = true, IndentChars = "\t" };
            xmlWriter = XmlWriter.Create(xmlStream, writerSettings);
            xmlWriter.WriteStartElement(rootElementName,xmlNameSpace);

            foreach (var attribute in attributes)
            {
                xmlWriter.WriteAttributeString(attribute.Key, attribute.Value);
            }

        }

        /// Writes the passed data element.
        /// </summary>
        /// <param name="carElement">The data element to be written.</param>
        public void WriteElement(Car carElement)
        {
            Serialize(carElement);
        }

        public void Finish()
        {
            xmlWriter.WriteEndElement();
            xmlWriter.Close();

        }

        protected void Serialize(Car carElement)
        {
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            var xmlSerializer = new XmlSerializer(carElement.GetType());
            xmlSerializer.Serialize(xmlWriter, carElement, xmlSerializerNamespaces);
        }

        public void Dispose()
        {
            xmlWriter.Dispose();
        }
    }
}
