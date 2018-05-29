using PracticeProject.Core.Enums;
using PracticeProject.Core.Manager;
using System;
using System.Xml.Serialization;

namespace PracticeProject.Core.Model
{
    [Serializable]
    public class Car : ICar
    {
        public const string XmlNameElement = "Car";

        [XmlElement(Order = 2)]
        public CarsModel Model { get; set; }
        [XmlElement(Order = 3)]
        public CarsType Type { get; set; }
        [XmlElement(Order = 4)]
        public CarsEngine Engine { get; set; }
        [XmlElement(Order = 1)]
        public Guid Id { get; set; }
        [XmlElement(Order = 5)]
        public string Name { get; set; }
        [XmlElement(Order = 6)]
        public int Power { get; set; }
        [XmlElement(Order = 7)]
        public int  MaxSpeed { get; set; }
        [XmlElement(Order = 8)]
        public double Milage { get; set; }
        [XmlElement(Order = 9)]
        public DateTime YearOfProduction;
        [XmlElement(Order = 10)]
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

        public override string ToString()
        {
            return string.Format(Resource.ToStringFormat, Constants.Constants.delimetr, Id,
                                 Model, Type, Engine, Name, Power, MaxSpeed, Milage, YearOfProduction.ToString("dd.MM.yyyy"), isAvailable);
        }

        public  string ConsoleView()
        {
            return string.Format(Resource.ConsoleFormat," ",
                                 Model, Type, Engine, Name, Power, MaxSpeed, Milage, YearOfProduction.ToString("dd.MM.yyyy"), isAvailable);
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
