using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
       public static int ToGetDataFromCSVFile(string path)
        {
            int count = 0;
            string[] data = File.ReadAllLines(path);
            IEnumerable<string> ele = data;
            foreach (var elements in data)
            {
                count++;
            }
            return count;
        }
    }
}
