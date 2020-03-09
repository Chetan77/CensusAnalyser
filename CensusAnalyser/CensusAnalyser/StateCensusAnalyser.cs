using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public delegate int GetCountFromStateCensusAnalyser(string path);
        public  int GetRecordsFromCSVFile(string path)
        {
            string[] array = File.ReadAllLines(path);
            return array.Length;
        }
    }
}
