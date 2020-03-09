using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStates : CSVBuilder
    {
        public delegate int ReferToCSVSates(string path, char delimiter = ',', string header = "SrNo,State,Name,TIN,StateCode");

        public int ToGetDataFromCSVFile(string path, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
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
