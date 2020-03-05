﻿using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
       public static int ToGetDataFromCSVFile(string path, char delimiter=',')
        {
            try
            {
                if (Path.GetExtension(path) == ".csv")
                {
                    int count = 0;
                    string[] data = File.ReadAllLines(path);
                    foreach (string str in data)
                    {

                        if (str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                        {
                            throw new CensusAnalyserException("Incorrect Delimiter");
                        }
                    }
                    IEnumerable<string> ele = data;
                    foreach (var elements in data)
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
        }
    }
}
