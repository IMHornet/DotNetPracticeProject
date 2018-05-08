using PracticeProject.Core.Manager;
using PracticeProject.Core.Model;
using System;

namespace ConsoleTest
{

    class Program
    {
        static void Main(string[] args)
        {
            CarManager manager = new CarManager();
            manager.GetCarsFromFile();
            Car eCar = manager.FindCarByID("73dab7a0-7f8b-432b-b494-cb365ed92953");
            Console.WriteLine(eCar.Milage);
            eCar.StartEngine();
            eCar.Drive(3, 50);
            eCar.StopEngine();
            manager.UpdateCarInFile(eCar);
            Console.WriteLine(eCar.Milage);

            Console.ReadKey();
        }
    }
}
