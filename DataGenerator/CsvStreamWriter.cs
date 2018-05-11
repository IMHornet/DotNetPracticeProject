using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class CsvStreamWriter : StreamWriter
    {
        string delimetr;

        public CsvStreamWriter(string filePath,string delimetr):base(filePath)
        {
            this.delimetr = delimetr;
        }

        public override void Write(string row)
        {
            try
            {
                base.WriteLine(row);
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        public void Write(params string[] values)
        {

        }
        //сгенерировать фаил и прочесть из кор
        // get car with validator  по параметрам 
    }
}
