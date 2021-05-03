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


        // GET ALL ITEMS
        // ======================================================================================================================

        [HttpGet]
        [AllowAnonymous]
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

        // GET ALL STUDIOS

        [HttpGet]
        [AllowAnonymous]
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

        // GET ALL STREAMINGSERVICES

        [HttpGet]
        [AllowAnonymous]
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


        // GET ALL ANIME V1 (PURE) => VERSIONING
        
        [HttpGet]
        [AllowAnonymous]
        [Route("animes")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<Anime>>> GetAnimesV1()
        {
            try{
                return new OkObjectResult(await _animeService.GetAnimesV1());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        // GET ALL ANIME V2 (DTO) => VERSIONING

        [HttpGet]
        [AllowAnonymous]
        [Route("animes")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<List<AllAnimeDTO>>> GetAnimesV2()
        {
            try{
                return new OkObjectResult(await _animeService.GetAnimesV2());
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

       



        // GET ONE ITEM
        // ======================================================================================================================

        // GET ONE ANIME BY ID

        [HttpGet]
        [AllowAnonymous]
        [Route("anime/Id/{animeId}")]
        public async Task<ActionResult<List<AnimeDTO>>> GetAnimeById(Guid animeId)
        {
            try{
                return new OkObjectResult(await _animeService.GetAnimeById(animeId));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        // GET ONE ANIME BY NAME

        [HttpGet]
        [AllowAnonymous]
        [Route("anime/name/{animeName}")]
        public async Task<ActionResult<List<AnimeDTO>>> GetAnimeByName(string animeName)
        {
            try{
                return new OkObjectResult(await _animeService.GetAnimeByName(animeName));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        // GET ONE GENRE BY ID

        [HttpGet]
        [AllowAnonymous]
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

        // GET ONE STREAMINGSERVICE BY ID

        [HttpGet]
        [AllowAnonymous]
        [Route("streamingService/{id}")]
        public async Task<ActionResult<List<StreamingServiceDTO>>> GetStreamingService(int id)
        {
            try{
                return new OkObjectResult(await _animeService.GetStreamingService(id));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        // GET ONE STUDIO BY ID

        [HttpGet]
        [AllowAnonymous]
        [Route("studio/{id}")]
        public async Task<ActionResult<List<StreamingServiceDTO>>> GetStudio(int id)
        {
            try{
                return new OkObjectResult(await _animeService.GetStudio(id));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }
       




       // POST/DELETE/UDPATE
       // ======================================================================================================================
    
        // POST ONE ANIME
        
        [HttpPost]
        [Route("anime")]
        public async Task<ActionResult<AnimeDTO>> AddAnime(AnimeDTO anime)
        {
            try{
                return new OkObjectResult(await _animeService.AddAnime(anime));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }




        // ======================================================================================================================

        // UPDATE ONE STUDIO

        [HttpPut]
        [Route("studio/{studioId}/{update}")]
        public async Task<ActionResult<string>> UpdateStudio(int studioId, string update)
        {
            try{
                return new OkObjectResult(await _animeService.UpdateStudio(studioId, update));

            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }


        // UPDATE ANIME WITH A SPECIFIC NAME

        [HttpPut]
        [Route("anime/{anime}/{update}")]
        public async Task<ActionResult<Anime>> UpdateAnime(string anime, string update)
        {
            try{
                return new OkObjectResult(await _animeService.UpdateAnime(anime, update));

            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }




        // ======================================================================================================================

        // DELETE ANIME WITH SPECIFIC NAME 

        [HttpDelete]
        [Route("anime/{anime}")]
        public async Task<ActionResult<string>> DeleteAnime(string anime)
        {
            try{
                return new OkObjectResult(await _animeService.DeleteAnime(anime));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }

        
        // DELETE ONE STUDIO WITH A SPECIFIC ID

        [HttpDelete]
        [Route("studio/{studioId}")]
        public async Task<ActionResult<string>> DeleteStudio(int studioId)
        {
            try{
                await _animeService.DeleteStudio(studioId);
                return new OkObjectResult("The Studio has been deleted!");
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }
    }
}
