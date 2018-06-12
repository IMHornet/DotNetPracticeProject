using DataGenerator;
using PracticeProject.Core.Data;
using PracticeProject.Core.Enums;
using PracticeProject.Core.Manager;
using PracticeProject.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using static DelegateExamples.Calculator;

namespace ConsoleTest
{

    class Program
    {
        //методы для делегата
        private static double Add(double x, double y)
        {   
                    return x+y;

        }

        private static double Diff(double x, double y)
        {
            return x - y;
        }

        private static double Div(double x, double y)
        {
            //return x != 0 ? x/y :0;
            return x / y;
        }

        private static double Multiply(double x, double y)
        {
            return x *y;
        }

        static void Main(string[] args)
        {


            Operation add = new Operation(Add);
            double resultAdd = add.Invoke(2, 2);
            Console.WriteLine(resultAdd);

            Operation div = new Operation(Div);
            double resultDiv = div.Invoke(2, 2);
            Console.WriteLine(resultDiv);

            //CarXmlManager xmlCarManager = new CarXmlManager();
            //Console.WriteLine(xmlCarManager.GetCars().Count);
            //Car car = xmlCarManager.FindCarById("abd4deaf-3212-4d98-bc8f-e1ec1e9443fa");
            //car.Name = "X7";
            //xmlCarManager.UpdateCar(car);
            //Console.WriteLine(car.ConsoleView());
            //xmlCarManager.DeleteCar(car);
            //Console.WriteLine(xmlCarManager.GetCars().Count);
            //Console.WriteLine(car.ConsoleView());


            //Car car = xmlCarManager.FindCarById("a8bc7152-9ae5-4c4a-8fe8-f9e30f06647e");
            //Console.WriteLine(car.ConsoleView());

            //Console.WriteLine(xmlCarManager.GetCars().Count);
            //Car car = new Car()
            //{
            //    Id = Guid.NewGuid(),
            //    Model = CarsModel.Toyota,
            //    Type = CarsType.Hatchback,
            //    Engine = CarsEngine.Benzine,
            //    Name = "Land cruzer",
            //    Power = 112,
            //    MaxSpeed = 220,
            //    Milage = 10000,
            //    YearOfProduction = new DateTime(2010, 03, 20),
            //    isAvailable = true
            //};

            //xmlCarManager.AddCar(car);

            //foreach (Car carr in xmlCarManager.GetCars())
            //{
            //    Console.WriteLine(carr.ConsoleView());
            //}

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

