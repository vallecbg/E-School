using System;
using System.Collections.Generic;
using System.Text;
using ESchool.ViewModels.OutputModels.Api;

namespace ESchool.Services.Contracts
{
    public interface IApiService
    {
        IEnumerable<ExamApiOutputModel> Exams();
    }
}
