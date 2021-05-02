using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EindopdrachtBackEnd.DTO;
using EindopdrachtBackEnd.Models;
using EindopdrachtBackEnd.Repositories;

namespace EindopdrachtBackEnd.Services
{
    public interface IAnimeService
    {
        Task<AnimeDTO> AddAnime(AnimeDTO anime);
        Task<string> DeleteAnime(string name);
        Task DeleteStudio(int studioId);
        Task<Anime> GetAnimeById(Guid animeId);
        Task<Anime> GetAnimeByName(string animeName);
        Task<List<AnimeDTO>> GetAnimesV1();
        Task<List<AllAnimeDTO>> GetAnimesV2();
        Task<GenreDTO> GetGenre(int genreId);
        Task<List<GenreDTO>> GetGenres();
        Task<StreamingService> GetStreamingService(int streamingServiceId);
        Task<List<StreamingServiceDTO>> GetStreamingServices();
        Task<StudioDTO> GetStudio(int studioId);
        Task<List<StudioDTO>> GetStudios();
        Task<List<AllAnimeDTO>> UpdateAnime(string anime, string update);
        Task<Studio> UpdateStudio(int studioId, string update);
    }

    public class AnimeService : IAnimeService
    {
        private IAnimeRepository _animeRepository;
        private IGenreRepository _genreRepository;
        private IStudioRepository _studioRepository;
        private IStreamingServiceRepository _streamingServiceRepository;
        private IMapper _mapper;

        public AnimeService(IMapper mapper, IAnimeRepository animeRepository, IGenreRepository genreRepository, IStudioRepository studioRepository, IStreamingServiceRepository streamingServiceRepository)
        {
            _mapper = mapper;
            _animeRepository = animeRepository;
            _genreRepository = genreRepository;
            _studioRepository = studioRepository;
            _streamingServiceRepository = streamingServiceRepository;
        }


        // GET ALL
        // ======================================================================================================================

        // GET ALL ANIME V2 => VERSIONING

        public async Task<List<AllAnimeDTO>> GetAnimesV2()
        {
            try
            {
                return _mapper.Map<List<AllAnimeDTO>>(await _animeRepository.GetAnimes());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // GET ALL ANIME V1 => VERSIONING

        public async Task<List<AnimeDTO>> GetAnimesV1()
        {
            try
            {
                return _mapper.Map<List<AnimeDTO>>(await _animeRepository.GetAnimes());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // GET ALL GENRES 

        public async Task<List<GenreDTO>> GetGenres()
        {
            try
            {
                return _mapper.Map<List<GenreDTO>>(await _genreRepository.GetGenres());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // GET ALL STUDIOS

        public async Task<List<StudioDTO>> GetStudios()
        {
            try
            {
                return _mapper.Map<List<StudioDTO>>(await _studioRepository.GetStudios());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // GET ALL STREAMING_SERVICES

        public async Task<List<StreamingServiceDTO>> GetStreamingServices()
        {
            try
            {
                return _mapper.Map<List<StreamingServiceDTO>>(await _streamingServiceRepository.GetStreamingServices());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }




        // GET ONE
        // ======================================================================================================================

        // GET ONE ANIME BY ID

        public async Task<Anime> GetAnimeById(Guid animeId)
        {
            try
            {
                return await _animeRepository.GetAnimeById(animeId);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // GET ONE ANIME BY NAME

        public async Task<Anime> GetAnimeByName(string animeName)
        {
            try
            {
                return await _animeRepository.GetAnimeByName(animeName);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // GET ONE GENRE BY ID

        public async Task<GenreDTO> GetGenre(int genreId)
        {
            try
            {
                return _mapper.Map<GenreDTO>(await _genreRepository.GetGenre(genreId));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // GET ONE STUDIO BY ID

        public async Task<StudioDTO> GetStudio(int studioId)
        {
            try
            {
                return _mapper.Map<StudioDTO>(await _studioRepository.GetStudio(studioId));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // GET ONE STREAMING_SERVICE BY ID

        public async Task<StreamingService> GetStreamingService(int streamingServiceId)
        {
            try
            {
                return await _streamingServiceRepository.GetStreamingService(streamingServiceId);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }




        // DELETE/POST/UPDATE
        // ======================================================================================================================

        // ADD/POST ANIME WITH OBJECT

        public async Task<AnimeDTO> AddAnime(AnimeDTO anime)
        {
            try
            {
                Anime checkIfExists = await _animeRepository.GetAnimeByName(anime.Name);
                if (checkIfExists != null)
                    return null;

                Anime newAnime = _mapper.Map<Anime>(anime);
                newAnime.AnimeId = new Guid();
                newAnime.AnimeStreamingServices = new List<AnimeStreamingService>();
                foreach (var streamingServiceId in anime.AnimeStreamingServices)
                {
                    newAnime.AnimeStreamingServices.Add(new AnimeStreamingService() { StreamingServiceId = streamingServiceId });
                }
                await _animeRepository.AddAnime(newAnime);
                return anime;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        

        //DELETE ANIME BY NAME

        public async Task<string> DeleteAnime(string name)
        {
            try
            {
                Anime checkIfExists = await _animeRepository.GetAnimeByName(name);
                if (checkIfExists == null)
                    return "The record doesn't exist!";

                await _animeRepository.DeleteAnime(name);

                return name;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // UPDATE ANIME BY NAME

        public async Task<List<AllAnimeDTO>> UpdateAnime(string anime, string update)
        {
            try
            {
                return _mapper.Map<List<AllAnimeDTO>>(await _animeRepository.UpdateAnime(anime, update));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // DELETE STUDIO BY ID

        public async Task DeleteStudio(int studioId)
        {
            try
            {
                await _studioRepository.DeleteStudio(studioId);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        // UPDATE STUDIO BY ID

        public async Task<Studio> UpdateStudio(int studioId, string update)
        {
            try
            {
                return await _studioRepository.UpdateStudio(studioId, update);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
