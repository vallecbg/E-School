using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESchool.Data;
using ESchool.Models;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Exams;
using ESchool.ViewModels.OutputModels.Api;
using ESchool.ViewModels.OutputModels.Exam;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public Exam FindById(string id)
        {
            var exam = this.Context.Exams.Find(id);

            return exam;
        }

        public ExamOutputModel GetExamDetails(string examId)
        {
            var exam = this.Context.Exams
                .Include(x => x.UserAnswers)
                .Include(x => x.Questions)
                .ThenInclude(x => x.PossibleAnswers)
                .FirstOrDefault(x => x.Id == examId);

            var examOutput = Mapper.Map<ExamOutputModel>(exam);

            return examOutput;
        }

        public ExamApiOutputModel GetExamSolve(string id)
        {
            var exam = this.Context.Exams
                .Include(x => x.UserAnswers)
                .Include(x => x.Questions)
                .ThenInclude(x => x.PossibleAnswers)
                .FirstOrDefault(x => x.Id == id);

            var examOutput = Mapper.Map<ExamApiOutputModel>(exam);

            return examOutput;
        }
    }
}
