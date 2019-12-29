using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;

namespace ESchool.ViewModels.OutputModels.Api
{
    public class ExamApiOutputModel
    {
        public ExamApiOutputModel()
        {
            //this.UserAnswers = new List<UserAnswer>();
            this.Questions = new List<QuestionApiOutputModel>();
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool IsOpen { get; set; }

        public double MaxMarks { get; set; }

        //public ICollection<UserAnswer> UserAnswers { get; set; }

        public ICollection<QuestionApiOutputModel> Questions { get; set; }
    }
}
