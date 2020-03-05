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
            int count2 = CSVStateCensus.ToGetDataFromCSVFile(path);
            Assert.AreEqual(count1, count2);
        }

        /// <summary>
        /// Givens the incorrectfile when analyse should throw census analyser exception.
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var exc = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.ToGetDataFromCSVFile(@"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusDa.csv"));
            Assert.AreEqual("file path incorrect", exc.GetMessage);
        }

        /// <summary>
        /// Givens the incorrectfile type when analyse should throw censusu analyser exception.
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var incorrectpath = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.ToGetDataFromCSVFile(@"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusDa.csvrrr"));
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

        /// <summary>
        /// Given the incorrect header when analyse should throw census analyser exception
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            var incorrectHeader = Assert.Throws<CensusAnalyserException>(
                () => StateCensusAnalyser.GetRecordsUsingEnumeratorIterator(path,',', "Ste,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("Incorrect header",incorrectHeader.GetMessage);
        }

    }
}