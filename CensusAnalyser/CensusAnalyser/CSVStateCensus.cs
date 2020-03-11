using System;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    public class CSVStateCensus : ICSVBuilder
    {
        public delegate int GetCSVCount();
        CSVBuilder cSVBuilder = new CSVBuilder();
        public int ToGetDataFromCSVFile()
        {
            try
            {
                string pa = cSVBuilder.Path;
                char del = cSVBuilder.Delimeter;
                string header = cSVBuilder.Header;
               
                int count = CSVOperations.CountRecords(cSVBuilder.Records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
