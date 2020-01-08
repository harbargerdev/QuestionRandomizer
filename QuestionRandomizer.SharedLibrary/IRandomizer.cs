using System.Collections.Generic;
using QuestionRandomizer.SharedLibrary.Entities;

namespace QuestionRandomizer.SharedLibrary
{
    public interface IRandomizer
    {
        ICollection<Question> RandomizeQuestions();
    }
}
