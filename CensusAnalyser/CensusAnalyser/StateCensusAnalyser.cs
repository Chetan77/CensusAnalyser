using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public static int GetRecordsUsingEnumeratorIterator(string path, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            int count = 0;
            try
            {
                if (Path.GetExtension(path) == ".csv")
                {
                    string[] data = File.ReadAllLines(path);
                    foreach (string str in data)
                    {
                        if (str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                        {
                            throw new CensusAnalyserException("Incorrect Delimiter");
                        }
                    }
                    if (!data[0].Equals(header))
                    {
                        throw new CensusAnalyserException("Incorrect header");
                    }
                    IEnumerable<string> ele = data;
                    foreach (var elements in ele)
                    {
                        count++;
                    }
                    return count;
                }
                else
                {
                    throw new CensusAnalyserException("File type incorrect");
                }
            }
            catch (FileNotFoundException)
            {
                throw new CensusAnalyserException("file path incorrect");
            }
            catch (CensusAnalyserException)
            {
                throw;
            }
        }
    }
}
