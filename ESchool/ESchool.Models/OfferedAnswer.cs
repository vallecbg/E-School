using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class OfferedAnswer
    {
        public OfferedAnswer()
        {
            this.SelectedAnswers = new List<UserOfferedAnswer>();
        }

        public string Id { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public string QuestionId { get; set; }
        public Question Question { get; set; }

        public ICollection<UserOfferedAnswer> SelectedAnswers { get; set; }
    }
}
