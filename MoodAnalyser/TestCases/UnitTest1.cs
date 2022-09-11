using MoodAnalyser;

namespace TestCases
{
    [TestClass]
    public class AnalyseMoodTestCases
    {
        private MoodAnalyserFactory factory;

        [TestMethod]
        public void GivenMoodAnalyzerClassName_ReturnMoodAnalysisObject(string className, string constructorName)
        {
            MoodAnalysis expected = new MoodAnalysis();
            object obj;

            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            obj = factory.CreatemoodAnalyse(className, constructorName);
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenImproperClassName_ShouldThrowCustomException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void GivenImproperConstructorName_ShouldThrowCustomException(string className, string constructorName, string expected)
        {
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod("I am in sad mood")]
        public void GivenMoodAnalyserWhenProperShouldReturnMoodAnalyserObject(string message)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj = null;
            try
            {
                factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyseParameterObject("MoodAnalysis", "MoodAnalysis", message);
            }
            catch (CustomException actual)
            {
                Assert.That(actual.Message, Is.EqualTo(obj));
            }
            obj.Equals(expected);
        }

        [TestMethod]
        public void GIvenClassNmaeWhenImproperShouldThrowException(string className, string message, string expexted)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj = null;
            try
            {
                factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyseParameterObject(className, "MoodAnalysis", message);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expexted, ex.Message);
            }
        }

        [TestMethod]
        public void GIvenConstructorNameWhenImproperShouldThrowException(string construtorName, string message, string expexted)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj;
            try
            {
                factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyseParameterObject("MoodAnalysis", construtorName, message);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expexted, ex.Message);
            }
        }
        [TestMethod("HAPPY")]
        public void ReflectionReturnMethod(string expected)
        {
            try
            {
                string actual = factory.InvokeAnalyseMood("happy", "AnalyseMood");
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void SetHappyMessageWithReflectorShouldReturnHappy(string value, string expected, string fieldName)
        {
            try
            {
                string actual = factory.SetField(value, fieldName);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        

        [TestMethod]
        public void SetFieldWhenImproperShouldThrowExceptionNoSuchField(string value, string expected, string fieldName)
        {
            try
            {
                string actual = factory.SetField(value, fieldName);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
      
        [TestMethod]
        public void SettingNullMessageWithReflectorShouldThrowException(string value, string expected, string fieldName)
        {
            try
            {
                string actual = factory.SetField(value, fieldName);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }


    }
}