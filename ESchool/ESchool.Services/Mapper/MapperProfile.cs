using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ESchool.Models;
using ESchool.ViewModels.InputModels.Users;

namespace ESchool.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterInputModel, User>();
        }

    }
}
