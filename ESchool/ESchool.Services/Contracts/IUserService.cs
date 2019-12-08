using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ESchool.ViewModels.InputModels.Users;
using Microsoft.AspNetCore.Identity;

namespace ESchool.Services.Contracts
{
    public interface IUserService
    {
        Task<SignInResult> Register(RegisterInputModel registerModel);

        SignInResult Login(LoginInputModel loginModel);

        //UserOutputModel GetUserDetails(string id);

        void Logout();

        string GetName(string id);
    }
}
