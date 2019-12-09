using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ESchool.ViewModels.InputModels.Exams;

namespace ESchool.Services.Contracts
{
    public interface IExamService
    {
        Task<string> CreateExam(ExamInputModel model);
    }
}
