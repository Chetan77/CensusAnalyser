using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public static int ToGetDataFromCSVFileUsigEnumerator(string path,char delimiter=',',string header="State,Population,AreaInSqKm,DensityPerSqKm")
        {
            int count = 0;
            try
            {
                if (!Path.GetExtension(path).Equals(".csv"))
                {
                    throw new CensusAnalyserException("file type incorrect");
                }
                string[] data = File.ReadAllLines(path);
                foreach(string str in data)
                {
                    if(str.Split(delimiter).Length !=4 && str.Split(delimiter).Length != 2)
                    {
                        throw new CensusAnalyserException("incorrect delimiter");
                    }
                }
                if (!data[0].Equals(header))
                {
                    throw new CensusAnalyserException("incorrect header");
                }
                IEnumerable<string> ele = data;
                foreach (var elements in data)
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
