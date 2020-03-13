using System;
using System.Collections.Generic;
using System.Text;
using static CensusAnalyser.CSVStateCensus;
using static CensusAnalyser.CSVStates;
using static CensusAnalyser.StateCensusAnalyser;

namespace CensusAnalyser
{
    public class CSVFactory
    {
        public static StateCensusAnalyser InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyser();
        }
        public static CSVStates InstanceOfCSVStates()
        {
            return new CSVStates();
        }
        public static CSVStateCensus InstanceOfCSVStateCensus()
        {
            return new CSVStateCensus();
        }
        public static GetCountFromStateCensusAnalyser DelegateofStateCensusAnalyser()
        {
            StateCensusAnalyser stateCensusAnalyser = InstanceOfStateCensusAnalyser();
            GetCountFromStateCensusAnalyser getCountFromStateCensusAnalyser = new GetCountFromStateCensusAnalyser(stateCensusAnalyser.GetRecordsFromCSVFile);
            return getCountFromStateCensusAnalyser;
        }
        public static GetCSVCount DelegateOfCSvStateCensus()
        {
            CSVStateCensus csvStateCensus = InstanceOfCSVStateCensus();
            GetCSVCount getCSVCount = new GetCSVCount(csvStateCensus.ToGetDataFromCSVFile);
            return getCSVCount;
        }
        
    }
}
