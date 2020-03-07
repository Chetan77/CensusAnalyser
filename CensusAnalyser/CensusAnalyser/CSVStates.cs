using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStates
    {
        public static int GetRecordsFromStateCodeCSV(string path)
        {
            int count = 0;
            try
            {
                string[] records = File.ReadAllLines(path);
                IEnumerable<string> enumerator = records;
                foreach (string str in enumerator)
                {
                    count++;
                }
                return count;
            }
            catch (FileNotFoundException)
            {
                throw new CensusAnalyserException("file incorrect");
            }
        }
    }
}
