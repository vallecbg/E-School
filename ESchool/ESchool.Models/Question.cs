using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class Question
    {
        public string Id { get; set; }

        public string QuestionText { get; set; }

        public double Marks { get; set; }

        public string ImageUrl { get; set; }
    }
}
