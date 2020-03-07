using CensusAnalyser;
using NUnit.Framework;
using static CensusAnalyser.CSVStateCensus;

namespace CensusAnalyserTestUnit
{
    public class Tests
    {
        private string path = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.csv";
        private string fileIncorrect= @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCusData.csv";
        private string fileTypeIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.txt";

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
        /// Given the state census CSV file incorrect when analyse throw census analyser exception.
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var value=Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.ToGetDataFromCSVFileUsigEnumerator(fileIncorrect));
            Assert.AreEqual("file incorrect", value.GetMessage);
        }

        /// <summary>
        /// Given the state census CSV file type incorrect when analyse throw census analyser exception
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileTypeIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var typeIncorrect = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.ToGetDataFromCSVFileUsigEnumerator(fileTypeIncorrect));
            Assert.AreEqual("file type incorrect", typeIncorrect.GetMessage);
        }
        /// <summary>
        /// Given the state cesnus CSV file delimiter incorrect when analyse throwcensus analyser exception
        /// </summary>
        [Test]
        public void GivenTheStateCesnusCsvFileDelimiterIncorrect_WhenAnalyse_ThrowcensusAnalyserException()
        {
            var delimiterIncorrect = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.ToGetDataFromCSVFileUsigEnumerator(path, '.'));
            Assert.AreEqual("incorrect delimiter", delimiterIncorrect.GetMessage);
        }

        /// <summary>
        /// Givens the state census CSV file header incorrect when analyse throw census analyser exception
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileHeaderIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var headerIncorrect = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.ToGetDataFromCSVFileUsigEnumerator(path, ',', "State,"));
            Assert.AreEqual("incorrect header", headerIncorrect.GetMessage);
        }

        private string stateCodePath=@"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCode.csv";
        private string stateCodePathfileIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\SeCode.csv";
        private string stateCodePathFileTypeIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCode.pdf";


        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ReturnNumberOfRecordsMatch()
        {
            int count1 = StateCensusAnalyser.GetRecordsFromCSVFile(stateCodePath);
            int count2 = CSVStates.GetRecordsFromStateCodeCSV(stateCodePath);
            Assert.AreEqual(count1, count2);
        }
        [Test]
        public void GivenTheCSVStatecodeFileIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var value = Assert.Throws<CensusAnalyserException>(() => CSVStates.GetRecordsFromStateCodeCSV(stateCodePathfileIncorrect));
            Assert.AreEqual("file incorrect", value.GetMessage);
        }

        [Test]
        public void GivenTheCSVStatecodeFileTypeIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var typeIncorrect = Assert.Throws<CensusAnalyserException>(() => CSVStates.GetRecordsFromStateCodeCSV(stateCodePathFileTypeIncorrect));
            Assert.AreEqual("file type incorrect", typeIncorrect.GetMessage);
        }

        [Test]
        public void GivenTheCSVStatecodefileDelimiterIncorrect_WhenAnalyse_ThrowcensusAnalyserException()
        {
            var delimiterIncorrect = Assert.Throws<CensusAnalyserException>(() => CSVStates.GetRecordsFromStateCodeCSV(path, '.'));
            Assert.AreEqual("incorrect delimiter", delimiterIncorrect.GetMessage);
        }
    }
}