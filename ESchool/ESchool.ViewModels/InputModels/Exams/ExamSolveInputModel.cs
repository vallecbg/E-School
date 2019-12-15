using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;

namespace ESchool.ViewModels.InputModels.Exams
{
    public class ExamSolveInputModel
    {
        public ExamSolveInputModel()
        {
            this.SelectedAnswers = new List<OfferedAnswer>();
        }

        public string ExamId { get; set; }

        public string UserId { get; set; }
        public ICollection<OfferedAnswer> SelectedAnswers { get; set; }
    }
}
