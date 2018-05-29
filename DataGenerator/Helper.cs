using PracticeProject.Core.Enums;
using System.Collections.Specialized;

namespace DataGenerator
{
    internal class Helper
    {
        public static readonly NameValueCollection ModelVersion = new NameValueCollection()
        {
                {"Mercedes","S Class"},{"Mercedes","ML 350"},{"Mercedes","GLE"},
                { "BMW","X5"},{ "BMW","X1"},{ "BMW","X6"},
                { "Honda","Civic"},{ "Honda","Accord"},{ "Honda","Prelude"},
                { "Toyota","Avensis"},{ "Toyota","Camry"},{ "Toyota","Supra"},
                { "KIA","Sportage"}, { "KIA","Sorento"}, { "KIA","Ceed"},
                { "Opel","Vectra C"},{ "Opel","Astra G"},{ "Opel","Insignia"},
        };
            public static readonly CarsEngine[] Engine = {CarsEngine.Benzine,CarsEngine.Electrolytic,CarsEngine.Hybrid};
            public static readonly CarsType[] Type = {CarsType.Hatchback, CarsType.Coupe, CarsType.OffRoad,CarsType.Sedan};
            public static readonly int[] Displacement = {10000,100,15000,30000};
            public static readonly bool[] IsAvailable = { true,false };
            public const int numberOfRecords = 1000;
            public const string delimetr = ";";
    }
}
