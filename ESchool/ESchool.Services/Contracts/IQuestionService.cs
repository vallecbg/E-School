using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ESchool.ViewModels.InputModels.Question;

namespace ESchool.Services.Contracts
{
    public interface IQuestionService
    {
        Task<string> Create(QuestionInputModel model);
    }
}
