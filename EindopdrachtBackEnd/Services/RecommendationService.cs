using System;

namespace EindopdrachtBackEnd.Services
{
    public interface IRecommendationService
    {
        string Recommendation(decimal score);
    }

    public class RecommendationService : IRecommendationService
    {

        // GET RECOMMENDATION BASED ON SCORE

        public string Recommendation(decimal score)
        {
            var advice = "";

            if (score < 0 || score > 10)
                throw new ArgumentException("invalid score!");

            else if (score > 7 && score <= 10)
            {
                advice = "This show is worth watching!";
            }
            else if (score >= 4 && score <= 7)
            {
                advice = "This show is mediocre at best, watch it when there's nothing else to watch!";
            }
            else
            {
                advice = "This show is the definition of trash!";
            }

            return advice;
        }
    }
}
