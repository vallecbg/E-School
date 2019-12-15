using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Services.Constants;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Exams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Web.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private readonly IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = await this.examService.CreateExam(model);
            //TODO: redirect to details

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var result = this.examService.GetExamDetails(id);

            return this.View(result);
        }

        [HttpGet]
        public IActionResult Solve(string id)
        {
            var exam = this.examService.GetExamSolve(id);
            if (exam == null)
            {
                this.ViewData[GlobalConstants.Error] = GlobalConstants.RecordDoesntExist;
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(exam);
        }
    }
}
