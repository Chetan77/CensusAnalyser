using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    class CSVOperations
    {
        public static bool CheckForDelimiter(string[] fileData, char delimiter)
        {
            try
            {
                foreach (string str in fileData)
                {
                    if (str.Split(delimiter).Length != 5 && str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                    {
                        throw new CensusAnalyserException("incorrect delimiter");
                    }
                }
                return true;
            }
            catch (CensusAnalyserException)
            {

                throw;
            }
        }
        public static bool CheckForHeader(string[] fileheader, string header)
        {
            try
            {
                if (fileheader[0].Equals(header))
                {
                    return true;
                }
                throw new CensusAnalyserException("incorrect header");
            }
            catch (CensusAnalyserException)
            {
                throw;
            }
        }

        public static bool CheckFileType(string path, string type)
        {
            try
            {
                if (Path.GetExtension(path).Equals(type))
                {
                    return true;
                }
                throw new CensusAnalyserException("file type incorrect");
            }
            catch (CensusAnalyserException)
            {
                throw;
            }
        }

        public static string[] ReadCSVFile(string path)
        {
            try
            {
                string[] data = File.ReadAllLines(path);
                return data;
            }
            catch (FileNotFoundException)
            {
                throw new CensusAnalyserException("file incorrect");
            }
        }
        public static int CountRecords(string[] records)
        {
            int count = 0;
            IEnumerable<string> enumerator = records;
            foreach (string str in enumerator)
            {
                count++;
            }
            return count;
        }
    }
}
