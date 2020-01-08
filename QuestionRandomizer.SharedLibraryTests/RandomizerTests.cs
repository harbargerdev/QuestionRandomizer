using NUnit.Framework;
using QuestionRandomizer.SharedLibrary;
using QuestionRandomizer.SharedLibrary.Entities;
using System;
using System.Collections.Generic;

namespace QuestionRandomizer.SharedLibraryTests
{
    public class RandomizerTests
    {
        public static string json = "[{\"Number\": 1,\"Text\": \"The first question\",\"Points\": 1},{\"Number\": 2,\"Text\": \"The second question\",\"Points\": 2}]";
        public static List<Question> questions = new List<Question>
        {
            new Question { Number = "1", Text = "The first question", Points = 1 },
            new Question { Number = "2", Text = "The second question", Points = 2 }
        };

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

        [Test]
        public void Randomizer_RandomizeQuestions_ThrowsException()
        {
            // Setup
            var sut = new Randomizer();
            sut.SetInitialQuestions(json);

            // Execute
            Assert.Throws<Exception>(() => { sut.RandomizeQuestions(3); });
        }

        [Test]
        public void Randomizer_RandomizeQuestions_ReturnsInitialList()
        {
            // Setup
            var sut = new Randomizer();
            sut.SetInitialQuestions(json);

            // Execute
            var output = sut.RandomizeQuestions(2);

            // Assert
            Assert.IsTrue(output.Count == 2);
        }

        [Test]
        public void Randomizer_RandomizeQuestions_ReturnsListContaingOne()
        {
            // Setup
            var sut = new Randomizer();
            sut.SetInitialQuestions(json);

            // Execute
            var output = sut.RandomizeQuestions(1);

            // Assert
            Assert.IsTrue(output.Count == 1);
        }
    }
}