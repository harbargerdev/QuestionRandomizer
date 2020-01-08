using System.Collections.Generic;
using QuestionRandomizer.SharedLibrary.Entities;

namespace QuestionRandomizer.SharedLibrary
{
    public interface IRandomizer
    {
        /// <summary>
        /// Method used to set collection of initial questions from JSON string.
        /// </summary>
        /// <param name="jsonQuestions">Json String</param>
        /// <returns>True if successful</returns>
        bool SetInitialQuestions(string jsonQuestions);

        /// <summary>
        /// Method used to set collection of initial questions using an existing collection.
        /// </summary>
        /// <param name="questions">Existing collection</param>
        /// <returns>True if successful</returns>
        bool SetInitialQuestions(ICollection<Question> questions);

        /// <summary>
        /// Randomizes questions to be asked.
        /// </summary>
        /// <param name="count">Number of questions to ask</param>
        /// <returns>List of Questions</returns>
        List<Question> RandomizeQuestions(int count);
    }
}
