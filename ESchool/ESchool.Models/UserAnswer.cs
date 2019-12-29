using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class UserAnswer
    {
        public UserAnswer()
        {
            this.SelectedAnswers = new List<UserOfferedAnswer>();
        }

        public string Id { get; set; }

        public string ExamId { get; set; }
        public Exam Exam { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<UserOfferedAnswer> SelectedAnswers { get; set; }
    }
}
