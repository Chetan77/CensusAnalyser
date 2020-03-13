using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CensusAnalyser.CSVStates;

namespace CensusAnalyser
{
    public class CSVOperations
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
            List<string> list = new List<string>();
            foreach (string str in records)
            {
                list.Add(str);
            }
            return list.Count;
        }

        public static JArray SortJsonBasedOnKey(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if (stateCensusrrary[j][key].ToString().CompareTo(stateCensusrrary[j + 1][key].ToString()) > 0)
                    {
                        var tamp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = tamp;
                    }
                }
            }
            return stateCensusrrary;
        }
        public static string RetriveFirstDataOnKey(string jsonPath, string key)
        {
            string jfile=File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            string val=jArray[0][key].ToString();
            return val;
        }
        public static string RetriveLastDataOnKey(string jsonPath, string key)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            string val = jArray[jArray.Count-1][key].ToString();
            return val;
        }
    }
}
