using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESchool.Data;
using ESchool.Models;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Exams;
using Microsoft.AspNetCore.Identity;

namespace ESchool.Services
{
    public class ExamService : BaseService, IExamService
    {
        public ExamService(UserManager<User> userManager, ESchoolContext context, IMapper mapper) : base(userManager, context, mapper)
        {
        }

        public async Task<string> CreateExam(ExamInputModel model)
        {
            var exam = Mapper.Map<Exam>(model);

            this.Context.Exams.Add(exam);
            await this.Context.SaveChangesAsync();

            return exam.Id;
        }
    }
}
