using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.Manager
{
    interface ICar
    {
        double Drive(double timeInHour, int speed);
        string StartEngine();
        string StopEngine();
    }
}
