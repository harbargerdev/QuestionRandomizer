using NUnit.Framework;
using QuestionRandomizer.SharedLibrary;

namespace QuestionRandomizer.SharedLibraryTests
{
    public class RandomizerTests
    {
        public static string json = "[{\"Number\": 1,\"Text\": \"The first question\",\"Points\": 1},{\"Number\": 2,\"Text\": \"The second question\",\"Points\": 2}]";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Randomizer_SetInitialQuestionsJson_Successful()
        {
            // Execute
            var sut = new Randomizer();
            var output = sut.SetInitialQuestions(json);

            // Assert
            Assert.IsTrue(output);
        }
    }
}