using PracticeProject.Core.Model;
using System;
using System.Collections.Generic;

namespace PracticeProject.Core.Interfaces
{
    interface ICarManager
    {
        void AddCar(Car car);
        List<Car> GetCarsFromFile();
        Car CarParseFromLine(string line);
        Car FindCarByID(string id);
        List<Car> FindCarByModel(string model);
        bool UpdateCarInFile(Car car);
        bool DeleteCarFromFile(Car car);
    }
}
