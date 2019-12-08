using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class ExamQuestion
    {
        public string Id { get; set; }

        public string ExamId { get; set; }
        public Exam Exam { get; set; }

        public string QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
