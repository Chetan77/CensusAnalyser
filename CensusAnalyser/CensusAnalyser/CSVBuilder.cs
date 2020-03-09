using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    interface CSVBuilder
    {
        public int ToGetDataFromCSVFile(string path, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
    }
}
