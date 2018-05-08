using PracticeProject.Core.Enums;
using PracticeProject.Core.Interfaces;
using PracticeProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace PracticeProject.Core.Manager
{
    public class CarManager : ICarManager
    {
        private List<Car> Cars;
        private StreamReader sr;
        private StreamWriter sw;
        string  Path = ConfigurationManager.AppSettings["Path"];

        public CarManager() {
            Cars = new List<Car>();
        }

        public List<Car> GetCarCollection() {
            return Cars;
        }

        public void AddCar(Car car) {
            try {
                using (sw = new StreamWriter(Path, true)) {
                    sw.WriteLine(car.ToFileFormat());
                }
            } catch (IOException ex) {
                throw ex;
            }
        }

        public List<Car> GetCarsFromFile() {
            string line = string.Empty;
            Car car = null;
            Cars.Clear();
            try {
                using (sr = new StreamReader(Path)) {

                    while ((line = sr.ReadLine()) != null)
                    {
                        car = CarParseFromLine(line);
                        if (car != null)
                        {
                            Cars.Add(car);
                        }
                    }
                }
            } catch (IOException ex) {
                throw ex;
            }
                         return Cars;
        }

        public Car CarParseFromLine(string line)
        {
            string[] entries;
            Car car = null;
            entries = line.Split(Constants.Constants.delimetr);

            if (entries.Length < Constants.Constants.entries)
            {
                    return null;
            }

            car = new Car()
            {
                Id = Guid.Parse(entries[0]),
                Model = (CarsModel)Enum.Parse(typeof(CarsModel), entries[1]),
                Type = (CarsType)Enum.Parse(typeof(CarsType), entries[2]),
                Engine = (CarsEngine)Enum.Parse(typeof(CarsEngine), entries[3]),
                Name = entries[4],
                Power = int.Parse(entries[5]),
                MaxSpeed = int.Parse(entries[6]),
                Milage = double.Parse(entries[7]),
                YearOfProduction = DateTime.Parse(entries[8]),
                isAvailable = bool.Parse(entries[9])
            };
            return car;
        }

        public Car FindCarByID(string id)
        {
            Guid iD = Guid.Parse(id);
            string line = string.Empty;
            Car car = null;
            try
            {
                using (sr = new StreamReader(Path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        car = CarParseFromLine(line);
                        if (car.Id == iD)
                        {
                            return car;
                        }
                    }
                }
            } catch (IOException ex)
                {
                    throw ex;
                }
            return null;
        }

        public bool UpdateCarInFile(Car car)
        {
            try
            {
                using (sw = new StreamWriter(Path))
                {
                    foreach (Car eCar in Cars)
                    {
                        if (eCar.Id != car.Id)
                        {
                            sw.WriteLine(eCar.ToFileFormat());
                        }
                          else
                          {
                            sw.WriteLine(car.ToFileFormat());
                          }
                    }
                }
                return true;

            } catch (IOException ex)
                {
                    throw ex;
                }
        }

        public bool DeleteCarFromFile(Car car)
        {
            try
            {
                using (sw = new StreamWriter(Path))
                {
                    foreach (Car rCar in Cars)
                    {
                        if (rCar.Id != car.Id)
                        {
                            sw.WriteLine(rCar.ToFileFormat());
                        }
                    }
                }
                return true;
            } catch (IOException ex)
              {
                throw ex;
              }
        }
    }
}
