using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.ViewModels.OutputModels.Api
{
    public class OfferedAnswerApiOutputModel
    {
        public string Id { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }
    }
}
