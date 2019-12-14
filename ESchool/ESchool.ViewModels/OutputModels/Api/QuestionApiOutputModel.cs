using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;

namespace ESchool.ViewModels.OutputModels.Api
{
    public class QuestionApiOutputModel
    {
        public QuestionApiOutputModel()
        {
            this.PossibleAnswers = new List<OfferedAnswerApiOutputModel>();
        }

        public string Id { get; set; }

        public string QuestionText { get; set; }

        public double Marks { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<OfferedAnswerApiOutputModel> PossibleAnswers { get; set; }
    }
}
