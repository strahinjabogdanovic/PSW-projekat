using System.Collections.Generic;

namespace PswProject.dto
{
    public class SurveyDTO
    {
        public List<int> SurveyQuestions { get; set; }
        public List<int> SurveyAnswers { get; set; }

        public SurveyDTO(){}
    }
}
