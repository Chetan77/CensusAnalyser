using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public static int GetNumberOfRecords(string path)
        {
            string[] data = File.ReadAllLines(path);
            return data.Length;
        }
    }
}
