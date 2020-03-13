using ChoETL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public delegate int GetCountFromStateCensusAnalyser(string path);
        public int GetRecordsFromCSVFile(string path)
        {
            string[] array = File.ReadAllLines(path);
            return array.Length;
        }

        public static string SortCSVFileWriteInJsonAndReturnFirstData(string filePath, string jsonFilepath, string key)
        {
            string re = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(re)
                .WithFirstLineHeader()
                )
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, sb.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, key);
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveFirstDataOnKey(jsonFilepath,key);
        }
        public static string SortCSVFileWriteInJsonAndReturnLastData(string filePath, string jsonFilepath, string key)
        {
            string re = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(re)
                .WithFirstLineHeader()
                )
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, sb.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, key);
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, key);
        }
    }
}
