using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using EindopdrachtBackEnd.DTO;
using EindopdrachtBackEnd.Models;
using Xunit;

namespace EindOpdrachtBackend.Test
{

    public class SneakerControllerTest :IClassFixture<WebApplicationFactory<EindopdrachtBackEnd.Startup>>
    {
        public HttpClient Client {get;}

        public SneakerControllerTest(WebApplicationFactory<EindopdrachtBackEnd.Startup> fixture){

            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Studios_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/studios");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var studios = JsonConvert.DeserializeObject<List<StudioDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(studios.Count > 0);
        }

        [Fact]
        public async Task Get_Genres_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/genres");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var genres = JsonConvert.DeserializeObject<List<GenreDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(genres.Count > 0);
        }

        [Fact]
        public async Task Get_StreamingServices_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/streamingServices");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var streamingServices = JsonConvert.DeserializeObject<List<StreamingServiceDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(streamingServices.Count > 0);
        }

        [Fact]
        public async Task Get_Animes_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/animes");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var animes = JsonConvert.DeserializeObject<List<AnimeDTO>>(await response.Content.ReadAsStringAsync());
            Assert.True(animes.Count > 0);
        }

        [Fact]
        public async Task Get_One_Genre_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/genre/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var genre = JsonConvert.DeserializeObject<GenreDTO>(await response.Content.ReadAsStringAsync());
            Assert.True(genre.Name == "Action");
        }

        [Fact]
        public async Task Get_One_Anime_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/anime/name/One punch man!");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_One_StreamingService_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/streamingservice/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_One_Studio_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/api/studio/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        //=======================================================================================================================================================================================================================

        // IF YOU WANT TO TEST THE TESTS UNDERNEATH, YOU'LL HAVE TO UNAUTHORIZE THE ANIME CONTROLLER SINCE THESE TESTS ARE BEHIND A AUTH0 AUTHENTICATION. THE TESTS ABOVE ARE ACCESIBLE FOR EVERYONE.
        // SO IF YOU ONLY WANT TO TEST THE TESTS ABOVE, YOU CAN PUT THE TESTS UNDERNEATH IN COMMENT WITH "//"

        [Fact]
        public async Task Post_One_Anime_Should_Return_Ok()
        {
            var anime = new AnimeDTO(){ 
                URLImage = "https://m.media-amazon.com/images/M/MV5BMjUxMzE4ZDctODNjMS00MzIwLThjNDktODkwYjc5YWU0MDc0XkEyXkFqcGdeQXVyNjc3OTE4Nzk@._V1_UY1200_CR85,0,630,1200_AL_.jpg", 
                Name = "Steins Gate" , 
                Synopsis = "Steins; Gate is a story about time travel and the consequences of it's misuse. The protagonist is a man named Okabe Rintarou; a self-proclaimed 'mad scientist' who goes by the name of Hououin Kyouma. He is about to attend a lecture from a man proclaiming to have discovered the secrets of time travel, Rintarou then challenges his theorem by claiming a man named 'John Titor' has beaten him to it. He is taken away from the lecture by a strange girl named Makise Kurisu who asks him about a previous conversation they had not too long ago, but Rintarou has no idea who this girl is and leaves her- only to find out that shortly after his departure she has been stabbed to death. Perplexed by these recent events, Rintarou sends a message to a friend named Itaru concerning Kurisu's murder. As he clicks the 'send message button' he is unconsciously thrown into a alternate reality several inconsistencies with his own memories such as John Titor never appearing in 2010 or there being a large satellite crashed into the roof of the radio kaikan. Dumbfounded by this experience, he begins to piece together a successful method of time travel. On completion, he begins to misuse this power by helping out friends with past dilemmas, not considering the weight of his actions. Eventually leading to consequences so great, he questions whether or not time travel was worth discovering after all..." , 
                Rating = 10,
                StudioId = 18,
                GenreId =10,
                AnimeStreamingServices = new List<int>(){ 1, 3, 6, 7 }
            };

            string json = JsonConvert.SerializeObject(anime);

            var response = await Client.PostAsync("/api/anime", 
            new StringContent(json,Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdAnime = JsonConvert.DeserializeObject<AnimeDTO>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdAnime);
            Assert.Equal<string>("Steins Gate", createdAnime.Name);
 
        }
    
        [Fact]
        public async Task Delete_One_Anime_Should_Return_Ok()
        {
            var response = await Client.DeleteAsync("/api/anime/Steins Gate");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_One_Anime_Should_Return_Ok()
        {
            var update ="TEST ONE PUUUUNCH MAN!!!";
            var response = await Client.PutAsync("/api/anime/One punch man Season 2/One Punch Man!", 
            new StringContent(update));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }    
    }
}
