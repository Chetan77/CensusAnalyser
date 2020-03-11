using CensusAnalyser;
using NUnit.Framework;
using static CensusAnalyser.CSVStateCensus;
using static CensusAnalyser.CSVStates;
using static CensusAnalyser.StateCensusAnalyser;

namespace CensusAnalyserTestUnit
{
    public class Tests
    {
        GetCountFromStateCensusAnalyser GetCountFromStateCensusAnalyser= CSVFactory.DelegateofStateCensusAnalyser();

        GetCSVCount csvstatecensus = CSVFactory.DelegateOfCSvStateCensus();
        private string path = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.csv";
        private string fileIncorrect= @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCusData.csv";
        private string fileTypeIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCensusData.txt";
        CSVBuilder cSVBuilder;

        /// <summary>
        /// Given the states census cs vfile when analyse should record number of recordmatches.
        /// TestCase 1.1
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            cSVBuilder = new CSVBuilder(path, ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            int count1 = GetCountFromStateCensusAnalyser(path);
            int count2 = csvstatecensus();
            Assert.AreEqual(count1, count2);
        }

        /// <summary>
        /// Given the state census CSV file incorrect when analyse throw census analyser exception.
        /// TestCase 1.2
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            cSVBuilder = new CSVBuilder(fileIncorrect, ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            var value = Assert.Throws<CensusAnalyserException>(() => csvstatecensus());
            Assert.AreEqual("file incorrect", value.GetMessage);
        }

        /// <summary>
        /// Given the state census CSV file type incorrect when analyse throw census analyser exception
        /// TestCase 1.3
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileTypeIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            cSVBuilder = new CSVBuilder(fileTypeIncorrect, ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            var typeIncorrect = Assert.Throws<CensusAnalyserException>(() => csvstatecensus());
            Assert.AreEqual("file type incorrect", typeIncorrect.GetMessage);
        }

        /// <summary>
        /// Given the state cesnus CSV file delimiter incorrect when analyse throwcensus analyser exception
        /// TestCase 1.4
        /// </summary>
        [Test]
        public void GivenTheStateCesnusCsvFileDelimiterIncorrect_WhenAnalyse_ThrowcensusAnalyserException()
        {
            cSVBuilder = new CSVBuilder(path, '.', "State,Population,AreaInSqKm,DensityPerSqKm");
            var delimiterIncorrect = Assert.Throws<CensusAnalyserException>(() => csvstatecensus());
            Assert.AreEqual("incorrect delimiter", delimiterIncorrect.GetMessage);
        }

        /// <summary>
        /// Givens the state census CSV file header incorrect when analyse throw census analyser exception
        /// TestCase 1.5
        /// </summary>
        [Test]
        public void GivenTheStateCensusCsvFileHeaderIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            cSVBuilder = new CSVBuilder(path, ',', "State,Popula tyPerSqKm");
            var headerIncorrect = Assert.Throws<CensusAnalyserException>(() => csvstatecensus());
            Assert.AreEqual("incorrect header", headerIncorrect.GetMessage);
        }

        ReferToCSVSates referToCSVSates = CSVFactory.Delegate();
        /*CSVStates cSVStates = new CSVStates(); 
        GetCountFromCSVSates getCountFromCSVSates = new GetCountFromCSVSates(cSVStates.ToGetDataFromCSVFile); */
        private string stateCodePath=@"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCode.csv";
        private string stateCodePathfileIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\SeCode.csv";
        private string stateCodePathFileTypeIncorrect = @"C:\Users\Admin\source\Chetan\CensusAnalyser\CensusAnalyser\FileData\StateCode.pdf";
        /// <summary>
        /// Givens the CSV state code file when analyse return number of records match
        /// TestCase 2.1
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ReturnNumberOfRecordsMatch()
        {
            cSVBuilder = new CSVBuilder(stateCodePath, ',', "SrNo,State,Name,TIN,StateCode");
            int count1 = GetCountFromStateCensusAnalyser(stateCodePath);
            int count2 = referToCSVSates();
            Assert.AreEqual(count1, count2);
        }

        /// <summary>
        /// Givens the CSV statecode file incorrect when analyse throw census analyser exception
        /// TestCase 2.2
        /// </summary>
        [Test]
        public void GivenTheCSVStatecodeFileIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            cSVBuilder = new CSVBuilder(stateCodePathfileIncorrect, ',', "SrNo,State,Name,TIN,StateCode");
            var value = Assert.Throws<CensusAnalyserException>(() => referToCSVSates());
            Assert.AreEqual("file incorrect", value.GetMessage);
        }

        /// <summary>
        /// Givens the CSV statecode file type incorrect when analyse throw census analyser exception
        /// TestCase 2.3
        /// </summary>
        [Test]
        public void GivenTheCSVStatecodeFileTypeIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            cSVBuilder = new CSVBuilder(stateCodePathFileTypeIncorrect, ',', "SrNo,State,Name,TIN,StateCode");
            var typeIncorrect = Assert.Throws<CensusAnalyserException>(() => referToCSVSates());
            Assert.AreEqual("file type incorrect", typeIncorrect.GetMessage);
        }

        /// <summary>
        /// Givens the CSV statecodefile delimiter incorrect when analyse throwcensus analyser exception
        /// TestCase 2.4
        /// </summary>
        [Test]
        public void GivenTheCSVStatecodefileDelimiterIncorrect_WhenAnalyse_ThrowcensusAnalyserException()
        {
            cSVBuilder = new CSVBuilder(stateCodePath, '.', "SrNo,State,Name,TIN,StateCode");
            var delimiterIncorrect = Assert.Throws<CensusAnalyserException>(() => referToCSVSates());
            Assert.AreEqual("incorrect delimiter", delimiterIncorrect.GetMessage);
        }

        /// <summary>
        /// Givens the CSV state code file header incorrect when analyse throw census analyser exception
        /// TestCase 2.5
        /// </summary>
        [Test]
        public void GivenTheCSVStateCodeFileHeaderIncorrect_WhenAnalyse_ThrowCensusAnalyserException()
        {
            cSVBuilder = new CSVBuilder(stateCodePath, ',', "SrNo,,TIN,StateCode");
            var headerIncorrect = Assert.Throws<CensusAnalyserException>(() => referToCSVSates());
            Assert.AreEqual("incorrect header", headerIncorrect.GetMessage);
        }
    }
}