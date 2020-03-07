﻿using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public static int ToGetDataFromCSVFileUsigEnumerator(string path)
        {
            int count = 0;
            try
            {
                string[] data = File.ReadAllLines(path);
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
        }
    }
}
