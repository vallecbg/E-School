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

        public QuestionService(UserManager<User> userManager, ESchoolContext context, IMapper mapper) 
            : base(userManager, context, mapper)
        {
        }

        public async Task<string> Create(QuestionInputModel model)
        {
            var cloudinary = SetCloudinary();

            var url = await UploadImage(cloudinary, model.Image, model.QuestionText);

            var question = Mapper.Map<Question>(model);

            question.ImageUrl = url ?? GlobalConstants.NoImageAvailableUrl;

            this.Context.Questions.Add(question);
            await this.Context.SaveChangesAsync();

            return question.Id;
        }
    }
}
