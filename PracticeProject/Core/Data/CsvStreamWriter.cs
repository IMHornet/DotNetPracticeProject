using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Core.Data
{
    public class CsvStreamWriter : StreamWriter
    {
        private readonly string delimetr;
       
       
        public CsvStreamWriter(string filePath):base(filePath)
        {
            this.delimetr = Constants.Constants.csvDelimetr;
        }

        public void WriteLine(IEnumerable<string> lines)
        {
            if (!lines.Any()) return;

            var line = string.Join(delimetr, lines);
            base.WriteLine(line);
        }

        public void Write(params string[] lines)
        {
            if (!lines.Any()) return;

            var line = string.Join(delimetr, lines);
            base.WriteLine(line);
        }
 
    }
}
