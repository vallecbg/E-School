using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;
using ESchool.ViewModels.InputModels.Answer;

namespace ESchool.ViewModels.InputModels.Exams
{
    public class ExamApiSolveInputModel
    {
        public string ExamId { get; set; }

        public IEnumerable<AnswerApiInputModel> SelectedAnswers { get; set; }
    }
}
