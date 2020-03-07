using System;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public delegate int GetCSVCount(string path, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public static int ToGetDataFromCSVFileUsigEnumerator(string path,char delimiter=',',string header="State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                bool type = CSVOperations.CheckFileType(path, ".csv");
                string[] records = CSVOperations.ReadCSVFile(path);
                bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
                bool head = CSVOperations.CheckForHeader(records, header);
                int count = CSVOperations.CountRecords(records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
