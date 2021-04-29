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
        Task<StreamingServiceDTO> GetStreamingService(int streamingServiceId);
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

        // GET ANIME
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

        public async Task<List<AllAnimeDTO>> GetAnimesV2()
        {
            return _mapper.Map<List<AllAnimeDTO>>(await _animeRepository.GetAnimes());
        }

        public async Task<List<AnimeDTO>> GetAnimesV1()
        {
            return _mapper.Map<List<AnimeDTO>>(await _animeRepository.GetAnimes());
        }

        // GET GENRES
        public async Task<GenreDTO> GetGenre(int genreId)
        {
            return _mapper.Map<GenreDTO>(await _genreRepository.GetGenre(genreId));
        }

        public async Task<List<GenreDTO>> GetGenres()
        {
            return _mapper.Map<List<GenreDTO>>(await _genreRepository.GetGenres());
        }

        // GET STUDIOS
        public async Task<StudioDTO> GetStudio(int studioId)
        {
            return _mapper.Map<StudioDTO>(await _studioRepository.GetStudio(studioId));
        }

        public async Task<List<StudioDTO>> GetStudios()
        {
            return _mapper.Map<List<StudioDTO>>(await _studioRepository.GetStudios());
        }

        // GET STREAMINGSERVICES
        public async Task<StreamingServiceDTO> GetStreamingService(int streamingServiceId)
        {
            return _mapper.Map<StreamingServiceDTO>(await _streamingServiceRepository.GetStreamingService(streamingServiceId));
        }

        public async Task<List<StreamingServiceDTO>> GetStreamingServices()
        {
            return _mapper.Map<List<StreamingServiceDTO>>(await _streamingServiceRepository.GetStreamingServices());
        }

        // ADD ANIME
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


        // DELETE STUDIO

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
    }
}
