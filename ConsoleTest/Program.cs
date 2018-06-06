using DataGenerator;
using PracticeProject.Core.Data;
using PracticeProject.Core.Enums;
using PracticeProject.Core.Manager;
using PracticeProject.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleTest
{

    class Program
    {
        static void Main(string[] args)
        {
            CarXmlManager xmlCarManager = new CarXmlManager();
            Car car = new Car()
            {
                Id = Guid.NewGuid(),
                Model = CarsModel.Toyota,
                Type = CarsType.Sedan,
                Engine = CarsEngine.Benzine,
                Name = "Avensis",
                Power = 150,
                MaxSpeed = 220,
                Milage = 5600,
                YearOfProduction = new DateTime(2018, 02, 20),
                isAvailable = true
            };

            xmlCarManager.AddCar(car);

            foreach (Car carr in xmlCarManager.GetCars())
            {
                Console.WriteLine(carr.ConsoleView());
            }

            //SearchFilter filter = new SearchFilter
            //{
            //    Model = "Honda",
            //    Engine = string.Empty,
            //    Year = string.Empty,
            //    dateFrom = new DateTime(2016, 01, 01)
            //};

            //foreach (Car car in xmlCarManager.GetCars())
            //{
            //    Console.WriteLine(car.ConsoleView());

            //}

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

