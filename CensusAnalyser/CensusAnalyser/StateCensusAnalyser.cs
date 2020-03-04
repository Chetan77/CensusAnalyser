using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public static int GetRecordsUsingEnumeratorIterator(string path)
        {
            int count = 0;
            string[] data = File.ReadAllLines(path);
            IEnumerable<string> ele = data;
            foreach (var elements in ele)
            {
                count++;
            }
            return count;
        }
    }
}
