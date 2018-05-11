using PracticeProject.Core.Manager;
using PracticeProject.Core.Model;
using DataGenerator;
using System;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace ConsoleTest
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars;
            Generator generator = new Generator();
            cars = generator.GetData(10);
            CsvStreamWriter writer = new CsvStreamWriter(@"D:\MyProgrammingRepository\C#REPOSITORY\test.csv", ";");

            foreach (Car car in cars) {
                writer.WriteLine(car.ToFileFormat());
                writer.Flush();
            }
            Console.ReadKey();
        }
    }
}
