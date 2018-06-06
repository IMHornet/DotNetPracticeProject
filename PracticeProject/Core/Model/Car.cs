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

        [XmlAttribute]
        public Guid Id { get; set; }
        [XmlAttribute]
        public CarsModel Model { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public CarsType Type { get; set; }
        [XmlAttribute]
        public CarsEngine Engine { get; set; }  
        [XmlAttribute]
        public int Power { get; set; }
        [XmlAttribute]
        public int  MaxSpeed { get; set; }
        [XmlAttribute]
        public double Milage { get; set; }
        [XmlAttribute]
        public DateTime YearOfProduction { get; set; }
        [XmlAttribute]
        public bool isAvailable { get; set; }
        [XmlNamespaceDeclarationsAttribute]
        public XmlSerializerNamespaces xmlns { get; set; }

        public Car() {

            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            this.xmlns = xmlSerializerNamespaces;

        }

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
                                 Model, Name, Type, Engine, Power, MaxSpeed, Milage, YearOfProduction.ToString("dd.MM.yyyy"), isAvailable);

        }

        public  string ConsoleView()
        {
            return string.Format(Resource.ConsoleFormat," ",
                                 Model, Name, Type, Engine, Power, MaxSpeed, Milage, YearOfProduction.ToString("dd.MM.yyyy"), isAvailable);
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
