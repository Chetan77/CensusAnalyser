using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
       public static int ToGetDataFromCSVFile(string path, char delimiter=',',string header="State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                    int count = 0;
                    string[] data = ReadCsvFile(path);
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
                    foreach (var elements in data)
                    {
                        count++;
                    }
                    return count;
            }
            catch (CensusAnalyserException)
            {
                throw;
            }
        }
        public static string[] ReadCsvFile(string path)
        {
            try
            {
                if (Path.GetExtension(path).Equals(".csv"))
                {
                    string[] arr = File.ReadAllLines(path);
                    return arr;
                }
                throw new CensusAnalyserException("File type incorrect");
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
