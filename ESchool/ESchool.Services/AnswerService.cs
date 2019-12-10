using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESchool.Data;
using ESchool.Models;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Answer;
using Microsoft.AspNetCore.Identity;

namespace ESchool.Services
{
    public class AnswerService : BaseService, IAnswerService
    {
        public AnswerService(UserManager<User> userManager, ESchoolContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }

        public async Task<string> Create(AnswerInputModel model)
        {
            var answer = Mapper.Map<OfferedAnswer>(model);

            this.Context.OfferedAnswers.Add(answer);
            await this.Context.SaveChangesAsync();

            return answer.Id;
        }
    }
}
