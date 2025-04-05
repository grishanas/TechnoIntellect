using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoIntellect
{
    internal class CsvReader
    {
        private string path = "file.csv";
    
        public string[] ParseCSV(string csv)
        {
            csv=csv.Replace("\"","");
            return csv.Split(',');
        }

        public string[] ReadFile()
        {
            return File.ReadAllLines(path);
        }

        public string[] ReadLines(List<int> lines)
        {
            var result= new List<string>();
            var fileLines=ReadFile();
            foreach (var line in lines)
            {
                result.Add(fileLines[line]);
            }
            return result.ToArray();
        }
        
        public string ReadLine(int lineNumber)
        {
            var line = File.ReadLines(path).ElementAtOrDefault(lineNumber);
            return line;
        }
    }
}
