using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESchool.Data;
using ESchool.Models;
using ESchool.Services.Contracts;
using ESchool.ViewModels.OutputModels.Api;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ESchool.Services
{
    public class ApiService : BaseService, IApiService
    {
        public ApiService(UserManager<User> userManager, ESchoolContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }

        public IEnumerable<ExamApiOutputModel> Exams()
        {
            var result = this.Context.Exams
                .Include(x => x.UserAnswers)
                .Include(x => x.Questions)
                .ThenInclude(x => x.PossibleAnswers)
                .ProjectTo<ExamApiOutputModel>(Mapper.ConfigurationProvider)
                .ToList();

            return result;
        }
    }
}
