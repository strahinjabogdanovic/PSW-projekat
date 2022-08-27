using Microsoft.AspNetCore.Mvc;
using PswProject.model;
using PswProject.repository;
using PswProject.service;
using System.Collections.Generic;

namespace PswProject.controller
{
    [Route("[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public SurveyQuestionSqlRepository repoSurveyQuestion = new SurveyQuestionSqlRepository();
        public SurveySqlRepository repoSurvey;
        public SurveyService surveyService;

        public SurveyController(MyDbContext db)
        {
            this.dbContext = db;
            repoSurvey = new SurveySqlRepository(db);
            surveyService = new SurveyService(repoSurvey);
        }


        [HttpGet("/survey")] 
        public IActionResult Get()
        {
            repoSurveyQuestion.dbContext = dbContext;
            return Ok(repoSurveyQuestion.GetAll());

        }


        [HttpPost("/survey/{id}/{ap}")]
        public IActionResult Post(List<AnsweredQuestion> answeredQuestion, string id, string ap)
        {
            surveyService.CreateSurvey(answeredQuestion, id, ap);
            return Ok();
        }
    }
}
