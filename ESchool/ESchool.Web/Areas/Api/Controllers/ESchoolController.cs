using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Models;
using ESchool.Services.Constants;
using ESchool.Services.Contracts;
using ESchool.ViewModels.InputModels.Exams;
using ESchool.ViewModels.OutputModels.Api;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Web.Areas.Api.Controllers
{
    [Route(GlobalConstants.RouteConstants.ApiRoute)]
    [ApiController]
    public class ESchoolController : ControllerBase
    {
        protected IApiService ApiService { get; set; }

        public ESchoolController(IApiService apiService)
        {
            this.ApiService = apiService;
        }

        // GET: api/Exams
        [HttpGet]
        [Route(GlobalConstants.RouteConstants.Exams)]
        public ActionResult<IEnumerable<ExamApiOutputModel>> Exams()
        {
            var exams = this.ApiService.Exams();
            if (exams == null)
            {
                return NotFound();
            }
            return new List<ExamApiOutputModel>(exams);
        }

        [HttpPost]
        public async Task<ActionResult<UserAnswer>> Solve(ExamSolveInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                var result = this.ApiService.SolveExam(model);
                //TODO: check if need to evaluate
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
