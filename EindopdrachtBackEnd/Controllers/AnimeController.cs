using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EindopdrachtBackEnd.DTO;
using EindopdrachtBackEnd.Models;
using EindopdrachtBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace EindopdrachtBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class AnimeController: ControllerBase
    {
        private readonly IAnimeService _animeService;
        private readonly ILogger<AnimeController> _logger;

        public AnimeController(ILogger<AnimeController> logger,IAnimeService animeService)
        {
            _logger = logger;
            _animeService = animeService;
        }

        // GET ALL GENRES / STUDIOS / DEVICES / STREAMINGSERVICES / ANIMES

        [HttpGet]
        [Route("genres")]
        public async Task<ActionResult<List<GenreDTO>>> GetGenres()
        {
            try{
                return new OkObjectResult(await _animeService.GetGenres());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("studios")]
        public async Task<ActionResult<List<StudioDTO>>> GetStudios()
        {
            try{
                return new OkObjectResult(await _animeService.GetStudios());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }


        [HttpGet]
        [Route("streamingServices")]
        public async Task<ActionResult<List<StreamingServiceDTO>>> GetStreamingServices()
        {
            try{
                return new OkObjectResult(await _animeService.GetStreamingServices());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("animes")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<AnimeDTO>>> GetAnimes()
        {
            try{
                return new OkObjectResult(await _animeService.GetAnimes());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }



        [HttpGet]
        [Route("anime/{animeId}")]
        public async Task<ActionResult<List<AnimeDTO>>> GetAnimeById(Guid animeId)
        {
            try{
                return new OkObjectResult(await _animeService.GetAnime(animeId));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }





        // GET ONE GENRE / STUDIO / DEVICE / STREAMINGSERVICE / ANIME

        // GET ONE GENRE
        [HttpGet]
        [Route("genre/{genreId}")]
        public async Task<ActionResult<Genre>> GetGenre(int genreId)
        {
            try{
                return new OkObjectResult(await _animeService.GetGenre(genreId));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }




        // POST ONE ANIME
        
        [HttpPost]
        [Route("anime")]
        public async Task<ActionResult<AnimeDTO>> AddSneaker(AnimeDTO anime)
        {
            try{
                return new OkObjectResult(await _animeService.AddAnime(anime));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }
    }
}
