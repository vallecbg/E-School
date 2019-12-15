using System;
using System.Collections.Generic;
using System.Text;
using ESchool.Models;
using ESchool.ViewModels.InputModels.Exams;
using ESchool.ViewModels.OutputModels.Api;

namespace ESchool.Services.Contracts
{
    public interface IApiService
    {
        IEnumerable<ExamApiOutputModel> Exams();

        UserAnswer SolveExam(ExamSolveInputModel model);
    }
}
