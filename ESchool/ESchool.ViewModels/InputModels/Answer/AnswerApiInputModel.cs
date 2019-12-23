using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.ViewModels.InputModels.Answer
{
    public class AnswerApiInputModel
    {
        public string Id { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }
    }
}
