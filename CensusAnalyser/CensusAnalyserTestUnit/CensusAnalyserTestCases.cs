using CensusAnalyser;
using NUnit.Framework;
using static CensusAnalyser.CSVStateCensus;

namespace CensusAnalyserTestUnit
{
    public class Tests
    {
        private string path = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.csv";
        private string fileIncorrect= @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCusData.csv";

        /// <summary>
        /// Given the states census cs vfile when analyse should record number of recordmatches.
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int count1 = StateCensusAnalyser.GetRecordsFromCSVFile(path);
            int count2 = CSVStateCensus.ToGetDataFromCSVFileUsigEnumerator(path);
            Assert.AreEqual(count1, count2);
        }
        /// <summary>
        /// Givens the state census CSV file incorrect when analyse throw census analyser exception.
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var value=Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.ToGetDataFromCSVFileUsigEnumerator(fileIncorrect));
            Assert.AreEqual("file incorrect", value.GetMessage);
        }
    }
}