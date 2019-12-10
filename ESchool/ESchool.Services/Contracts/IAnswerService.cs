using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ESchool.ViewModels.InputModels.Answer;

namespace ESchool.Services.Contracts
{
    public interface IAnswerService
    {
        Task<string> Create(AnswerInputModel model);
    }
}
