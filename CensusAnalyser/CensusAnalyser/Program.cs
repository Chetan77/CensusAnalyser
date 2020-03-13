using System;
using System.IO;

namespace CensusAnalyser
{
    class Program
    {
        private static string CsvStateCensuspath = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.csv";
        private static string CsvStateCodePath = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCode.csv";
        private static string jsonCsvStateCensuspath = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\JsonFiles\CSVStateCensusData.json";
        private static string jsonCsvStateCodepath = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\JsonFiles\StateCode.json";
        static void Main(string[] args)
        {
            /*Console.WriteLine( StateCensusAnalyser.GetRecordsFromCSVFile(path));
            Console.WriteLine(CSVStateCensus.ToGetDataFromCSVFileUsigEnumerator(path));*/
            // var fi = CSVStateCensus.ToGetDataFromCSVFile(path);
            //Console.WriteLine(fi);
            /* string stateCensusData = StateCensusAnalyser.SortStateCodeandWriteInJson(CsvStateCensuspath, jsonCsvStateCensuspath, "State");
             string stateCode = StateCensusAnalyser.SortStateCodeandWriteInJson(CsvStateCodePath, jsonCsvStateCodepath, "StateCode");

             Console.WriteLine(stateCensusData);
             Console.WriteLine(stateCode);
 */
            string val=CSVOperations.RetriveFirstDataOnKey(jsonCsvStateCensuspath, "State");
            string lat = CSVOperations.RetriveLastDataOnKey(jsonCsvStateCensuspath, "State");

            Console.WriteLine(val);
            Console.WriteLine(lat);

        }
    }
}
