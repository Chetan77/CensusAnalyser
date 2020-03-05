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
            Assert.AreEqual(30, count1);
        }

        /// <summary>
        /// Givens the incorrectfile when analyse should throw census analyser exception.
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var exc = Assert.Throws<CensusAnalyserException>(() => StateCensusAnalyser.GetRecordsUsingEnumeratorIterator(@"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusDa.csv"));
            Assert.AreEqual("file path incorrect", exc.GetMessage);
        }
        /// <summary>
        /// Givens the incorrectfile type when analyse should throw censusu analyser exception.
        /// </summary>
        
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var incorrectpath = Assert.Throws<CensusAnalyserException>(() => StateCensusAnalyser.GetRecordsUsingEnumeratorIterator(@"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusDa.csvrrr"));
            Assert.AreEqual("File type incorrect", incorrectpath.GetMessage);
        }

        /// <summary>
        /// Given the incorrect delimiter when analyse should throw census analyser exception.
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            var incorrectDelimiter = Assert.Throws<CensusAnalyserException>(() => StateCensusAnalyser.GetRecordsUsingEnumeratorIterator(path,'.'));
            Assert.AreEqual("Incorrect Delimiter",incorrectDelimiter.GetMessage);
        }
    }
}