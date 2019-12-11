using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ESchool.Models;
using ESchool.ViewModels.InputModels.Answer;
using ESchool.ViewModels.InputModels.Exams;
using ESchool.ViewModels.InputModels.Question;
using ESchool.ViewModels.InputModels.Users;
using ESchool.ViewModels.OutputModels.Exam;

namespace ESchool.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterInputModel, User>();

            CreateMap<ExamInputModel, Exam>()
                .ForMember(x => x.Name, cfg => cfg.MapFrom(x => x.Name))
                .ForMember(x => x.Description, cfg => cfg.MapFrom(x => x.Description))
                .ForMember(x => x.StartDate, cfg => cfg.MapFrom(x => x.StartDate))
                .ForMember(x => x.EndDate, cfg => cfg.MapFrom(x => x.EndDate))
                .ForMember(x => x.IsOpen, cfg => cfg.MapFrom(x => x.IsOpen))
                .ForMember(x => x.MaxMarks, cfg => cfg.MapFrom(x => x.MaxMarks))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<QuestionInputModel, Question>()
                .ForMember(x => x.QuestionText, cfg => cfg.MapFrom(x => x.QuestionText))
                .ForMember(x => x.Marks, cfg => cfg.MapFrom(x => x.Marks))
                .ForMember(x => x.ExamId, cfg => cfg.MapFrom(x => x.ExamId))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<AnswerInputModel, OfferedAnswer>()
                .ForMember(x => x.AnswerText, cfg => cfg.MapFrom(x => x.AnswerText))
                .ForMember(x => x.IsCorrect, cfg => cfg.MapFrom(x => x.IsCorrect));
            //TODO: think if need to add ignore all other

            CreateMap<Exam, ExamOutputModel>()
                .ForMember(x => x.StartDate, cfg => cfg.MapFrom(x => x.StartDate.ToString("g")))
                .ForMember(x => x.EndDate, cfg => cfg.MapFrom(x => x.EndDate.ToString("g")));
        }

    }
}
