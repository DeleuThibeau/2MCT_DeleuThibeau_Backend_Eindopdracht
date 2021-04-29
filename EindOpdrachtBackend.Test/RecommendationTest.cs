using System;
using Xunit;
using EindopdrachtBackEnd.Services;


namespace EindOpdrachtBackend.Test
{
    public class RecommendationTest
    {
        [Theory]
        [InlineData(10)]
        public void Give_Adivce_Score_10(decimal score){ 
            RecommendationService recommend = new RecommendationService();
             Assert.Equal<string>("This show is worth watching!", recommend.Recommendation(score));
            
        }

        [Theory]
        [InlineData(6)]
        public void Give_Adivce_Score_6(decimal score){ 
            RecommendationService recommend = new RecommendationService();
            Assert.Equal<string>("This show is mediocre at best, watch it when there's nothing else to watch!", recommend.Recommendation(score));
            
        }

        [Theory]
        [InlineData(2)]
        public void Give_Adivce_Score_2(decimal score){ 
            RecommendationService recommend = new RecommendationService();
            Assert.Equal<string>("This show is the definition of trash!", recommend.Recommendation(score));
            
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-0.1)]
        [InlineData(50)]
        [InlineData(51)]
        public void TestException(decimal score){ 
            RecommendationService recommend = new RecommendationService();
            Assert.Throws<ArgumentException>(() => recommend.Recommendation(score));    
        }
    }
}
