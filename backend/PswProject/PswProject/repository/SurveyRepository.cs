using PswProject.model;
using System.Collections.Generic;

namespace PswProject.repository
{
    public interface SurveyRepository : IGenericRepository<Survey, int>
    {
        public bool CheckIfExistsById(int id);
        public void CreateSurvey(List<AnsweredQuestion> answeredQuestion, string id, string ap);
    }
}
