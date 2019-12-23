using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;
using ESchool.ViewModels.InputModels.Answer;

namespace ESchool.ViewModels.InputModels.Exams
{
    public class ExamApiSolveInputModel
    {
        public ExamApiSolveInputModel()
        {
            this.SelectedAnswers = new List<AnswerApiInputModel>();
        }

        public string ExamId { get; set; }

        public ICollection<AnswerApiInputModel> SelectedAnswers { get; set; }
    }
}
