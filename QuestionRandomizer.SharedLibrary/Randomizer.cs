using System;
using QuestionRandomizer.SharedLibrary.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QuestionRandomizer.SharedLibrary
{
    public class Randomizer : IRandomizer
    {
        private readonly List<Question> _initialQuestions;
        private List<Question> _availableQuestions;

        public Randomizer(string jsonQuestions)
        {
        }

        public Randomizer(ICollection<Question> questions)
        {
            _initialQuestions = questions.ToList();
        }

        public ICollection<Question> RandomizeQuestions()
        {
            throw new System.NotImplementedException();
        }
    }
}
