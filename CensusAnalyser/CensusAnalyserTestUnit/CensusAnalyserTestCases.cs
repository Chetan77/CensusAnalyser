using CensusAnalyser;
using NUnit.Framework;
using static CensusAnalyser.CSVStateCensus;
using static CensusAnalyser.CSVStates;
using static CensusAnalyser.StateCensusAnalyser;

namespace CensusAnalyserTestUnit
{
    public class Tests
    {
        GetCSVCount getCSVCountFromCSVStateCensus = ToGetDataFromCSVFileUsigEnumerator;
        GetCountFromStateCensusAnalyser getCountFromStateCensusAnalyser = GetRecordsFromCSVFile;
        private string path = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.csv";
        private string fileIncorrect= @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCusData.csv";
        private string fileTypeIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.txt";

        /// <summary>
        /// Given the states census cs vfile when analyse should record number of recordmatches.
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int count1 = getCountFromStateCensusAnalyser(path);
            int count2 = getCSVCountFromCSVStateCensus(path);
            Assert.AreEqual(count1, count2);
        }

        /// <summary>
        /// Given the state census CSV file incorrect when analyse throw census analyser exception.
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var value=Assert.Throws<CensusAnalyserException>(() => getCSVCountFromCSVStateCensus(fileIncorrect));
            Assert.AreEqual("file incorrect", value.GetMessage);
        }

        /// <summary>
        /// Given the state census CSV file type incorrect when analyse throw census analyser exception
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileTypeIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var typeIncorrect = Assert.Throws<CensusAnalyserException>(() => getCSVCountFromCSVStateCensus(fileTypeIncorrect));
            Assert.AreEqual("file type incorrect", typeIncorrect.GetMessage);
        }
        /// <summary>
        /// Given the state cesnus CSV file delimiter incorrect when analyse throwcensus analyser exception
        /// </summary>
        [Test]
        public void GivenTheStateCesnusCsvFileDelimiterIncorrect_WhenAnalyse_ThrowcensusAnalyserException()
        {
            var delimiterIncorrect = Assert.Throws<CensusAnalyserException>(() => getCSVCountFromCSVStateCensus(path, '.'));
            Assert.AreEqual("incorrect delimiter", delimiterIncorrect.GetMessage);
        }

        /// <summary>
        /// Givens the state census CSV file header incorrect when analyse throw census analyser exception
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileHeaderIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var headerIncorrect = Assert.Throws<CensusAnalyserException>(() => getCSVCountFromCSVStateCensus(path, ',', "State,"));
            Assert.AreEqual("incorrect header", headerIncorrect.GetMessage);
        }

        GetCountFromCSVSates getCountFromCSVSates = GetRecordsFromStateCodeCSV; 
        private string stateCodePath=@"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCode.csv";
        private string stateCodePathfileIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\SeCode.csv";
        private string stateCodePathFileTypeIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCode.pdf";

        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ReturnNumberOfRecordsMatch()
        {
            int count1 = getCountFromStateCensusAnalyser(stateCodePath);
            int count2 = getCountFromCSVSates(stateCodePath);
            Assert.AreEqual(count1, count2);
        }
        [Test]
        public void GivenTheCSVStatecodeFileIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var value = Assert.Throws<CensusAnalyserException>(() => getCountFromCSVSates(stateCodePathfileIncorrect));
            Assert.AreEqual("file incorrect", value.GetMessage);
        }

        [Test]
        public void GivenTheCSVStatecodeFileTypeIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var typeIncorrect = Assert.Throws<CensusAnalyserException>(() => getCountFromCSVSates(stateCodePathFileTypeIncorrect));
            Assert.AreEqual("file type incorrect", typeIncorrect.GetMessage);
        }

        [Test]
        public void GivenTheCSVStatecodefileDelimiterIncorrect_WhenAnalyse_ThrowcensusAnalyserException()
        {
            var delimiterIncorrect = Assert.Throws<CensusAnalyserException>(() => getCountFromCSVSates(path, '.'));
            Assert.AreEqual("incorrect delimiter", delimiterIncorrect.GetMessage);
        }
        [Test]
        public void GivenTheCSVStateCodeFileHeaderIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            var headerIncorrect = Assert.Throws<CensusAnalyserException>(() => getCountFromCSVSates(path, ',', "State,"));
            Assert.AreEqual("incorrect header", headerIncorrect.GetMessage);
        }
    }
}