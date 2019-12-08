using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Models;
using ESchool.Services.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ESchool.Web.HelperMethods
{
    public class SeedRolesMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedRolesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            UserManager<User> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await SeedRoles(userManager, roleManager);
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        private async Task SeedRoles(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole
            {
                Name = GlobalConstants.AdminRole
            });

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = GlobalConstants.StudentRole
            });

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = GlobalConstants.TeacherRole
            });

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = GlobalConstants.ParentRole
            });

            var admin = new User
            {
                UserName = "admintest",
                Email = "admin@admin.com",
                Name = "The Admin"
            };

            var student = new User
            {
                UserName = "studenttest",
                Email = "student@student.com",
                Name = "The Student"
            };

            var teacher = new User
            {
                UserName = "teachertest",
                Email = "teacher@teacher.com",
                Name = "The Teacher"
            };

            var parent = new User
            {
                UserName = "parenttest",
                Email = "parent@parent.com",
                Name = "The Parent"
            };

            string adminPass = "admin123";
            string studentPass = "student123";
            string teacherPass = "teacher123";
            string parentPass = "parent123";

            await userManager.CreateAsync(admin, adminPass);
            await userManager.CreateAsync(student, studentPass);
            await userManager.CreateAsync(teacher, teacherPass);
            await userManager.CreateAsync(parent, parentPass);

            await userManager.AddToRoleAsync(admin, GlobalConstants.AdminRole);
            await userManager.AddToRoleAsync(student, GlobalConstants.StudentRole);
            await userManager.AddToRoleAsync(teacher, GlobalConstants.TeacherRole);
            await userManager.AddToRoleAsync(parent, GlobalConstants.ParentRole);
        }
    }
}
