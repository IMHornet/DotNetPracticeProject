using PracticeProject.Core.Enums;
using PracticeProject.Core.Manager;
using System;

namespace PracticeProject.Core.Model
{
    public class Car:ICar
    {
        public CarsModel Model { get; set; }
        public CarsType Type { get; set; }
        public CarsEngine Engine { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int    Power { get; set; }
        public int  MaxSpeed { get; set; }
        public double Milage { get; set; }
        public DateTime YearOfProduction;
        public bool isAvailable { get; set; }

        public Car() { }

        public Car(CarsModel model,CarsType type,CarsEngine engine, string name,
                   int power,int maxSpeed,double milage,DateTime year,bool available)
        {
            Id = Guid.NewGuid();
            Model = model;
            Type = type;
            Engine = engine;
            Name = name;
            Power = power;
            MaxSpeed = maxSpeed;
            Milage = milage;
            YearOfProduction = year;
            isAvailable = available;
        }

        public  string ToFileFormat()
        {
            return string.Format(Resource.CarFileFormat, Constants.Constants.delimetr, Id,
                                 Model, Type, Engine, Name, Power, MaxSpeed, Milage,YearOfProduction.ToShortDateString(),isAvailable);
        }

        public override string ToString()
        {
            return string.Format(Resource.ToStringFormat, Constants.Constants.newline,
                                 Model, Type, Engine, Name, Power, MaxSpeed, Milage, YearOfProduction.ToShortDateString(), isAvailable);
        }

        public double Drive(double timeInHour, int speed)
        {
            double s = speed * timeInHour;
            return Milage += s;
        }

        public string StartEngine()
        {
            return string.Format(Resource.StartEngine);
        }

        public string StopEngine()
        {
            return string.Format(Resource.StopEngine);
        }
    }
}
