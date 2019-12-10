using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Services.Constants;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Answer;
using ESchool.ViewModels.InputModels.Question;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Web.Controllers
{
    [Authorize]
    public class AnswerController : Controller
    {
        private readonly IAnswerService answerService;

        public AnswerController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }

        [HttpGet]
        [Route(GlobalConstants.RouteConstants.CreateAnswerRoute)]
        public IActionResult Create(string questionId)
        {
            this.ViewData[GlobalConstants.QuestionId] = questionId;
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnswerInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData[GlobalConstants.QuestionId] = model.QuestionId;
                return this.View();
            }

            await this.answerService.Create(model);


            return this.RedirectToAction("Index", "Home");
        }
    }
}
