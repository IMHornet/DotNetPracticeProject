using PracticeProject.Core.Data;
using PracticeProject.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PracticeProject.Core.Manager
{
   public  class CarXmlManager
    {
        private string filePath { get; set; }
        private List<Car> Cars  { get; set; }
        private StreamReader streamReader { get; set; }
        private StreamWriter streamWriter { get; set; }
        private XmlStreamReader xmlStreamReader { get; set; }
        private List<string> searchFilter { get; set; }

        public CarXmlManager(string filePath)
        {
            this.filePath = filePath;
            Cars = new List<Car>();
            searchFilter = new List<string>();
        }

        //public List<Car> GetCars()
        //{
        //    Car car = null;

        //    Cars.Clear();
        //    using (Stream stream = new System.IO.FileStream(filePath, FileMode.Open))
        //    {
        //        using (xmlStreamReader = new XmlStreamReader(stream))
        //        {
        //            while (xmlStreamReader.Read())
        //            {
        //                car = xmlStreamReader.Deserialize();
        //                if (car != null)
        //                {
        //                    Cars.Add(car);
        //                }
        //            }
        //        }
        //    }
        //    return Cars;
        //}

        public List<Car> GetCars(SearchFilter filter)
        {
            
            Car car = null;

            Cars.Clear();
            using (Stream stream = new System.IO.FileStream(filePath, FileMode.Open))
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
