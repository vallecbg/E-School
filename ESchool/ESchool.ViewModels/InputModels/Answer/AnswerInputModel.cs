using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.ViewModels.InputModels.Answer
{
    public class AnswerInputModel
    {
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public string QuestionId { get; set; }
    }
}
