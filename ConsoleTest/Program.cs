using DataGenerator;
using PracticeProject.Core.Data;
using PracticeProject.Core.Manager;
using PracticeProject.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleTest
{

    class Program
    {
        static void Main(string[] args)
        {
            CarXmlManager xmlCarManager = new CarXmlManager(@"D:\MyProgrammingRepository\C#REPOSITORY\PracticeProject\DotNetPracticeProject\PracticeProject\Resources\CarsFile.xml");

            SearchFilter filter = new SearchFilter
            {
                Model = "Honda",
                Engine = string.Empty,
                Year = string.Empty,
                dateFrom = new DateTime(2016, 01, 01)
            };

            Console.WriteLine(xmlCarManager.GetCars(filter).Count);

            foreach (Car car in xmlCarManager.GetCars(filter))
            {
                Console.WriteLine(car.ConsoleView());

            }

            //Generator generator = new Generator();
            //using (Stream fileStream = new System.IO.FileStream(@"D:\MyProgrammingRepository\C#REPOSITORY\PracticeProject\DotNetPracticeProject\PracticeProject\Resources\CarsFile.xml", FileMode.Create))
            //{
            //    var xmlStreamWriter = new XmlStreamWriter();
            //    xmlStreamWriter.Begin(fileStream, "Cars", "http://www.develop.com/car", new Dictionary<string, string>());
            //    foreach (var item in generator.GetData(10))
            //    {
            //        xmlStreamWriter.WriteElement(item);
            //    }
            //    xmlStreamWriter.Finish();
            //    Console.WriteLine("DONE!!");
            //}

            Console.ReadKey();

        }
     }
 }

