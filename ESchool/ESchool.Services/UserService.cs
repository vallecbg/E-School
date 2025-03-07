﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESchool.Data;
using ESchool.Models;
using ESchool.Services.Constants;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Users;
using Microsoft.AspNetCore.Identity;

namespace ESchool.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly SignInManager<User> signInManager;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, ESchoolContext context, IMapper mapper)
            : base(userManager, context, mapper)
        {
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> Register(RegisterInputModel registerModel)
        {
            bool uniqueUsername = this.Context.Users.All(x => x.UserName != registerModel.Username);

            if (!uniqueUsername)
            {
                return SignInResult.Failed;
            }

            var user = Mapper.Map<User>(registerModel);

            await this.UserManager.CreateAsync(user);
            await this.UserManager.AddPasswordAsync(user, registerModel.Password);
            //TODO: think about the roles
            await this.UserManager.AddToRoleAsync(user, GlobalConstants.StudentRole);
            var result = await this.signInManager.PasswordSignInAsync(user, registerModel.Password, true, false);

            return result;
        }

        public SignInResult Login(LoginInputModel loginModel)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.UserName == loginModel.Username);

            if (user == null)
            {
                return SignInResult.Failed;
            }

            var password = loginModel.Password;
            var result = this.signInManager.PasswordSignInAsync(user, password, true, false).Result;

            return result;
        }

        //public UserOutputModel GetUserDetails(string id)
        //{
        //    var user = this.Context.Users
        //        .Include(x => x.Robots)
        //        .Include(x => x.SentRobots)
        //        .ThenInclude(x => x.Robot)
        //        .Include(x => x.ReceivedRobots)
        //        .ThenInclude(x => x.Robot)
        //        .First(x => x.Id == id);

        //    var userResult = this.Mapper.Map<UserOutputModel>(user);

        //    return userResult;
        //}

        public async void Logout()
        {
            await this.signInManager.SignOutAsync();
        }

        public string GetName(string id)
        {
            var name = this.Context.Users
                .Find(id)
                .Name;

            return name;
        }
    }
}
