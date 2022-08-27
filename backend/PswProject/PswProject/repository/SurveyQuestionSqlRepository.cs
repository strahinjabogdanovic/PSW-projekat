using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PswProject.repository
{
    public class SurveyQuestionSqlRepository : SurveyQuestionRepository
    {
        public MyDbContext dbContext { get; set; }

        public SurveyQuestionSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public SurveyQuestionSqlRepository()
        {

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SurveyQuestion> GetAll()
        {
            List<SurveyQuestion> result = new List<SurveyQuestion>();

            dbContext.SurveyQuestion.ToList().ForEach(survey => result.Add(new SurveyQuestion(survey.Text, survey.Rating, survey.QuestionType)));

            return result;
        }

        public SurveyQuestion GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(SurveyQuestion newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(SurveyQuestion editedObject)
        {
            throw new NotImplementedException();
        }

        List<SurveyQuestion> IGenericRepository<SurveyQuestion, int>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        SurveyQuestion IGenericRepository<SurveyQuestion, int>.GetOne(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
