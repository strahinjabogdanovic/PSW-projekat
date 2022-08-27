using PswProject.model;
using PswProject.repository;
using System.Collections.Generic;
using System.Linq;

namespace PswProject.service
{
    public class SurveyService
    {
        private SurveySqlRepository SurveyRepository { get; set; }
        private SurveyRepository SurveyRepositorys { get; set; }
        private SurveyQuestionSqlRepository SurveyQuestionRepository { get; set; }
        private Survey survey = new Survey();

        public SurveyService(SurveySqlRepository surveyRepository)
        {
            SurveyRepositorys = surveyRepository;
        }

        public SurveyService(SurveyQuestionSqlRepository SurveyQuestionSqlRepository)
        {
            SurveyQuestionRepository = SurveyQuestionSqlRepository;
        }

        public bool CheckIfExistsById(int id)
        {
            List<Survey> surveys = SurveyRepositorys.GetAll().ToList();

            return survey.IdEqual(surveys, id);
        }

        public void CreateSurvey(List<AnsweredQuestion> answeredQuestion, string id, string ap)
        {
            SurveyRepositorys.CreateSurvey(answeredQuestion, id, ap);
        }

        public List<SurveyQuestion> GetAll()
        {
            return SurveyQuestionRepository.GetAll();
        }
    }
}
