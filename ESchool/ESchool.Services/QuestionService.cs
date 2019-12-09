using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESchool.Data;
using ESchool.Models;
using ESchool.Services.Constants;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Question;
using Microsoft.AspNetCore.Identity;

namespace ESchool.Services
{
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IExamService examService;

        public QuestionService(UserManager<User> userManager, ESchoolContext context, IMapper mapper, IExamService examService) 
            : base(userManager, context, mapper)
        {
            this.examService = examService;
        }

        public async Task<string> Create(QuestionInputModel model)
        {
            var cloudinary = SetCloudinary();

            var url = await UploadImage(cloudinary, model.Image, model.QuestionText);

            var question = Mapper.Map<Question>(model);

            question.ImageUrl = url ?? GlobalConstants.NoImageAvailableUrl;
            question.ExamId = examService.FindById(model.ExamId).Id;
            //TODO: find if needed to set also the exam property

            this.Context.Questions.Add(question);
            await this.Context.SaveChangesAsync();

            return question.Id;
        }
    }
}
