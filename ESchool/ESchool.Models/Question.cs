using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class Question
    {
        public Question()
        {
            this.PossibleAnswers = new List<OfferedAnswer>();
        }

        public string Id { get; set; }

        public string QuestionText { get; set; }

        public double Marks { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<OfferedAnswer> PossibleAnswers { get; set; }

        public string ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
