using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.ViewModels.OutputModels.Exam
{
    public class ExamOutputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool IsOpen { get; set; }

        public double MaxMarks { get; set; }
    }
}
