using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ESchool.ViewModels.Constants;
using Microsoft.AspNetCore.Http;

namespace ESchool.ViewModels.InputModels.Exams
{
    public class ExamInputModel
    {
        [Required]
        [StringLength(ViewModelsConstants.NameMaxLength, MinimumLength = ViewModelsConstants.NameMinLength)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [StringLength(ViewModelsConstants.DescriptionMaxLength, MinimumLength = ViewModelsConstants.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        //TODO: need to remove isopen required from here and make it calculate automatically
        [Required]
        public bool IsOpen { get; set; }

        [Required]
        public double MaxMarks { get; set; }
    }
}
