using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStates
    {
        public delegate int GetCountFromCSVSates(string path, char delimiter = ',', string header = "SrNo,State,Name,TIN,StateCode");
        public static int GetRecordsFromStateCodeCSV(string path, char delimiter = ',', string header = "SrNo,State,Name,TIN,StateCode")
        {
            try
            {
                bool type = CSVOperations.CheckFileType(path, ".csv");
                string[] records = CSVOperations.ReadCSVFile(path);
                bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
                bool head = CSVOperations.CheckForHeader(records, header);
                int count=CSVOperations.CountRecords(records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}
