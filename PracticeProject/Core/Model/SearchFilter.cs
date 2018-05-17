using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.Model
{
    public class SearchFilter
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Year { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }


    }
}
