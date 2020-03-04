using System;
using System.IO;

namespace CensusAnalyser
{
    class Program
    {
        private static string path = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.csv";
        static void Main(string[] args)
        {
            int v = StateCensusAnalyser.GetRecordsUsingEnumeratorIterator(path);
            Console.WriteLine(v);
            Console.WriteLine(CSVStateCensus.GetNumberOfRecords(path));
        }
    }
}
