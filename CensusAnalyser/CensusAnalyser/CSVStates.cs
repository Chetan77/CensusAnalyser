using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStates : ICSVBuilder
    {
        public delegate int ReferToCSVSates();

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
