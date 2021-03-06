﻿using Newtonsoft.Json.Linq;
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
            int k = 1;
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = records[0].Split(',');
            for (int i = 1; i < records.Length; i++)
            {
                string[] value = records[i].Split(',');
                Dictionary<string, string> subMap = new Dictionary<string, string>()
              {
                  { key[0], value[0] },
                  { key[1], value[1] },
                  { key[2], value[2] },
                  { key[3], value[3] },
              };

                map.Add(k, subMap);
                k++;
            }

            return map.Count;
          
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
        public static int SortJsonBasedOnKeyAndReturnNumberOfStatesSorted(string jsonPath, string key)
        {
            int count = 0;
            string jsonFile = File.ReadAllText(jsonPath);
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if ((int)stateCensusrrary[j][key] < (int)stateCensusrrary[j + 1][key])
                    {
                        var tamp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = tamp;
                        count++;
                    }
                }
            }
            return count;
        }
        public static JArray SortJsonBasedOnKeyAndValueIsNumber(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if ((int)stateCensusrrary[j][key] < (int)stateCensusrrary[j + 1][key])
                    {
                        var tamp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = tamp;
                    }
                }
            }
            return stateCensusrrary;
        }
    }
}
