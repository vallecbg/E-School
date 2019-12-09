using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class Exam
    {
        public Exam()
        {
            this.UserAnswers = new List<UserAnswer>();
            this.Questions = new List<Question>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsOpen { get; set; }

        public double MaxMarks { get; set; }



        public ICollection<UserAnswer> UserAnswers { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
