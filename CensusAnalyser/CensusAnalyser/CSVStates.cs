using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStates
    {
        public static int GetRecordsFromStateCodeCSV(string path,char delimiter=',',string header= "SrNo,State,Name,TIN,StateCode")
        {
            int count = 0;
            try
            {
                if (!Path.GetExtension(path).Equals(".csv"))
                {
                    throw new CensusAnalyserException("file type incorrect");
                }
                string[] records = File.ReadAllLines(path);
                foreach (string str in records)
                {
                    if (str.Split(delimiter).Length != 5 && str.Split(delimiter).Length !=4 && str.Split(delimiter).Length != 2)
                    {
                        throw new CensusAnalyserException("incorrect delimiter");
                    }
                }
                if (!records[0].Equals(header))
                {
                    throw new CensusAnalyserException("incorrect header");
                }
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
            catch (CensusAnalyserException)
            {
                throw;
            }
        }
    }
}
