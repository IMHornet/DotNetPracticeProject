using PracticeProject.Core.Model;
using PracticeProject.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    class DataGenerator
    {
        public List<Car> GetData(int numberOfInstance)
        {
            var result = new List<Car>();
            Random random = new Random();

            for (int i = 0; i < numberOfInstance; i++)
            {
                var model = Helper.ModelVersion.GetKey(random.Next(0, Helper.ModelVersion.Count));
                var versionValues = Helper.ModelVersion.GetValues(model);
                var version = versionValues.GetValue(random.Next(0, versionValues.Length));
                var engine = Helper.Engine.ElementAt(random.Next(0, Helper.Engine.Length));
                var displacement = Helper.Displacement.ElementAt(random.Next(0, Helper.Displacement.Length));

                //get random data beetween 2015 and 2020
                TimeSpan timeSpan = new DateTime(2020, 12, 30) - new DateTime(2015, 1, 1);
                TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
                DateTime newData = new DateTime(2015, 1, 1) + timeSpan;

                result.Add(new Car()
                {
                    Model = (CarsModel)Enum.Parse(typeof(CarsModel), model),
                    Type = Helper.Type[random.Next(Helper.Type.Count())],
                    Engine = Helper.Engine[random.Next(Helper.Engine.Count())],
                    Name = version.ToString(),
                    Power = random.Next(10, 21) * 10,
                    MaxSpeed = random.Next(17, 22) * 10,
                    Milage = Helper.Displacement[random.Next(Helper.Displacement.Count())],
                    YearOfProduction = newData,
                });
            }
            return result;
        }
    }
 }
