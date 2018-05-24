using PracticeProject.Core.Manager;
using PracticeProject.Core.Model;
using DataGenerator;
using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using PracticeProject.Core.Constants;

namespace ConsoleTest
{

    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            using (Stream fileStream = new System.IO.FileStream(@"D:\MyProgrammingRepository\C#REPOSITORY\PracticeProject\DotNetPracticeProject\PracticeProject\Resources\CarsFile.xml", FileMode.Create))
            {
                var xmlStreamWriter = new XmlStreamWriter();
                xmlStreamWriter.Begin(fileStream, "Cars", "http://www.develop.com/car", new Dictionary<string, string>());

                foreach (var item in generator.GetData(10))
                {
                    xmlStreamWriter.WriteElement(item);
                }
                xmlStreamWriter.Finish();
                Console.WriteLine("DONE!!");
            }


                //CarManager carManager = new CarManager();
                //SearchFilter filter = new SearchFilter()
                //{
                //    Model = "Mercedes",
                //    Engine = "Benzin",
                //    Year = "2018"
                //};

                //carManager.FindCarByParams(filter);

                //foreach (Car car in carManager.GetCarCollection()) {
                //    Console.WriteLine(car.ConsoleView());
                //}

                Console.ReadKey();
        }
    }
}
