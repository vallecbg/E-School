using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class OfferedAnswer
    {
        public string Id { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public string QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
