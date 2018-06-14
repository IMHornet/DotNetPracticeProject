using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    public class TemperatureConvertor
    {
        public void ConvertToC(double far)
        {
            double res = (far - 32) * 5 / 9;
           //return (far - 32) * (5 / 9);
           Console.WriteLine(res);
        }

        public double LambdaConvertToC(double far)
        {
            //double res = (far - 32) * 5 / 9;
            return (far - 32) * (5 / 9);
            //Console.WriteLine(res);
        }

        public void ConvertToF(double cel)
        {
            double res = (cel * 9 / 5) + 32;
            Console.WriteLine(res);
        }

    }
}
