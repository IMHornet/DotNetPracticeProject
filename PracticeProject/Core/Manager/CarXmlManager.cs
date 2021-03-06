﻿using PracticeProject.Core.Data;
using PracticeProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PracticeProject.Core.Manager
{
    public class CarXmlManager
    {

        private List<Car> Cars { get; set; }
        private StreamReader streamReader { get; set; }
        private StreamWriter streamWriter { get; set; }
        private XmlStreamReader xmlStreamReader { get; set; }
        private string XmlPath = ConfigurationManager.AppSettings["XmlPath"];
        private List<string> searchFilter { get; set; }

        public CarXmlManager()
        {
            Cars = new List<Car>();
            searchFilter = new List<string>();
        }

        public List<Car> GetCars()
        {
            Car car = null;

            Cars.Clear();
            using (Stream stream = new System.IO.FileStream(XmlPath, FileMode.Open))
            {
                using (xmlStreamReader = new XmlStreamReader(stream))
                {
                    while (xmlStreamReader.Read())
                    {
                        string tmp = xmlStreamReader.ReadXmlContentAsString();
                        car = xmlStreamReader.Deserialize(tmp);
                        if (car != null)
                        {
                            Cars.Add(car);
                        }
                    }
                }
            }
            return Cars;
        }

        public List<Car> GetCars(SearchFilter filter)
        {

            Car car = null;

            Cars.Clear();
            using (Stream stream = new System.IO.FileStream(XmlPath, FileMode.Open))
            {
                using (xmlStreamReader = new XmlStreamReader(stream))
                {

                    while (xmlStreamReader.Read())
                    {
                        var tmp = xmlStreamReader.ReadXmlContentAsString();
                        if (tmp.Contains(filter.Model)
                        &&
                        tmp.Contains(filter.Year)
                        &&
                        tmp.Contains(filter.Engine)
                        &&
                        IsCarInDateRange(tmp, filter.dateFrom, filter.dateTo)
                        )
                        {
                            car = xmlStreamReader.Deserialize(tmp);
                            if (car != null)
                            {
                                Cars.Add(car);
                            }
                        }
                    }
                }
            }
            return Cars;
        }

        public Car FindCarById(string id)
        {
            Car car = null;
            using (Stream stream = new System.IO.FileStream(XmlPath, FileMode.Open))
            {
                using (xmlStreamReader = new XmlStreamReader(stream))
                {
                    while (xmlStreamReader.Read())
                    {
                        var tmp = xmlStreamReader.ReadXmlContentAsString();
                        if (tmp.Contains(id))
                        {
                            car = xmlStreamReader.Deserialize(tmp);
                            if (car != null)
                            {
                                return car;
                            }
                        }
                    }
                }

            }

            return null;
        }

        public bool AddCar(Car car)
        {
            byte[] endtag = System.Text.Encoding.UTF8.GetBytes("</Cars>");
            using (Stream stream = new System.IO.FileStream(XmlPath, FileMode.Open))
            {

                stream.Seek(-9, System.IO.SeekOrigin.End);
                var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true, IndentChars = "\t" };
                XmlWriter writer = XmlWriter.Create(stream, settings);
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(Car), string.Empty);

                serializer.Serialize(stringwriter, car, car.xmlns);
                var tmp = stringwriter.ToString();
                Regex rgx = new Regex(@"<\?xml.*>\r\n");

                var cleanCar = rgx.Replace(tmp, "\t");
                writer.WriteRaw("\r\n" + cleanCar + "\r\n" + System.Text.Encoding.UTF8.GetString(endtag));// START CHILD
                writer.Flush();//END CHILD

            }
            return true;
        }

        public bool DeleteCar(Car car)
        {
            XDocument xdoc = XDocument.Load(XmlPath);
            var uCar = xdoc.Descendants("Car").Single(c => c.Attribute("Id").Value.Equals(car.Id.ToString()));
            uCar.Remove();
            xdoc.Save(XmlPath);
            return true;
        }

        public bool UpdateCar(Car car)
        {

            var indexPosition = GetCarPosition(car);

            using (Stream stream = new FileStream(XmlPath, FileMode.Open))
            {
                stream.Seek(indexPosition, SeekOrigin.Begin);

                var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true, IndentChars = "\t" };

                XmlWriter writer = XmlWriter.Create(stream, settings);
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(Car), string.Empty);

                serializer.Serialize(stringwriter, car, car.xmlns);
                var tmp = stringwriter.ToString();
                Regex rgx = new Regex(@"<\?xml.*>\r\n");

                var cleanCar = rgx.Replace(tmp, "\t");
                writer.WriteRaw(cleanCar);
                writer.Flush();

            }
            return true;
        }

        public long GetCarPosition(Car car)
        {
            long result = 0;
            byte[] carBytes = null;

            using (Stream stream = new FileStream(XmlPath, FileMode.Open))
            {
                using (xmlStreamReader = new XmlStreamReader(stream))
                {
                    while (xmlStreamReader.Read())
                    {
                        string tmp = xmlStreamReader.ReadXmlContentAsString();
                        carBytes = System.Text.Encoding.UTF8.GetBytes(tmp);
                        result =  result + carBytes.Length;

                        if (tmp.Contains(car.Id.ToString()))
                        {
                            break;
                        }
                    }                    
                }
            }
                return result-82;
        }

        private bool IsCarInDateRange(string carLine, DateTime? dateFrom, DateTime? dateTo)
            {

                var carDateString = string.Empty;
                var carDate = DateTime.Now;
                var regEx = new Regex(Constants.Constants.regExDatePatternXml);
                carDateString = regEx.Match(carLine).Value;

                return ((DateTime.TryParse(carDateString, out carDate))
                        &&
                         (dateFrom.HasValue && carDate >= dateFrom || !dateFrom.HasValue)
                        &&
                        (dateTo.HasValue && carDate <= dateTo || !dateTo.HasValue));
            }


       
    }
}
