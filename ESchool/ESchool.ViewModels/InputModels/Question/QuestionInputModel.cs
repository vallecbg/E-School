using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ESchool.ViewModels.Constants;
using Microsoft.AspNetCore.Http;

namespace ESchool.ViewModels.InputModels.Question
{
    public class QuestionInputModel
    {
        public string QuestionText { get; set; }

        public double Marks { get; set; }

        [Display(Name = ViewModelsConstants.ImageDisplay)]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public string ExamId { get; set; }
    }
}
