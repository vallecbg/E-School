using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Services.Constants;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet]
        [Route(GlobalConstants.RouteConstants.CreateQuestionRoute)]
        public IActionResult Create(string examId)
        {
            this.ViewData[GlobalConstants.ExamId] = examId;
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData[GlobalConstants.ExamId] = model.ExamId;
                return this.View();
            }

            await this.questionService.Create(model);


            return this.RedirectToAction("Index", "Home");
            //var assembly = this.assemblyService.GetAssemblyById(model.AssemblyId);
            //return this.RedirectToAction("Details", "Robots", new { id = assembly.RobotId });
        }
    }
}
