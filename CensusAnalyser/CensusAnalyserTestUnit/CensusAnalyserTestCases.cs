using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTestUnit
{
    public class Tests
    {
        private string path = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.csv";
        /// <summary>
        /// Giventhes the states census cs vfile when analyse should record number of recordmatches.
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int count1 = StateCensusAnalyser.GetRecordsUsingEnumeratorIterator(path);
            int count2 = CSVStateCensus.GetNumberOfRecords(path);
            Assert.AreEqual(count1, count2);
        }
    }
}