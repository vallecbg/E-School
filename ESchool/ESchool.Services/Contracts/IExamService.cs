using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ESchool.Models;
using ESchool.ViewModels.InputModels.Exams;
using ESchool.ViewModels.OutputModels.Exam;

namespace ESchool.Services.Contracts
{
    public interface IExamService
    {
        Task<string> CreateExam(ExamInputModel model);

        Exam FindById(string id);

        ExamOutputModel GetExamDetails(string examId);

        
    }
}
