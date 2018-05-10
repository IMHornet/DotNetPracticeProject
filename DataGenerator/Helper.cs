using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeProject.Core.Enums;

namespace DataGenerator
{
    public class Helper
    {
        public static readonly NameValueCollection ModelVersion = new NameValueCollection()
        {
                {"Mercedes","S Class"},{ "BMW","X5"},{"Honda","Civic"},
                { "Toyota","CRV"},{ "KIA","Sportage"},{"Opel","Vectra C"}
        };
            public static readonly CarsEngine[] Engine = {CarsEngine.Benzine,CarsEngine.Electrolytic,CarsEngine.Hybrid};
            public static readonly CarsType[] Type = {CarsType.Hatchback, CarsType.Coupe, CarsType.OffRoad,CarsType.Sedan};
            public static readonly int[] Displacement = {};
            public const int numberOfRecords = 1000;
            public const string Separator = ";";
    }
}
