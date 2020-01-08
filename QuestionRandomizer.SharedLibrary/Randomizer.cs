using System;
using QuestionRandomizer.SharedLibrary.Entities;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace QuestionRandomizer.SharedLibrary
{
    public class Randomizer : IRandomizer
    {
        private List<Question> _initialQuestions;
        private List<Question> _availableQuestions;

        public Randomizer()
        {
        }

        public Randomizer(string jsonQuestions)
        {
            ConvertJsonToList(jsonQuestions);
        }

        public Randomizer(ICollection<Question> questions)
        {
            _initialQuestions = questions.ToList();
        }

        public List<Question> RandomizeQuestions(int count)
        {
            if (count > _initialQuestions.Count)
                throw new Exception("Invalid parameter sent, count should be less than initial questions.");
            else if (count == _initialQuestions.Count)
                return _initialQuestions; // Shortcut if full list is requested

            _availableQuestions = new List<Question>(_initialQuestions);
            Random random = new Random();
            List<Question> questions = new List<Question>();

            while(questions.Count < count)
            {
                int position = random.Next(0, _availableQuestions.Count - 1);
                Question question = _availableQuestions[position];
                questions.Add(question);
                _availableQuestions.RemoveAt(position);
            }

            return questions;
        }

        public bool SetInitialQuestions(string jsonQuestions)
        {
            ConvertJsonToList(jsonQuestions);
            return true;
        }

        public bool SetInitialQuestions(ICollection<Question> questions)
        {
            _initialQuestions = questions.ToList();
            return true;
        }

        #region Helper Methods

        private void ConvertJsonToList(string json)
        {
            _initialQuestions = JsonConvert.DeserializeObject<List<Question>>(json);
        }

        #endregion
    }
}
