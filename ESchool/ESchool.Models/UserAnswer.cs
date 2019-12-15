﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class UserAnswer
    {
        public UserAnswer()
        {
            this.SelectedAnswers = new List<OfferedAnswer>();
        }

        public string Id { get; set; }

        public string ExamId { get; set; }
        public Exam Exam { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<OfferedAnswer> SelectedAnswers { get; set; }
    }
}
